using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerData
{
    [SerializeField]
    public PlayerInfo info;
    [SerializeField]
    public PlayerInventory inventory;
}
[Serializable]
public class PlayerInfo
{
    public string name;
    public int exp;
    public int level;
    public int bestScore;
    public int id_Gun1;
    public int id_Gun2;
}
[Serializable]
public class PlayerInventory
{
    public int potion;
    [SerializeField]
    public Dictionary<string, GunData> dicGun = new Dictionary<string, GunData>();
}
[Serializable]
public class GunData
{
    public int idGun;
    public int level;
}