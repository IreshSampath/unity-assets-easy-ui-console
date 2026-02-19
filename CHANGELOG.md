# Changelog
All notable changes to **EasyUIConsole** will be documented in this file.

The format is based on Keep a Changelog
and this project adheres to Semantic Versioning.

---

## [2.0.0] - 2026-02-19

### 🚀 Added
- New event-driven architecture for console logging
- `EasyUIC` static API for simplified usage
- Auto-initialization support using RuntimeInitializeOnLoadMethod
- ConsoleType enum support
- Improved modular structure for future extensions

### 🔄 Changed
- Refactored internal logging flow to use Events instead of direct Manager calls
- Updated README documentation to reflect new architecture
- Improved sample scene and usage flow
- Package structure cleaned and optimized

### 🧹 Removed
- Direct dependency on EasyUIConsoleManager from public API
- Legacy log invocation methods

### 🐞 Fixed
- Manager initialization order issues
- Minor UI rendering inconsistencies

---

## [1.2.2] - Previous Version

### Added
- Highlight log type support
- Improved UI styling

### Fixed
- Minor runtime console display issues

---

## [1.0.0]

### Initial Release
- Basic in-game console UI
- Log / Warning / Error display
- TextMeshPro integration
