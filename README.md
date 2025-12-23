# 🎯 FaceIT Scoreboard for SwiftlyS2

[![Source 2](https://img.shields.io/badge/Source%202-orange?style=for-the-badge&logo=valve&logoColor=white)](https://developer.valvesoftware.com/wiki/Source_2)
[![SwiftlyS2](https://img.shields.io/badge/SwiftlyS2-1.0.0-blue?style=for-the-badge)](https://github.com/swiftly-solution/swiftlys2)
[![.NET](https://img.shields.io/badge/.NET-10.0-purple?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)

> **Display FaceIT levels on the scoreboard – know who's carrying at a glance.**

| Platform | Status    |
| -------- | --------- |
| Windows  | ✅ Tested  |
| Linux    | ⏳ Pending |

## 📋 Requirements

- [SwiftlyS2](https://github.com/swiftly-solution/swiftlys2) v1.0.0+
- CS2 Dedicated Server
- [FaceIT API Key](https://developers.faceit.com/)

## 🔧 Installation

1. Download the [latest release](https://github.com/zhw1nq/swiftlyS2-faceit-scoreboard/releases)
2. Extract to `addons/swiftlys2/plugins/swiftlyS2-faceit-scoreboard/`
3. Restart the server
4. Configure `config.jsonc` with your FaceIT API key

## ⚙️ Configuration

| Option                | Type   | Default | Description                   |
| --------------------- | ------ | ------- | ----------------------------- |
| `ApiKey`              | string | `""`    | FaceIT API key (**Required**) |
| `UseCSGO`             | bool   | `false` | Fallback to CSGO data         |
| `DefaultStatus`       | bool   | `true`  | Show level by default         |
| `EnableToggleCommand` | bool   | `true`  | Allow toggle command          |
| `CacheExpiryHours`    | int    | `24`    | Cache duration                |

## 🎮 Commands

| Command   | Description                 |
| --------- | --------------------------- |
| `!faceit` | Toggle FaceIT level display |
| `!fl`     | Alias                       |

## 🌐 Languages

<p align="center">
  <img src="https://flagcdn.com/24x18/sa.png" title="Arabic">
  <img src="https://flagcdn.com/24x18/bg.png" title="Bulgarian">
  <img src="https://flagcdn.com/24x18/cz.png" title="Czech">
  <img src="https://flagcdn.com/24x18/dk.png" title="Danish">
  <img src="https://flagcdn.com/24x18/de.png" title="German">
  <img src="https://flagcdn.com/24x18/gr.png" title="Greek">
  <img src="https://flagcdn.com/24x18/gb.png" title="English">
  <img src="https://flagcdn.com/24x18/es.png" title="Spanish">
  <img src="https://flagcdn.com/24x18/mx.png" title="Latin America">
  <img src="https://flagcdn.com/24x18/fi.png" title="Finnish">
  <img src="https://flagcdn.com/24x18/fr.png" title="French">
  <img src="https://flagcdn.com/24x18/hu.png" title="Hungarian">
  <img src="https://flagcdn.com/24x18/id.png" title="Indonesian">
  <img src="https://flagcdn.com/24x18/it.png" title="Italian">
  <img src="https://flagcdn.com/24x18/jp.png" title="Japanese">
  <img src="https://flagcdn.com/24x18/kr.png" title="Korean">
  <img src="https://flagcdn.com/24x18/nl.png" title="Dutch">
  <img src="https://flagcdn.com/24x18/no.png" title="Norwegian">
  <img src="https://flagcdn.com/24x18/pl.png" title="Polish">
  <img src="https://flagcdn.com/24x18/pt.png" title="Portuguese">
  <img src="https://flagcdn.com/24x18/br.png" title="Brazilian">
  <img src="https://flagcdn.com/24x18/ro.png" title="Romanian">
  <img src="https://flagcdn.com/24x18/ru.png" title="Russian">
  <img src="https://flagcdn.com/24x18/se.png" title="Swedish">
  <img src="https://flagcdn.com/24x18/th.png" title="Thai">
  <img src="https://flagcdn.com/24x18/tr.png" title="Turkish">
  <img src="https://flagcdn.com/24x18/ua.png" title="Ukrainian">
  <img src="https://flagcdn.com/24x18/vn.png" title="Vietnamese">
  <img src="https://flagcdn.com/24x18/cn.png" title="Chinese CN">
  <img src="https://flagcdn.com/24x18/tw.png" title="Chinese TW">
</p>

## 🙏 Credits

- **zhw1nq** - Author
- [Pisex](https://github.com/Pisex/cs2-faceit-level) - Original idea
- [SwiftlyS2](https://github.com/swiftly-solution/swiftlys2) - Framework
- [FaceIT](https://developers.faceit.com/) - API

## 📄 License

MIT License