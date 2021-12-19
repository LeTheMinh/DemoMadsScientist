using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : Singleton<ViewManager>
{
    public Transform anchorView;
    private Dictionary<ViewIndex, BaseView> dicView = new Dictionary<ViewIndex, BaseView>();
    private BaseView currentView;
    public override void OnAwake()
    {
        base.OnAwake();
        foreach (ViewIndex e in ViewConfig.viewIndices)
        {
            string viewName = e.ToString();
            GameObject viewObject = Instantiate(Resources.Load("View/" + viewName, typeof(GameObject))) as GameObject;
            viewObject.transform.SetParent(anchorView, false);
            viewObject.SetActive(false);
            dicView.Add(e, viewObject.GetComponent<BaseView>());
        }
        SwitchView(ViewIndex.EmptyView, null, null);
    }
    public void SwitchView(ViewIndex viewIndex,ViewParam param=null,Action<object> callBack=null)
    {
       
        if(currentView!=null)
        {
            Debug.LogError(viewIndex.ToString());

            currentView.OnHide(()=> {

                currentView.gameObject.SetActive(false);
                currentView = dicView[viewIndex];
                currentView.gameObject.SetActive(true);
                currentView.OnSetup(param);
                currentView.OnShow((data) =>
                {

                    callBack?.Invoke(data);
                });
            });
        }
        else
        {
            currentView = dicView[viewIndex];
            currentView.gameObject.SetActive(true);
            currentView.OnSetup(param);
            currentView.OnShow((data) =>
            {

                callBack?.Invoke(data);
            });
        }
    }
}
