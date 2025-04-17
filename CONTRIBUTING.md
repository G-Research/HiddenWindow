# Contributing to HiddenWindow

Thank you for your interest in contributing to HiddenWindow! This document provides guidelines and instructions for contributing to this project.

## Code of Conduct

By participating in this project, you agree to abide by our [Code of Conduct](CODE_OF_CONDUCT.md). Please read it before contributing.

## How to Contribute

### Reporting Bugs

- Check if the bug has already been reported in the [Issues](https://github.com/G-Research/HiddenWindow/issues) section.
- If not, create a new issue with a clear title and description, following the [issue template](.github/ISSUE_TEMPLATE/bug_report_form.yaml).
- Include as much relevant information as possible, such as:
  - Steps to reproduce the issue
  - Expected behavior
  - Actual behavior
  - Screenshots or code snippets if applicable
  - Environment details (OS, .NET version, etc.)

### Suggesting Enhancements

- Check if the enhancement has already been suggested in the [Issues](https://github.com/G-Research/HiddenWindow/issues) section.
- If not, create a new issue with a clear title and description, following the [issue template](.github/ISSUE_TEMPLATE/feature_request_form.yaml).
- Explain why this enhancement would be useful to most HiddenWindow users.
- Include any mockups or examples if applicable.

### Pull Requests

1. Fork the repository and create your branch from `main`.
2. Make sure your code lints.
3. Make sure the [CI](https://github.com/G-Research/HiddenWindow/actions) pipeline passes.
4. Issue that pull request!

## Development Setup

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version compatible with the project's target framework)
- A code editor (Visual Studio, VS Code, etc.)
- Git

### Building the Project

1. Clone the repository:
   ```bash
   git clone https://github.com/G-Research/HiddenWindow.git
   cd HiddenWindow
   ```

2. Build the project:
   ```bash
   dotnet build
   ```

3. Run tests:
   ```bash
   dotnet test
   ```

### Coding Standards

- Follow the C# coding conventions used in the project.
- Use meaningful variable and method names.
- Add comments for complex logic.
- Keep methods focused and concise.
- Write unit tests for new functionality.

## Questions or Need Help?

If you have questions or need help with contributing, please:

1. Check the existing [Issues](https://github.com/G-Research/HiddenWindow/issues) to see if your question has already been answered.
2. If not, create a new issue with your question.
