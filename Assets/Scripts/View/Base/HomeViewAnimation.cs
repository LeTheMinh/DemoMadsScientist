using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeViewAnimation : BaseViewAnimation
{
    public Animator animator;
    private Action<object> callBack_In;
    private Action callBack_Out;
    public override void OnShowView(Action<object> callBack)
    {
        this.callBack_In = callBack;
        animator.SetTrigger("In");
    }
    public override void OnHideHide(Action callBack)
    {
        this.callBack_Out = callBack;
        animator.SetTrigger("Out");
    }
    public void OnEndInAnim()
    {
        callBack_In?.Invoke(null);
    }
    public void OnEndOutAnim()
    {
        callBack_Out.Invoke();
    }
}
