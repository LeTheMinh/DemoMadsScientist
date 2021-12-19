using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_A_Behaviour : S_Behaviour
{
    public override void Setup()
    {
        iText = new I_SA_Interface();
    }
}

public class I_SA_Interface : S_Interface
{
    public void ShowInfo(string mess)
    {
        string s = mess.ToUpper();
        Debug.LogError(s);
    }
}