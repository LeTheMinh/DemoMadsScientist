using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class LoadSceneManager : Singleton<LoadSceneManager>
{
    public GameObject uiObject;
    public Image loadingProgressImage;
    public Text progressLB;
    public Text tipLB;
    public void LoadSceneByName(string nameScene, Action callBack)
    {
        StopAllCoroutines();
        StartCoroutine(LoadSceneByNameProgress(nameScene, callBack));
    }
    IEnumerator LoadSceneByNameProgress(string nameScene, Action callBack)
    {
        uiObject.SetActive(true);
        ConfigTipRecord cf = ConfigManager.instance.configTip.GetRandom();
        tipLB.text = cf.Tip;
        AsyncOperation async = SceneManager.LoadSceneAsync(nameScene, LoadSceneMode.Single);
        progressLB.text =  "10%";
        loadingProgressImage.fillAmount = 0.1f;
        yield return new WaitUntil(() => async.isDone);
        // The shortcuts way
        float amout = 0.1f;
        DOTween.To(() => amout, x => amout = x, 1, 2).OnUpdate(() =>
        {
            progressLB.text = (Mathf.RoundToInt(amout * 100)).ToString() + "%";
            loadingProgressImage.fillAmount = amout;
        }).OnComplete(()=> {
            callBack?.Invoke();
            uiObject.SetActive(false);
        });
    }
    public void LoadSceneByIndex(int index, Action callBack)
    {
        StopAllCoroutines();
        StartCoroutine(LoadSceneByIndexProgress(index, callBack));
    }
    IEnumerator LoadSceneByIndexProgress(int index, Action callBack)
    {
        uiObject.SetActive(true);
        ConfigTipRecord cf = ConfigManager.instance.configTip.GetRandom();
        tipLB.text = cf.Tip;
        AsyncOperation async = SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
        progressLB.text = "10%";
        loadingProgressImage.fillAmount = 0.1f;
        yield return new WaitUntil(() => async.isDone);
        // The shortcuts way
        float amout = 0.1f;
        DOTween.To(() => amout, x => amout = x, 1, 2).OnUpdate(() =>
        {
            progressLB.text = (Mathf.RoundToInt(amout * 100)).ToString() + "%";
            loadingProgressImage.fillAmount = amout;
        }).OnComplete(() => {
            callBack?.Invoke();
            uiObject.SetActive(false);
        });
    }
}
