# HiddenWindow

A library for creating a Hidden Window with associated Windows message loop so that Console applications can receive signals.
In particular this allows a ConsoleApplication to capture and respond to TaskKill signal.

## Usage

Add a reference to the nuget package and call:

```C#
HiddenWindow.OnClose += OnCloseEventHandler
HiddenWindow.Create();
```
