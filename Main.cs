using System.IO;
using Assets.Scripts.UI.Panels;
using MelonLoader;
using MuseDashMirror;
using MuseDashMirror.CommonPatches;
using MuseDashMirror.UICreate;
using Tomlet;
using UnityEngine;
using UnityEngine.UI;

namespace UIDisable
{
    internal class Main : MelonMod
    {
        private static GameObject UIDisableToggle;

        public override void OnInitializeMelon()
        {
            Save.Load();
            PatchEvents.PnlMenuEvent += MenuPostfix;
            PatchEvents.MenuSelectEvent += DisableToggle;
            PatchEvents.SwitchLanguagesEvent += SwitchLanguagesPostfix;
            BattleComponent.GameStartEvent += DisableUI;
            LoggerInstance.Msg("UI Disable Loaded");
        }

        public override void OnDeinitializeMelon()
        {
            File.WriteAllText(Path.Combine("UserData", "UI Disable.cfg"), TomletMain.TomlStringFrom(Save.Settings));
        }

        private static void DisableUI()
        {
            if (!Save.Settings.UIDisabled) return;
            var ui_2d = GameObject.Find("UI_2D");
            var sceneObjectController = GameObject.Find("SceneObjectController");
            var pnlBattle = ui_2d.transform.GetChild(0).GetChild(0);
            var pnlCommonUI = pnlBattle.GetChild(0);
            var pnlBattleOthers = pnlBattle.GetChild(1).GetChild(0);
            if (!Save.Settings.ComboEnabled)
            {
                pnlCommonUI.gameObject.SetActive(false);
            }

            if (!Save.Settings.ScoreEnabled)
            {
                pnlBattleOthers.GetChild(5).gameObject.SetActive(false);
            }

            if (!Save.Settings.BottomBarEnabled)
            {
                pnlBattleOthers.GetChild(3).gameObject.SetActive(false);
            }

            if (!Save.Settings.HitPointEnabled)
            {
                sceneObjectController.transform.GetChild(1).gameObject.SetActive(false);
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
                pnlBattleOthers.GetChild(2).gameObject.SetActive(false);
            }
        }

        private static unsafe void MenuPostfix(PnlMenu __instance)
        {
            GameObject vSelect = null;
            foreach (var @object in __instance.transform.parent.parent.Find("Forward"))
            {
                var transform = @object.Cast<Transform>();
                if (transform.name == "PnlVolume")
                {
                    vSelect = transform.gameObject;
                }
            }

            fixed (bool* uiEnabled = &Save.Settings.UIDisabled)
            {
                if (UIDisableToggle == null && vSelect != null)
                {
                    UIDisableToggle = ToggleCreate.CreatePnlMenuToggle("UI Disable Toggle", uiEnabled, "UI Disable On/Off");
                }
            }
        }

        private static void DisableToggle(int listIndex, int index, bool isOn)
        {
            if (listIndex == 0 && index == 0 && isOn)
            {
                UIDisableToggle.SetActive(true);
            }
            else
            {
                UIDisableToggle.SetActive(false);
            }
        }

        private static void SwitchLanguagesPostfix()
        {
            UIDisableToggle.transform.Find("Txt").GetComponent<Text>().text = "UI Disable On/Off";
        }
    }
}