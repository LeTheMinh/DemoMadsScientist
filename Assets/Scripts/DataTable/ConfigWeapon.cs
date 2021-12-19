using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ConfigWeaponRecord
{
    //id	name	prefab
    [SerializeField]
    private int id;
    public int ID
    {
        get
        {
            return id;
        }
    }
 
    [SerializeField]
    private string name;
    public string Name
    {
        get
        {
            return name;
        }
    }

    [SerializeField]
    private string prefab;
    public string Prefab
    {
        get
        {
            return prefab;
        }
    }
}
public class ConfigWeapon : BYDataTable<ConfigWeaponRecord>
{
    public override void AddKeySearch()
    {
        recordCompare = new ConfigCompareKey<ConfigWeaponRecord>("id");
    }
    public List<ConfigWeaponRecord> AllRecord
    {
        get
        {
            return records;
        }
    }
}
