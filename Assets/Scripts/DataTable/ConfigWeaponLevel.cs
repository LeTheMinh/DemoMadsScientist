using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ConfigWeaponLevelRecord
{
    //idGun	level	rof	damage	reload	clipSize
    [SerializeField]
    private int idGun;
    public int IDGun
    {
        get
        {
            return idGun;
        }
    }
    [SerializeField]
    private int level;
    public int Level
    {
        get
        {
            return level;
        }
    }
    [SerializeField]
    private float rof;
    public float Rof
    {
        get
        {
            return rof;
        }
    }
    [SerializeField]
    private int damage;
    public int Damage
    {
        get
        {
            return damage;
        }
    }
    [SerializeField]
    private float reload;
    public float Reload
    {
        get
        {
            return reload;
        }
    }
    [SerializeField]
    private int clipSize;
    public int ClipSize
    {
        get
        {
            return clipSize;
        }
    }
    [SerializeField]
    private int hp;
    public int HP
    {
        get
        {
            return hp;
        }
    }
    [SerializeField]
    private int cost;
    public int Cost
    {
        get
        {
            return cost;
        }
    }
}                                                                                                                                       
public class ConfigWeaponLevel : BYDataTable<ConfigWeaponLevelRecord>
{
    public override void AddKeySearch()
    {
        recordCompare = new ConfigCompare2Key<ConfigWeaponLevelRecord, int, int>("idGun", "level");
    }

   
}
