using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_B_Behaviour : S_Behaviour
{
    public override void Setup()
    {
        iText = new I_SB_Interface();
    }
}

public class I_SB_Interface : S_Interface
{
    public void ShowInfo(string mess)
    {
        string s = mess.ToLower();
        Debug.LogError(s);
    }
}