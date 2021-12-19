using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BaseDialog : MonoBehaviour
{
    public DialogIndex index;
    public BaseDialogAnimation baseDialogAnimation;
    public virtual void OnSetup(DialogParam param)
    {

    }
    public void OnShow(Action<object> callBack)
    {
        baseDialogAnimation.OnShowView((data) =>
        {
            callBack?.Invoke(data);
            OnShowDialog();

        });
    }
    public void OnHide(Action callBack)
    {
        baseDialogAnimation.OnHideHide(() =>
        {
            callBack?.Invoke();
            OnHideDialog();

        });
    }
    public virtual void OnShowDialog()
    {
    }
    public virtual void OnHideDialog()
    {
    }
}
