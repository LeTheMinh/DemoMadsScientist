using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class ConfigEnemyRecord
{
    //
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
    private string prefab;
    public string Prefab
    {
        get
        {
            return prefab;
        }
    }
}
public class ConfigEnemy : BYDataTable<ConfigEnemyRecord>
{
    public override void AddKeySearch()
    {
        recordCompare = new ConfigCompareKey<ConfigEnemyRecord>("id");
    }

   
}
