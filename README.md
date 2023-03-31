[![CI](https://github.com/G-Research/hiddenwindow/actions/workflows/ci.yml/badge.svg?branch=main&event=push)](https://github.com/G-Research/hiddenwindow/actions/workflows/ci.yml?query=branch%main+event%3Apush)
[![NuGet](https://img.shields.io/nuget/vpre/consul)](https://www.nuget.org/packages/Consul/absoluteLatest)
[![License](https://img.shields.io/github/license/G-Research/hiddenwindow.svg?label=License)](https://github.com/G-Research/hiddenwindow/blob/main/LICENSE)
[![Twitter Follow](https://img.shields.io/twitter/follow/oss_gr.svg?label=Twitter)](https://twitter.com/oss_gr)

# HiddenWindow

A library for creating a Hidden Window with associated Windows message loop so that Console applications can receive signals.
In particular this allows a ConsoleApplication to capture and respond to TaskKill signal.

## Usage

Add a reference to the nuget package and call:

```C#
HiddenWindow.OnClose += OnCloseEventHandler
HiddenWindow.Create();
```
