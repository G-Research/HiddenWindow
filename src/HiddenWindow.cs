using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace HiddenWindow
{
    internal delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    // TODO: I think I would like some logging...
    public class HiddenWindow
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr CreateWindowEx(
           WindowStylesEx dwExStyle,
           [MarshalAs(UnmanagedType.LPStr)] string lpClassName,
           [MarshalAs(UnmanagedType.LPStr)] string lpWindowName,
           WindowStyles dwStyle,
           int x,
           int y,
           int nWidth,
           int nHeight,
           IntPtr hWndParent,
           IntPtr hMenu,
           IntPtr hInstance,
           IntPtr lpParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.U2)]
        private static extern short RegisterClassEx([In] ref WNDCLASSEX lpwcx);

        [DllImport("user32.dll")]
        private static extern int GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

        [DllImport("user32.dll")]
        private static extern bool TranslateMessage([In] ref MSG lpMsg);

        [DllImport("user32.dll")]
        private static extern IntPtr DispatchMessage([In] ref MSG lpmsg);

        [DllImport("user32.dll")]
        private static extern IntPtr DefWindowProc(IntPtr hWnd, WM uMsg, IntPtr wParam, IntPtr lParam);

        public delegate void Message(uint message);
        public static event Message OnClose;
        public static event Message OnMessage;

        public static void Create()
        {
            // trap the task?
            Task.Run(() => InternalCreate());
        }

        private static int InternalCreate()
        {
            var szAppName = "HiddenWindow";
            IntPtr hInstance = Process.GetCurrentProcess().Handle;
            WNDCLASSEX wndclass = new WNDCLASSEX();

            wndclass.style = ClassStyles.HorizontalRedraw | ClassStyles.VerticalRedraw;
            wndclass.lpfnWndProc = (WndProc)((hWnd, message, wParam, lParam) =>
            {
                OnMessage?.Invoke(message);
                switch ((WM)message)
                {
                    case (WM.CLOSE):
                        OnClose?.Invoke(message);
                        break;
                    case WM.DESTROY:
                        return IntPtr.Zero;
                }

                return DefWindowProc(hWnd, (WM)message, wParam, lParam);
            });
            wndclass.cbSize = (uint)Marshal.SizeOf(wndclass);
            wndclass.cbClsExtra = 0;
            wndclass.cbWndExtra = 0;
            wndclass.hInstance = hInstance;
            wndclass.hIcon = IntPtr.Zero;
            wndclass.hCursor = IntPtr.Zero;
            wndclass.hbrBackground = IntPtr.Zero;
            wndclass.lpszMenuName = null;
            wndclass.lpszClassName = szAppName;

            short regResult = RegisterClassEx(ref wndclass);

            if (regResult == 0)
            {
                return 1;
            }

            IntPtr hwnd = CreateWindowEx(
                0,
                szAppName, // window class name
                "HiddenWindow", // window caption
                WindowStyles.WS_OVERLAPPEDWINDOW, // window style
                0, // initial x position
                0, // initial y position
                0, // initial x size
                0, // initial y size
                IntPtr.Zero, // parent window handle
                IntPtr.Zero, // window menu handle
                hInstance, // program instance handle
                IntPtr.Zero); // creation parameters

            if (hwnd == IntPtr.Zero)
            {
                int lastError = Marshal.GetLastWin32Error();
                string errorMessage = new Win32Exception(lastError).Message;

                return lastError;
            }

            ProcessMessage();

            return 0;
        }

        private static void ProcessMessage()
        {
            MSG msg;
            int ret;
            while ((ret = GetMessage(out msg, IntPtr.Zero, 0, 0)) != 0)
            {
                if (ret == -1)
                {
                    //-1 indicates an error
                    break;
                }
                else
                {
                    TranslateMessage(ref msg);
                    DispatchMessage(ref msg);
                }
            }
        }
    }
}
