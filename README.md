<div align="center">
  <img src="https://pan.samyyc.dev/s/VYmMXE"/>
  <h1>SwiftlyS2 FaceIT Scoreboard</h1>
  <p>Display FaceIT skill levels on the CS2 scoreboard</p>
</div>

<p align="center">
  <a href="https://developer.valvesoftware.com/wiki/Source_2"><img src="https://img.shields.io/badge/Source%202-orange?style=for-the-badge&logo=valve&logoColor=white" alt="Source 2"></a>
  <a href="https://github.com/zhw1nq/swiftlyS2-faceit-scoreboard/releases"><img src="https://img.shields.io/badge/Version-1.0.0-blue?style=for-the-badge" alt="Version"></a>
  <a href="https://dotnet.microsoft.com/"><img src="https://img.shields.io/badge/.NET-10.0-purple?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET"></a>
</p>

---

## Showcase

<div align="center">
  <img src="Showcase.jpg" alt="Showcase" width="600"/>
</div>

---

## Platform Support

| Platform | Status                                                                                       |
| -------- | -------------------------------------------------------------------------------------------- |
| Windows  | Tested                                                                                       |
| Linux    | Need testers - [Open an issue](https://github.com/zhw1nq/swiftlyS2-faceit-scoreboard/issues) |

## Requirements

- [SwiftlyS2](https://github.com/swiftly-solution/swiftlys2) v1.0.0+
- [FaceIT API Key](https://developers.faceit.com/)

## Installation

1. Download the [latest release](https://github.com/zhw1nq/swiftlyS2-faceit-scoreboard/releases)
2. Extract plugin to `addons/swiftlys2/plugins/swiftlyS2-faceit-scoreboard/`
3. Extract `workshop.zip` to `game/csgo_addons/` (not `content/csgo_addons/`)
4. Restart the server
5. Configure `config.jsonc` with your FaceIT API key

## Configuration

| Option                    | Type   | Default | Description                            |
| ------------------------- | ------ | ------- | -------------------------------------- |
| `ApiKey`                  | string | `""`    | FaceIT API key (Required)              |
| `UseCSGO`                 | bool   | `false` | Fallback to CSGO data if CS2 not found |
| `DefaultStatus`           | bool   | `true`  | Show level by default for new players  |
| `EnableToggleCommand`     | bool   | `true`  | Allow players to toggle display        |
| `CacheExpiryHours`        | int    | `24`    | Hours before refreshing level          |
| `MaxConcurrentRequests`   | int    | `3`     | Max concurrent API requests            |
| `RequestTimeoutSeconds`   | int    | `8`     | API request timeout                    |
| `AutoSaveIntervalSeconds` | int    | `120`   | Auto-save cache interval (0 = disable) |

## Commands

| Command   | Description                 |
| --------- | --------------------------- |
| `!faceit` | Toggle FaceIT level display |
| `!fl`     | Alias for `!faceit`         |

## Supported Languages

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

## Building from Source

### Requirements

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [SwiftlyS2.CS2 NuGet Package](https://www.nuget.org/packages/SwiftlyS2.CS2)

### Build

```bash
git clone https://github.com/zhw1nq/swiftlyS2-faceit-scoreboard.git
cd swiftlyS2-faceit-scoreboard
dotnet restore
dotnet build
```

### Publish

```bash
dotnet publish -c Release
```

Output directory: `build/publish/swiftlyS2-faceit-scoreboard/`

## Credits

- **zhw1nq** - Author
- [Pisex](https://github.com/Pisex/cs2-faceit-level) - Original idea
- [SwiftlyS2](https://github.com/swiftly-solution/swiftlys2) - Framework
- [FaceIT](https://developers.faceit.com/) - API

## License

This project is licensed under the MIT License.
