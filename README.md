[![CI](https://github.com/G-Research/hiddenwindow/actions/workflows/ci.yml/badge.svg?branch=main&event=push)](https://github.com/G-Research/hiddenwindow/actions/workflows/ci.yml?query=branch%main+event%3Apush)
[![NuGet](https://img.shields.io/nuget/vpre/consul)](https://www.nuget.org/packages/Consul/absoluteLatest)
[![License](https://img.shields.io/github/license/G-Research/hiddenwindow.svg?label=License)](https://github.com/G-Research/hiddenwindow/blob/main/LICENSE)
[![Twitter Follow](https://img.shields.io/twitter/follow/oss_gr.svg?label=Twitter)](https://twitter.com/oss_gr)

# HiddenWindow

A lightweight .NET library that enables console applications to receive and respond to Windows messages, particularly the TaskKill signal, by creating a hidden window with an associated message loop.

## About the Project

HiddenWindow solves a common challenge in Windows console applications: the inability to gracefully handle termination signals like TaskKill. By creating a hidden window with a Windows message loop, this library allows your console application to intercept and respond to these signals before the application is forcefully terminated.

This is particularly useful for applications that need to perform cleanup operations, save state, or notify other services before shutting down. Without HiddenWindow, a TaskKill command would immediately terminate your application without any opportunity to respond.

The library is designed to be simple to use with minimal overhead, making it an ideal solution for any .NET console application that requires graceful shutdown capabilities.

## Getting Started

### Installation

Install the package via NuGet:

```bash
dotnet add package HiddenWindow
```

### Basic Usage

Add the following code to your console application:

```csharp
using HiddenWindow;

class Program
{
    static void Main(string[] args)
    {
        // Register an event handler for the close signal
        HiddenWindow.OnClose += (message) => 
        {
            Console.WriteLine("Application is shutting down...");
            // Perform cleanup operations here
        };
        
        // Create the hidden window
        HiddenWindow.Create();
        
        // Your application code continues here
        Console.WriteLine("Application is running. Press Ctrl+C to exit.");
        
        // Keep the application running
        Console.ReadLine();
    }
}
```

### How It Works

HiddenWindow creates an invisible window with a Windows message loop that intercepts system messages. When a TaskKill signal is received, the library raises the `OnClose` event, allowing your application to perform any necessary cleanup before termination.

## Contributing

We welcome contributions to HiddenWindow! Whether you're fixing a bug, adding a feature, or improving documentation, your help is greatly appreciated.

### How to Contribute

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

For more detailed contribution guidelines, please see our [CONTRIBUTING.md](CONTRIBUTING.md).

## Security

Please see our [security policy](SECURITY.md) for details on reporting security vulnerabilities.

## License

This project is licensed under the Apache License 2.0 - see the [LICENSE](LICENSE) file for details.
