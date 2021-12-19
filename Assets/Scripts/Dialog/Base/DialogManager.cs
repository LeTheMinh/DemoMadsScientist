using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : Singleton<DialogManager>
{
    public Transform anchorView;
    private Dictionary<DialogIndex, BaseDialog> dicDialog = new Dictionary<DialogIndex, BaseDialog>();
    private List<BaseDialog> dialogShows = new List<BaseDialog>();
    public override void OnAwake()
    {
        base.OnAwake();
        foreach (DialogIndex e in DialogConfig.indices)
        {
            string dialogname = e.ToString();
            GameObject dialogObject = Instantiate(Resources.Load("Dialog/" + dialogname, typeof(GameObject))) as GameObject;
            dialogObject.transform.SetParent(anchorView, false);
            dialogObject.SetActive(false);
            dicDialog.Add(e, dialogObject.GetComponent<BaseDialog>());
        }
       
    }
    public void ShowDialog(DialogIndex index, DialogParam param=null,Action<object> callBack=null)
    {
        BaseDialog dialog = dicDialog[index];
        dialog.gameObject.SetActive(true);
        dialog.OnSetup(param);
        dialog.OnShow(callBack);
        dialogShows.Add(dialog);
    }
    public void HideDialog(DialogIndex index)
    {
        BaseDialog dialog = dicDialog[index];
        dialog.OnHide(()=> {
            dialogShows.Remove(dialog);
            dialog.gameObject.SetActive(false);
        });
    }
    public void HideAllDialog(DialogIndex index)
    {
        foreach(BaseDialog e in dialogShows)
        {
            e.OnHide(null);
            e.gameObject.SetActive(false);
        }
        dialogShows.Clear();
    }
}
