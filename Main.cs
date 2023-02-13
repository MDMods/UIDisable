using MelonLoader;
using MuseDashMirror;
using UnityEngine;

namespace UIDisable
{
    public class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            Save.Load();
            BattleComponent.GameStartEvent += DisableUI;
            LoggerInstance.Msg("UI Disable Loaded");
        }

        private void DisableUI()
        {
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
    }
}