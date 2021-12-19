using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public delegate void OnTouch(bool istouch, Vector2 point);
public class InputManager : Singleton<InputManager>
{
    public static UnityEvent<bool ,Vector2> onTouchHandle=new UnityEvent<bool, Vector2>();
    public static UnityEvent  OnEventChangeGun=new UnityEvent();

    private void OnDisable()
    {
        onTouchHandle.RemoveAllListeners();
        OnEventChangeGun.RemoveAllListeners();
    }


    //  public static event OnTouch onTouchHandle;
    // Start is called before the first frame update

    public void OnTouchScreen(bool istouch, Vector2 point)
    {
        if (istouch)
        {
            onTouchHandle?.Invoke(true,point);
        }
        else 
        {
            onTouchHandle?.Invoke(false,point);
        }
        

    }
    public void OnChangeGun()
    {
        OnEventChangeGun?.Invoke();
    }
    // Update is called once per frame

}
