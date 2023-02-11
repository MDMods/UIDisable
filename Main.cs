using MelonLoader;
using System.IO;
using Tomlet;
using UnityEngine;

namespace UIDisable
{
    public class Main : MelonMod
    {
        private static bool IsGameScene { get; set; }
        private static bool Set { get; set; }

        public override void OnInitializeMelon()
        {
            Save.Load();
            LoggerInstance.Msg("UI Disable Loaded");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName == "GameMain")
            {
                IsGameScene = true;
                Set = false;
            }
            else
            {
                IsGameScene = false;
            }
        }

        public override void OnUpdate()
        {
            if (IsGameScene)
            {
                if (!Save.Settings.ComboEnabled)
                {
                    if (GameObject.Find("Combo"))
                    {
                        GameObject.Find("Combo").SetActive(false);
                    }
                    else if (GameObject.Find("ComboGC"))
                    {
                        GameObject.Find("ComboGC").SetActive(false);
                    }
                    else if (GameObject.Find("Combo_djmax"))
                    {
                        GameObject.Find("Combo_djmax").SetActive(false);
                    }
                }

                if (!Set)
                {
                    if (!Save.Settings.ScoreEnabled)
                    {
                        GameObject.Find("Score").SetActive(false);
                    }
                    if (!Save.Settings.BottomBarEnabled)
                    {
                        GameObject.Find("Below").SetActive(false);
                    }
                    if (!Save.Settings.HitPointEnabled)
                    {
                        GameObject.Find("HitPointRoad").SetActive(false);
                        GameObject.Find("HitPointAir").SetActive(false);
                    }
                    if (!Save.Settings.ComboEnabled)
                    {
                        GameObject.Find("MultiHitComboControl").SetActive(false);
                    }
                    if (!Save.Settings.EffectEnabled)
                    {
                        GameObject.Find("Effects").SetActive(false);
                    }
                    if (!Save.Settings.PauseButtonEnabled)
                    {
                        GameObject.Find("BtnPause").SetActive(false);
                    }
                    Set = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.F9))
            {
                string Datas = File.ReadAllText(Path.Combine("UserData", "UI Disable.cfg"));
                Save.Settings = TomletMain.To<Data>(Datas);
            }
        }
    }
}