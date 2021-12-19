using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[Serializable]
public class ConfigTipRecord
{
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
    private string tip;
    public string Tip
    {
        get
        {
            return tip;
        }
    }
}
public class ConfigTip : BYDataTable<ConfigTipRecord>
{
    public override void AddKeySearch()
    {
        recordCompare = new ConfigCompareKey<ConfigTipRecord>("id");
    }
    public ConfigTipRecord GetRandom()
    {
        return records.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
    }
}
