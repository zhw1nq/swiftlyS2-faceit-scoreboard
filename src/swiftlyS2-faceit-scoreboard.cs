using Microsoft.Extensions.DependencyInjection;
using SwiftlyS2.Shared.Plugins;
using SwiftlyS2.Shared;

namespace swiftlyS2_faceit_scoreboard;

[PluginMetadata(Id = "swiftlyS2_faceit_scoreboard", Version = "0.0.1", Name = "SwiftlyS2 FaceIT Scoreboard", Author = "zhw1nq", Description = "Displays FaceIT levels on the scoreboard – know who’s carrying in a blink. [For SwiftlyS2]")]
public partial class swiftlyS2_faceit_scoreboard : BasePlugin {
  public swiftlyS2_faceit_scoreboard(ISwiftlyCore core) : base(core)
  {
  }

  public override void ConfigureSharedInterface(IInterfaceManager interfaceManager) {
  }

  public override void UseSharedInterface(IInterfaceManager interfaceManager) {
  }

  public override void Load(bool hotReload) {
    
  }

  public override void Unload() {
  }
} 