using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class S_Behaviour : MonoBehaviour
{
    public S_Interface iText;
    private void Start()
    {
        Setup();
    }
    public virtual void Setup()
    {

    }
    public void Show()
    {
            iText.ShowInfo("Hello World");
    }

}
