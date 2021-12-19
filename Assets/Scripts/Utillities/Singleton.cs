using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T>:MonoBehaviour where T: MonoBehaviour
{
    public static T instance;
  
    // Start is called before the first frame update
    void Awake()
    {
        instance = gameObject.GetComponent<T>();
        OnAwake();
    }
    private void Reset()
    {
        gameObject.name = typeof(T).ToString();
    }
    public virtual void OnAwake()
    {

    }
}
