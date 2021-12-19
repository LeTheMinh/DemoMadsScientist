using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ConfigShopRecord
{
    //id	icon	icon_Value	value	cost_dollar	cost_potion
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
    private string icon;
    public string Icon
    {
        get
        {
            return icon;
        }
    }
    [SerializeField]
    private string icon_Value;
    public string Icon_Value
    {
        get
        {
            return icon_Value;
        }
    }
    [SerializeField]
    private int value;
    public int Value
    {
        get
        {
            return value;
        }
    }
    [SerializeField]
    private float cost_dollar;
    public float Cost_dollar
    {
        get
        {
            return cost_dollar;
        }
    }
    [SerializeField]
    private int cost_potion;
    public int Cost_potion
    {
        get
        {
            return cost_potion;
        }
    }
}
public class ConfigShop : BYDataTable<ConfigShopRecord>
{
    public override void AddKeySearch()
    {
        recordCompare = new ConfigCompareKey<ConfigShopRecord>("id");
    }
    public List<ConfigShopRecord> GetAll()
    {
        return records;
    }
}
