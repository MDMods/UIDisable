using System.IO;
using Tomlet;
using Tomlet.Attributes;

namespace UIDisable
{
    internal static class Save
    {
        private static Data Default = new Data(true, true, true, true, true, true);
        internal static Data Settings { get; set; }

        public static void Load()
        {
            if (!File.Exists(Path.Combine("UserData", "UI Disable.cfg")))
            {
                string defaultConfig = TomletMain.TomlStringFrom(Default);
                File.WriteAllText(Path.Combine("UserData", "UI Disable.cfg"), defaultConfig);
            }
            string Datas = File.ReadAllText(Path.Combine("UserData", "UI Disable.cfg"));
            Settings = TomletMain.To<Data>(Datas);
        }
    }

    internal struct Data
    {
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

        internal Data(bool scoreEnabled, bool bottomBarEnabled, bool hitPointEnabled, bool comboEnabled, bool effectEnabled, bool pauseButtonEnabled)
        {
            ScoreEnabled = scoreEnabled;
            BottomBarEnabled = bottomBarEnabled;
            HitPointEnabled = hitPointEnabled;
            ComboEnabled = comboEnabled;
            EffectEnabled = effectEnabled;
            PauseButtonEnabled = pauseButtonEnabled;
        }
    }
}