using System.IO;
using Tomlet;
using Tomlet.Attributes;

namespace UIDisable
{
    internal static class Save
    {
        private static readonly Data Default = new Data(false, true, true, true, true, true, true);
        internal static Data Settings;

        public static void Load()
        {
            if (!File.Exists(Path.Combine("UserData", "UI Disable.cfg")))
            {
                var defaultConfig = TomletMain.TomlStringFrom(Default);
                File.WriteAllText(Path.Combine("UserData", "UI Disable.cfg"), defaultConfig);
            }

            var data = File.ReadAllText(Path.Combine("UserData", "UI Disable.cfg"));
            Settings = TomletMain.To<Data>(data);
        }
    }

    internal struct Data
    {
        [TomlPrecedingComment("Disable UI elements or not")]
        internal bool UIDisabled;

        [TomlPrecedingComment("Enable Score GameObject or not")]
        internal bool ScoreEnabled;

        [TomlPrecedingComment("Enable Fever bar and HP or not")]
        internal bool BottomBarEnabled;

        [TomlPrecedingComment("Enable HitPoint or not")]
        internal bool HitPointEnabled;

        [TomlPrecedingComment("Enable Combo and hits count or not")]
        internal bool ComboEnabled;

        [TomlPrecedingComment("Enable all hit effects")]
        internal bool EffectEnabled;

        [TomlPrecedingComment("Enable pause button or not(you cannot pause if disable the button)")]
        internal bool PauseButtonEnabled;

        internal Data(bool uiDisabled, bool scoreEnabled, bool bottomBarEnabled, bool hitPointEnabled, bool comboEnabled, bool effectEnabled, bool pauseButtonEnabled)
        {
            UIDisabled = uiDisabled;
            ScoreEnabled = scoreEnabled;
            BottomBarEnabled = bottomBarEnabled;
            HitPointEnabled = hitPointEnabled;
            ComboEnabled = comboEnabled;
            EffectEnabled = effectEnabled;
            PauseButtonEnabled = pauseButtonEnabled;
        }
    }
}