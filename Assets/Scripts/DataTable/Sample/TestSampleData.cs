using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class TestSampleData : MonoBehaviour
{
    public SampleData sampleData;
    // Start is called before the first frame update
    void Start()
    {
        string json = JsonUtility.ToJson(sampleData);
        Debug.LogError("json: " + json);
        // SampleData data = JsonUtility.FromJson<SampleData>(json);
        //  Debug.LogError("data: " + data.record[1].info);
        GetInfoSample<WeaponBehaviour> getInfoSample = new GetInfoSample<WeaponBehaviour>();
        getInfoSample.GetFieldName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class GetInfoSample<T> where T: class
{
   public void GetFieldName()
    {
        Type type = typeof(T);
        FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        foreach(FieldInfo f in fieldInfos)
        {
            Debug.LogError(f.Name);
        }
    }
}