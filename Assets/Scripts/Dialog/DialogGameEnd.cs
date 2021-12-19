using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogGameEnd : BaseDialog
{
    public Text currentScore;
    public Text bestScore;
    public override void OnSetup(DialogParam param)
    {
        DialogGameEndParam data = (DialogGameEndParam)param;
        currentScore.text = "Current Score: <color=#FF6D00>" + data.score.ToString()+"</color>";
        int bestS = DataAPIController.instance.GetBestScore(data.score);
        if(bestS>data.score) 
        {
            bestScore.text = "Best Score: <color=#ffff00ff>" + bestS.ToString() + "</color>";
        }
        else
            bestScore.text = "Best Score: <color=#FF6D00>" + bestS.ToString() + "</color>";
        base.OnSetup(param);
    }
    public override void OnShowDialog()
    {
        Time.timeScale = 0;
    }
    public override void OnHideDialog()
    {
        Time.timeScale = 1;
    }
    public void OnClose()
    {
        DialogManager.instance.HideDialog(DialogIndex.DialogGameEnd);
        LoadSceneManager.instance.LoadSceneByName("Buffer", () => {

            ViewManager.instance.SwitchView(ViewIndex.HomeView);
        });
    }
}
