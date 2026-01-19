using HarmonyLib;
using MelonLoader;

#region Assemblies
[assembly: MelonInfo(typeof(UniverseLibErrorFix.UniverseLibErrorFix), UniverseLibErrorFix.BuildInfo.ModName, UniverseLibErrorFix.BuildInfo.ModVersion, UniverseLibErrorFix.BuildInfo.Author, UniverseLibErrorFix.BuildInfo.DownloadLink)]

[assembly: MelonColor(255, 0, 160, 230)]
[assembly: MelonAuthorColor(255, 0, 160, 230)]

[assembly: VerifyLoaderVersion(UniverseLibErrorFix.BuildInfo.MLVersion, true)]
#endregion

namespace UniverseLibErrorFix
{
    /// <summary>
    /// Info for UniverseLibErrorFix.
    /// </summary>
    public static class BuildInfo
    {
        /// <summary>
        /// Mod name.
        /// </summary>
        public const string ModName = "UniverseLibErrorFix";
        /// <summary>
        /// Mod version.
        /// </summary>
        public const string ModVersion = "1.0.0";
        /// <summary>
        /// MelonLoader version.
        /// </summary>
        public const string MLVersion = "0.7.1";
        /// <summary>
        /// Mod author.
        /// </summary>
        public const string Author = "ninjaguardian";
        /// <summary>
        /// Mod download link.
        /// </summary>
        public const string DownloadLink = "https://thunderstore.io/c/rumble/p/ninjaguardian/UniverseLibErrorFix";
    }

    /// <summary>
    /// Patches <see cref="UniverseLib.Config.ConfigManager.Disable_AssetBundles_LoadFromMemory"/> to always return true.
    /// </summary>
    public class UniverseLibErrorFix : MelonMod
    {
        [HarmonyPatch(typeof(UniverseLib.Config.ConfigManager), nameof(UniverseLib.Config.ConfigManager.Disable_AssetBundles_LoadFromMemory), MethodType.Getter)]
        private static class Patch
        {
            private static bool Prefix(ref bool __result)
            {
                __result = true;
                return false;
            }
        }
    }
}
