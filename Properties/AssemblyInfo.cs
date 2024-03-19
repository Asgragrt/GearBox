using System.Reflection;
using MelonLoader;
using static GearBox.Properties.MelonBuildInfo;
using Main = GearBox.Main;

[assembly: MelonInfo(typeof(Main), ModName, ModVersion, ModAuthor)]
[assembly: MelonGame("PeroPeroGames", "MuseDash")]
[assembly: MelonColor(255, 241, 196, 15)]

[assembly: AssemblyTitle(ModName)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Muse Dash Modding Community")]
[assembly: AssemblyProduct(ModName)]
[assembly: AssemblyCopyright("Copyright © 2024")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: AssemblyVersion(ModVersion)]
[assembly: AssemblyFileVersion(ModVersion)]