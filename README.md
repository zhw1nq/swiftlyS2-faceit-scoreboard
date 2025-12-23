<div align="center">
  <img src="https://pan.samyyc.dev/s/VYmMXE" width="100" />
  <h1>SwiftlyS2 FaceIT Scoreboard</h1>
  <p>Display FaceIT skill levels on the CS2 scoreboard</p>
</div>

<p align="center">
  <a href="#"><img src="https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET"></a>
  <a href="#"><img src="https://img.shields.io/badge/SwiftlyS2-1.0.0-0078D4?style=for-the-badge" alt="SwiftlyS2"></a>
  <a href="#"><img src="https://img.shields.io/badge/CS2-Plugin-F7931A?style=for-the-badge&logo=steam&logoColor=white" alt="CS2"></a>
</p>

<p align="center">
  <a href="https://github.com/zhw1nq/swiftlyS2-faceit-scoreboard/releases"><img src="https://img.shields.io/github/v/release/zhw1nq/swiftlyS2-faceit-scoreboard?style=flat-square" alt="Release"></a>
  <a href="https://github.com/zhw1nq/swiftlyS2-faceit-scoreboard/blob/main/LICENSE"><img src="https://img.shields.io/github/license/zhw1nq/swiftlyS2-faceit-scoreboard?style=flat-square" alt="License"></a>
  <a href="#"><img src="https://img.shields.io/badge/languages-30-success?style=flat-square" alt="Languages"></a>
</p>

---

## Features

- Auto-detect FaceIT levels on player connect
- Display skill level as scoreboard medal
- Toggle command for players (`/faceit`, `/fl`)
- Persistent cache with configurable expiry
- Multi-language support (30 languages)
- Optimized with connection pooling & rate limiting

## Requirements

- [SwiftlyS2](https://github.com/swiftly-solution/swiftlys2) v1.0.0+
- [FaceIT API Key](https://developers.faceit.com/)

## Installation

1. Download the [latest release](https://github.com/zhw1nq/swiftlyS2-faceit-scoreboard/releases)
2. Extract to `addons/swiftlys2/plugins/swiftlyS2-faceit-scoreboard/`
3. Restart server
4. Configure `config.jsonc` with your API key

## Configuration

| Option                    | Type   | Default | Description                             |
| ------------------------- | ------ | ------- | --------------------------------------- |
| `ApiKey`                  | string | `""`    | FaceIT Data API key (required)          |
| `UseCSGO`                 | bool   | `false` | Fallback to CSGO stats if CS2 not found |
| `DefaultStatus`           | bool   | `true`  | Show level by default for new players   |
| `EnableToggleCommand`     | bool   | `true`  | Allow players to toggle display         |
| `CacheExpiryHours`        | int    | `24`    | Hours before re-fetching level          |
| `MaxConcurrentRequests`   | int    | `3`     | Maximum concurrent API requests         |
| `RequestTimeoutSeconds`   | int    | `8`     | API request timeout                     |
| `AutoSaveIntervalSeconds` | int    | `120`   | Cache auto-save interval                |

## Commands

| Command   | Description                        |
| --------- | ---------------------------------- |
| `!faceit` | Toggle FaceIT level display on/off |
| `!fl`     | Alias for `!faceit`                |

## Supported Languages

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

## Building from Source

```bash
git clone https://github.com/zhw1nq/swiftlyS2-faceit-scoreboard.git
cd swiftlyS2-faceit-scoreboard
dotnet build
```

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Credits

- **zhw1nq** - Author
- [SwiftlyS2](https://github.com/swiftly-solution/swiftlys2) - Plugin framework
- [FaceIT](https://developers.faceit.com/) - Data API