# Unity-MCP
 
# Project Setup Instructions

This guide outlines the required setup for working with this Unity project, including package installations, external tools, and dependencies.

---

## 📦 Unity MCP Package Installation
Add the following package into Unity via the **Package Manager**:
https://github.com/justinpbarnett/unity-mcp

To do this:
1. Open Unity and go to `Window > Package Manager`.
2. Click the `+` icon and select `Add package from Git URL...`.
3. Paste the URL and click `Add`.

---

## 🧪 Install UV (Universal Virtualenv)

UV is required for Python environment management.

### Option 1: Install via PowerShell (Recommended)
1. Open PowerShell and run the following command:
   ```powershell
   iwr https://astral.sh/uv/install.ps1 -useb | iex
Option 2: If the above doesn't work
Run:
pip install uv
More info: [UV Installation Guide](https://docs.astral.sh/uv/getting-started/installation/#github-releases)

Install Claude (AI Assistant)
Create a [Claude](https://claude.ai) account.
Download the desktop apps: Claude Desktop Apps

Install Python 3.12+
Download and install the latest version of Python (3.12 or newer):
[Download Python](https://www.python.org/downloads/)
Make sure to check "Add Python to PATH" during installation.

Final Checks:
-Unity MCP added via Package Manager
-UV installed and working (uv --version)
-Claude account created and app installed
-Python 3.12+ installed and added to PATH

Feel free to open an issue or contact the maintainer if you encounter any problems during setup.
