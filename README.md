# 🎯 FaceIT Scoreboard for SwiftlyS2

[![Source 2](https://img.shields.io/badge/Source%202-orange?style=for-the-badge&logo=valve&logoColor=white)](https://developer.valvesoftware.com/wiki/Source_2)
[![SwiftlyS2](https://img.shields.io/badge/SwiftlyS2-1.0.0-blue?style=for-the-badge)](https://github.com/swiftly-solution/swiftlys2)
[![.NET](https://img.shields.io/badge/.NET-10.0-purple?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-green?style=for-the-badge&logo=csharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)

[![Stars](https://img.shields.io/github/stars/zhw1nq/swiftlyS2-faceit-scoreboard?style=social)](https://github.com/zhw1nq/swiftlyS2-faceit-scoreboard/stargazers)
[![Forks](https://img.shields.io/github/forks/zhw1nq/swiftlyS2-faceit-scoreboard?style=social)](https://github.com/zhw1nq/swiftlyS2-faceit-scoreboard/network/members)
[![Watchers](https://img.shields.io/github/watchers/zhw1nq/swiftlyS2-faceit-scoreboard?style=social)](https://github.com/zhw1nq/swiftlyS2-faceit-scoreboard/watchers)

> **Display FaceIT levels on the scoreboard – know who's carrying at a glance.**

This SwiftlyS2 plugin enhances your CS2 server by displaying FaceIT skill levels directly on the scoreboard using custom coins/medals. Players can toggle FaceIT level display on/off and the plugin efficiently caches data to minimize API calls.

## ✨ Features

- 🏆 **FaceIT Level Display**: Show FaceIT skill levels (1-10) as custom coins on the scoreboard
- ⚡ **Real-time Updates**: Automatically fetch and update player FaceIT levels on connect
- 🔄 **Player Control**: Toggle FaceIT level display on/off with simple commands
- 💾 **Smart Caching**: Efficient caching system to reduce API calls and improve performance
- 🎮 **Multi-game Support**: Supports both FaceIT CS2 and CSGO data fallback
- 🌍 **Multi-language**: 30 languages supported
- ⚙️ **Configurable**: Multiple configuration options for customization
- 💿 **Persistent Data**: Player preferences saved across server restarts

## 🖥️ Tested Platforms

| Platform | Status    |
| -------- | --------- |
| Windows  | ✅ Tested  |
| Linux    | ⏳ Pending |

## 🎨 FaceIT Level Coins

The plugin uses custom coin IDs to represent different FaceIT skill levels:

| Level | Coin ID | Level | Coin ID |
| ----- | ------- | ----- | ------- |
| 1     | 1088    | 6     | 1074    |
| 2     | 1087    | 7     | 1039    |
| 3     | 1032    | 8     | 1067    |
| 4     | 1055    | 9     | 1061    |
| 5     | 1041    | 10    | 1017    |

## 📋 Requirements

- [SwiftlyS2](https://github.com/swiftly-solution/swiftlys2) v1.0.0+
- CS2 Dedicated Server
- [FaceIT API Key](https://developers.faceit.com/)

## 🔧 Installation

1. **Download** the [latest release](https://github.com/zhw1nq/swiftlyS2-faceit-scoreboard/releases)
2. **Extract** to `addons/swiftlys2/plugins/swiftlyS2-faceit-scoreboard/`
3. **Restart** the server
4. **Configure** the config file with your FaceIT API key

## ⚙️ Configuration

The plugin creates a configuration file at:
```
addons/swiftlys2/configs/plugins/swiftlyS2-faceit-scoreboard/config.jsonc
```

### Configuration Options

| Option                    | Type   | Default | Description                                  |
| ------------------------- | ------ | ------- | -------------------------------------------- |
| `ApiKey`                  | string | `""`    | Your FaceIT API key (**Required**)           |
| `UseCSGO`                 | bool   | `false` | Fallback to CSGO data if CS2 not found       |
| `DefaultStatus`           | bool   | `true`  | Default FaceIT level display for new players |
| `EnableToggleCommand`     | bool   | `true`  | Allow players to toggle display on/off       |
| `CacheExpiryHours`        | int    | `24`    | Hours before reloading player data           |
| `MaxConcurrentRequests`   | int    | `3`     | Maximum concurrent API requests              |
| `RequestTimeoutSeconds`   | int    | `8`     | API request timeout                          |
| `AutoSaveIntervalSeconds` | int    | `120`   | Auto-save cache interval                     |

### 🔑 Getting FaceIT API Key

1. Visit [FaceIT Developer Portal](https://developers.faceit.com/)
2. Log in with your FaceIT account
3. Create a new application
4. Copy the API key to your config file

## 🎮 Commands

| Command   | Alias | Description                        |
| --------- | ----- | ---------------------------------- |
| `!faceit` | `!fl` | Toggle FaceIT level display on/off |

## 📁 File Structure

```
addons/swiftlys2/plugins/swiftlyS2-faceit-scoreboard/
├── swiftlyS2-faceit-scoreboard.dll
├── swiftlyS2-faceit-scoreboard.deps.json
└── resources/
    ├── templates/
    │   └── config.template.jsonc
    └── translations/
        ├── en.jsonc
        ├── vn.jsonc
        └── ... (30 languages)
```

## 🌐 Supported Languages

<p align="center">
  <img src="https://flagcdn.com/24x18/sa.png" alt="Arabic" title="Arabic">
  <img src="https://flagcdn.com/24x18/bg.png" alt="Bulgarian" title="Bulgarian">
  <img src="https://flagcdn.com/24x18/cz.png" alt="Czech" title="Czech">
  <img src="https://flagcdn.com/24x18/dk.png" alt="Danish" title="Danish">
  <img src="https://flagcdn.com/24x18/de.png" alt="German" title="German">
  <img src="https://flagcdn.com/24x18/gr.png" alt="Greek" title="Greek">
  <img src="https://flagcdn.com/24x18/gb.png" alt="English" title="English">
  <img src="https://flagcdn.com/24x18/es.png" alt="Spanish" title="Spanish">
  <img src="https://flagcdn.com/24x18/mx.png" alt="Latin America" title="Latin America">
  <img src="https://flagcdn.com/24x18/fi.png" alt="Finnish" title="Finnish">
  <img src="https://flagcdn.com/24x18/fr.png" alt="French" title="French">
  <img src="https://flagcdn.com/24x18/hu.png" alt="Hungarian" title="Hungarian">
  <img src="https://flagcdn.com/24x18/id.png" alt="Indonesian" title="Indonesian">
  <img src="https://flagcdn.com/24x18/it.png" alt="Italian" title="Italian">
  <img src="https://flagcdn.com/24x18/jp.png" alt="Japanese" title="Japanese">
  <img src="https://flagcdn.com/24x18/kr.png" alt="Korean" title="Korean">
  <img src="https://flagcdn.com/24x18/nl.png" alt="Dutch" title="Dutch">
  <img src="https://flagcdn.com/24x18/no.png" alt="Norwegian" title="Norwegian">
  <img src="https://flagcdn.com/24x18/pl.png" alt="Polish" title="Polish">
  <img src="https://flagcdn.com/24x18/pt.png" alt="Portuguese" title="Portuguese">
  <img src="https://flagcdn.com/24x18/br.png" alt="Brazilian" title="Brazilian">
  <img src="https://flagcdn.com/24x18/ro.png" alt="Romanian" title="Romanian">
  <img src="https://flagcdn.com/24x18/ru.png" alt="Russian" title="Russian">
  <img src="https://flagcdn.com/24x18/se.png" alt="Swedish" title="Swedish">
  <img src="https://flagcdn.com/24x18/th.png" alt="Thai" title="Thai">
  <img src="https://flagcdn.com/24x18/tr.png" alt="Turkish" title="Turkish">
  <img src="https://flagcdn.com/24x18/ua.png" alt="Ukrainian" title="Ukrainian">
  <img src="https://flagcdn.com/24x18/vn.png" alt="Vietnamese" title="Vietnamese">
  <img src="https://flagcdn.com/24x18/cn.png" alt="Chinese CN" title="Chinese CN">
  <img src="https://flagcdn.com/24x18/tw.png" alt="Chinese TW" title="Chinese TW">
</p>

## 🐛 Troubleshooting

### Common Issues

1. **FaceIT levels not showing**
   - Check if FaceIT API key is configured correctly
   - Verify player has FaceIT account linked to Steam ID
   - Check server console for API errors

2. **Plugin not loading**
   - Ensure SwiftlyS2 v1.0.0+ is installed
   - Verify file permissions
   - Check for conflicting plugins

3. **Performance issues**
   - Reduce `MaxConcurrentRequests` value
   - Increase `CacheExpiryHours` to reduce API calls

## 🔨 Building from Source

```bash
git clone https://github.com/zhw1nq/swiftlyS2-faceit-scoreboard.git
cd swiftlyS2-faceit-scoreboard
dotnet build
dotnet publish -c Release
```

## 🙏 Credits

- **zhw1nq** - Author
- **Original Idea**: Based on [Pisex's cs2-faceit-level](https://github.com/Pisex/cs2-faceit-level)
- **Framework**: [SwiftlyS2](https://github.com/swiftly-solution/swiftlys2)
- **API**: [FaceIT Data API](https://developers.faceit.com/)

## 💬 Support & Community

- **Discord**: [@vhming_](https://discord.com/users/vhming_)
- **SwiftlyS2 Community**: [Join Discord](https://discord.gg/swiftly)

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

<div align="center">
<i>Made with ❤️ for the CS2 community</i>
</div>