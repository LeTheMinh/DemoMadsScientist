using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ConfigEnemyLevelRecord
{
    //
    [SerializeField]
    private int idEnemy;
    public int IDEnemy
    {
        get
        {
            return idEnemy;
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
    private int damage;
    public int Damage
    {
        get
        {
            return damage;
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
    private int score;
    public int Score
    {
        get
        {
            return score;
        }
    }
}
public class ConfigEnemyLevel : BYDataTable<ConfigEnemyLevelRecord>
{
    public override void AddKeySearch()
    {
        recordCompare = new ConfigCompare2Key<ConfigEnemyLevelRecord, int, int>("idEnemy", "level");
    }



}
