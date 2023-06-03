using System.IO;
using Tomlet;
using Tomlet.Attributes;

namespace UIDisable
{
    internal static class Save
    {
        internal static Data Settings;

        public static void Load()
        {
            if (!File.Exists(Path.Combine("UserData", "UI Disable.cfg")))
            {
                var defaultConfig = TomletMain.TomlStringFrom(new Data());
                File.WriteAllText(Path.Combine("UserData", "UI Disable.cfg"), defaultConfig);
            }

            var data = File.ReadAllText(Path.Combine("UserData", "UI Disable.cfg"));
            Settings = TomletMain.To<Data>(data);
        }
    }

    public class Data
    {
        [TomlPrecedingComment("Disable UI elements or not")]
        internal bool UIDisabled = false;

        [TomlPrecedingComment("Enable Score GameObject or not")]
        internal bool ScoreEnabled { get; set; } = true;

        [TomlPrecedingComment("Enable Fever bar and HP or not")]
        internal bool BottomBarEnabled { get; set; } = true;

        [TomlPrecedingComment("Enable HitPoint or not")]
        internal bool HitPointEnabled { get; set; } = true;

        [TomlPrecedingComment("Enable Combo and hits count or not")]
        internal bool ComboEnabled { get; set; } = true;

        [TomlPrecedingComment("Enable all hit effects")]

        internal bool EffectEnabled { get; set; } = true;

        [TomlPrecedingComment("Enable pause button or not(you cannot pause if disable the button)")]
        internal bool PauseButtonEnabled { get; set; } = true;
    }
}