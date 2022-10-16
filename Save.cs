using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomlet;
using Tomlet.Attributes;
using UnityEngine;

namespace UIDisable
{
    internal class Save
    {
        private static Data Default = new Data(true, true, true, true, true, true);
        internal static Data Settings;

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
        [TomlPrecedingComment("Disable Score GameObject or not")]
        internal bool ScoreEnabled;

        [TomlPrecedingComment("Disable Fever bar and HP or not")]
        internal bool BottomBarEnabled;

        [TomlPrecedingComment("Disable HitPoint or not")]
        internal bool HitPointEnabled;

        [TomlPrecedingComment("Disable Combo and hits count or not")]
        internal bool ComboEnabled;

        [TomlPrecedingComment("Disable all hit effects")]
        internal bool EffectEnabled;

        [TomlPrecedingComment("Disable pause button or not(you cannot pause if disable the button)")]
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