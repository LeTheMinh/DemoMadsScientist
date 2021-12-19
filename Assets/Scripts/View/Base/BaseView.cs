using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseView : MonoBehaviour
{
    public ViewIndex viewIndex;
    public BaseViewAnimation baseViewAnimation;
    public virtual void OnSetup(ViewParam param)
    {

    }
    public  void OnShow( Action<object> callBack)
    {
        baseViewAnimation.OnShowView((data) =>
        {
            callBack?.Invoke(data);
            OnShowView();

        });
    }
    public  void OnHide(Action callBack)
    {
        baseViewAnimation.OnHideHide(() =>
        {
            callBack?.Invoke();
            OnHideView();

        });
    }
    public virtual void OnShowView()
    {
    }
    public virtual void OnHideView()
    {
    }

}
