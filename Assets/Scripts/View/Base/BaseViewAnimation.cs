using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;


public class BaseViewAnimation : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup canvasGroup;
    public virtual void OnShowView(Action<object> callBack)
    {
        canvasGroup.DOFade(1, 0.5f).OnComplete(() =>
        {
            callBack?.Invoke(null);

        });
    }
    public virtual void OnHideHide(Action callBack)
    {
        canvasGroup.DOFade(0, 0.25f).OnComplete(() =>
        {
            callBack?.Invoke();


        });
    }

    private void Reset()
    {
        gameObject.name = "BaseViewAnimation";
    }

}
