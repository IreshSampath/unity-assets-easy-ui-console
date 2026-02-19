# 🖥️ EasyUIConsole for Unity

![EasyUIConsole Preview](Docs/Preview.png)

![Unity](https://img.shields.io/badge/Unity-2022.3%2B-green.svg)
![Platform](https://img.shields.io/badge/Platform-PC%20%7C%20Android%20%7C%20iOS%20%7C%20WebGL%20%7C%20Editor-lightgrey.svg)
![License](https://img.shields.io/badge/License-MIT-blue.svg)

---

## 🚀 Overview

**EasyUIConsole** is a lightweight in-game console for **real-time log display** in Unity.  
It provides a clean, customizable on-screen console that shows:
🎨 UI Behavior
Log Type	Color Style

- ✅ **Logs** $${\color{white}(White)}$$
- ✅ **Highlights** $${\color{green}(Green)}$$
- ✅ **Warnings** $${\color{yellow}(Yellow)}$$
- ✅ **Errors** $${\color{red}(Red)}$$

Perfect for **runtime debugging**, **mobile builds**, **playtesting**, or **live demos** where Unity’s built-in Console is not accessible.

---

## 📦 Installation

### Option A — Install via Unity Package Manager (Git URL)

1. Open **Unity → Window → Package Manager**
2. Click **+** → **Add package from Git URL**
3. Paste the following:
https://github.com/IreshSampath/unity-assets-easy-ui-console.git
4. Click **Install**

---

## 🧰 Quick Start

### ✅ Step 1 — Import Sample

1. Go to **Package Manager → EasyUIConsole → Samples**
3. Click **Import  → EasyUIConsole Sample**
4. Drag the **EasyUIConsole** prefab into your scene
   
![Easy UIConsole Prefab Preview](Docs/Prefab.png)

### ✅ Step 2 — Print Messages from Code

#### ⭐ Console Control
```csharp
using GAG.EasyUIConsole;

EasyUIC.OpenConsole();
```
👉 Opens the console panel using internal events.

#### ⭐ Direct Methods
```csharp
using GAG.EasyUIConsole;

EasyUIC.Log("Sample Log");
EasyUIC.Highlight("Sample Highlight");
EasyUIC.Warning("Sample Warning");
EasyUIC.Error("Sample Error");
```
#### ⭐ Unified Print Method (Recommended for Dynamic Systems)
```csharp
using GAG.EasyUIConsole;

EasyUIC.Print("Sample Log Print Message", EasyUIConsoleType.Log);
EasyUIC.Print("Sample Highlight Print Message", EasyUIConsoleType.Highlight);
EasyUIC.Print("Sample Warning Print Message", EasyUIConsoleType.Warning);
EasyUIC.Print("Sample Error Print Message", EasyUIConsoleType.Error);
```
👉 This automatically raises internal events — no direct Manager access required.
---

## 📜 License
IT License — Free for commercial and personal use.

---

## 🙏 Thank You
Thanks for using EasyUIConsole!
- Feel free to contribute
⭐ Star the repo
🐞 Report issues
🚀 Suggest improvements

---

## 👤 Author
Iresh Sampath 🔗 [LinkedIn Profile](https://www.linkedin.com/in/ireshsampath/)
