using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ConfigUtilities 
{

}

public class ConfigCompareKey<T> : RecordCompare<T> where T : class,new ()
{
    FieldInfo fieldInfo;
    public ConfigCompareKey(string fieldname)
    {
        Type type = typeof(T);
        fieldInfo = type.GetField(fieldname, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

    }
    public override T MakeKeySearch(object key)
    {
        T keyobject = new T();
        fieldInfo.SetValue(keyobject, key);
        return keyobject;
    }

    public override int OnRecordCompare(T x, T y)
    {
        object var_1 = fieldInfo.GetValue(x);
        object var_2 = fieldInfo.GetValue(y);
        if (var_1 == null && var_2 == null)
        {
            return  0;
        }
        else if (var_1 != null && var_2 == null)
            return 1;
        else if (var_1 == null && var_2 != null)
            return -1;
        else
        {
            return ((IComparable)var_1).CompareTo(var_2);
        }
    }
}
public class MakeCompare2keyObject<T1, T2>
{
    public T1 key_1;
    public T2 key_2;
}
public class ConfigCompare2Key<T, T1, T2> : RecordCompare<T> where T : class, new()
{
    FieldInfo fieldInfo_1;
    FieldInfo fieldInfo_2;
    public ConfigCompare2Key(string fieldName_1,string fieldName_2)
    {
        Type type = typeof(T);
        fieldInfo_1 = type.GetField(fieldName_1, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        fieldInfo_2 = type.GetField(fieldName_2, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    }
    public override T MakeKeySearch(object key)
    {
        MakeCompare2keyObject<T1, T2> keynew = (MakeCompare2keyObject<T1, T2>)key;
        T keyobject = new T();
        fieldInfo_1.SetValue(keyobject, keynew.key_1);
        fieldInfo_2.SetValue(keyobject, keynew.key_2);
        return keyobject;
    }

    public override int OnRecordCompare(T x, T y)
    {
        object var_1 = fieldInfo_1.GetValue(x);
        object var_2 = fieldInfo_1.GetValue(y);
        int result = ((IComparable)var_1).CompareTo(var_2);
        if(result!=0)
        {
            return result;
        }
        else
        {
            object var_1_key2 = fieldInfo_2.GetValue(x);
            object var_2_key2 = fieldInfo_2.GetValue(y);
            return ((IComparable)var_1_key2).CompareTo(var_2_key2);
        }
    }
}