using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPause : BaseDialog
{
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
        DialogManager.instance.HideDialog(DialogIndex.DialogPause);
        
    }
    public void OnQuit()
    {
        DialogManager.instance.HideDialog(DialogIndex.DialogPause);
        LoadSceneManager.instance.LoadSceneByName("Buffer", () => {

            ViewManager.instance.SwitchView(ViewIndex.HomeView);
        });
    }
}
