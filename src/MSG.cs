using System;
using System.Runtime.InteropServices;

namespace HiddenWindow
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct POINT
    {
        public FIXED x;
        public FIXED y;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct FIXED
    {
        public short fract;
        public short value;
    }

    /// <summary>
    /// Win32 Structure
    /// Defined in winuser.h
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]

    internal struct MSG
    {
        public IntPtr hwnd;
        public uint message;
        public UIntPtr wParam;
        public IntPtr lParam;
        public int time;
        public POINT pt;
    }
}