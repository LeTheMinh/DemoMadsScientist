using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ShowInfo(string mess);
public delegate string ShowInfoMess(string mess);
public class DelegateSample : MonoBehaviour
{
    public event ShowInfo onShowInfo;
    // Start is called before the first frame update
    void Start()
    {
        onShowInfo += OnShowInfoEventhandle;
        onShowInfo += OnShowInfoEventhandle1;
        //ShowInfo(ShowInfoDelegate);

        //ShowInfoLamda(x => {
        //    Debug.LogError(x);
        //});
        //ShowInfoLamda(ShowInfoDelegateLamda);
    }

    private void OnShowInfoEventhandle(string mess)
    {
        Debug.LogError(mess);
    }
    private void OnShowInfoEventhandle1(string mess)
    {
        Debug.LogError("1: "+mess);
    }
    // callback
    private void ShowInfo(ShowInfoMess callback)
    {
        string mess = "helo co ba";
        //1
        if (callback != null)
            callback(mess);
        // 2
        string s= callback?.Invoke(mess);
        Debug.LogError("result: " + s);
    }
    string ShowInfoDelegate(string mess)
    {
        string s = " mess delegate " + mess;
        Debug.LogError(" mess delegate " + mess);
        return s;
    }
    private void ShowInfoLamda(ShowInfo callback)
    {
        string mess = "helo co ba";
         callback?.Invoke(mess);
    }
    void ShowInfoDelegateLamda(string mess)
    {
        Debug.LogError(" mess delegate " + mess);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            onShowInfo?.Invoke("helo world");
    }
}
