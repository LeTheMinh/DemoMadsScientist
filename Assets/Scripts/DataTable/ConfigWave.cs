using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ConfigWaveRecord
{
    //id	random	enemies	number	rate
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
    private bool random;
    public bool Random
    {
        get
        {
            return random;
        }
    }
    [SerializeField]
    private string enemies;//1;2;1
    public List<int> GetEnemies
    {
        get
        {
            List<int> ls = new List<int>();
            string[] s = enemies.Split(';');
            foreach (string e in s)
            {
                ls.Add(int.Parse(e));
            }
            return ls;
        }
    }
    [SerializeField]
    private int number;
    public int Number
    {
        get
        {
            return number;
        }
    }
    [SerializeField]
    private float rate;
    public float Rate
    {
        get
        {
            return rate;
        }
    }
    [SerializeField]
    private float delay;
    public float Delay
    {
        get
        {
            return delay;
        }
    }
}
public class ConfigWave : BYDataTable<ConfigWaveRecord>
{
    public int TotalWave
    {
        get
        {
            return records.Count;
        }
    }
    public override void AddKeySearch()
    {
        recordCompare = new ConfigCompareKey<ConfigWaveRecord>("id");
    }
    public List<ConfigWaveRecord> AllRecord
    {
        get
        {
            return records;
        }
    }

}
