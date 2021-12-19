using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class BaseDialogAnimation : MonoBehaviour
{
    private RectTransform rectTransform_;
    private void Awake()
    {
        rectTransform_ = GetComponent<RectTransform>();
    }
    public virtual void OnShowView(Action<object> callBack)
    {
        rectTransform_.DOScale(Vector3.one, 0.25f).OnComplete(() =>
        {
            callBack?.Invoke(null);

        }).SetEase(Ease.OutQuad).SetUpdate(true);
    }
    public virtual void OnHideHide(Action callBack)
    {
        rectTransform_.DOScale(Vector3.zero, 0.2f).OnComplete(() =>
        {
            callBack?.Invoke();

        }).SetUpdate(true);
    }

    private void Reset()
    {
        gameObject.name = "BaseDialogAnimation";
    }
}
