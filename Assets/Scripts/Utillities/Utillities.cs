using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utillities 
{
   public static string ToKey(this object obj)
    {
        return "K_"+ obj.ToString();
    }
    public static int FromKey(this string obj)
    {
        string[] s = obj.Split('_');
        return int.Parse(s[1]);
    }
}
