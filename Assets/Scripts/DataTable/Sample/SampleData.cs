using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SampleData", menuName = "ScriptableObjects/SampleData", order = 1)]
public class SampleData : ScriptableObject
{
    public List<SampleDataItem> record;

}
[Serializable]
public class SampleDataItem
{
    public string info;
    public int age;
}