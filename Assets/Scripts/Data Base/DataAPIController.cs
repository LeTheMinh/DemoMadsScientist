using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class DataAPIController : Singleton<DataAPIController>
{
    [SerializeField]
    private DataBaseModel model;
    // Start is called before the first frame update
    public void InitData(Action callBack)
    {
        model.CreateData(callBack);
    }
    public int GetPotion()
    {
        return model.ReadData<int>(DataPath.POTION);
    }
    public void UpdatePotion(int potion)
    {
        int potion_ = GetPotion();
        potion_ += potion;
        if (potion_ < 0)
            potion_ = 0;
        model.UpdateData(DataPath.POTION, potion_);
    }
    public string GetNameHero()
    {
        return model.ReadData<string>(DataPath.NAME);
    }
    public GunData GetGunDataById(int gunID)
    {
        return model.ReadDictionary<GunData>(DataPath.GUNS, gunID.ToKey());
    }
    public void UnlockGun(int gunID)
    {
        MakeCompare2keyObject<int, int> objKey = new MakeCompare2keyObject<int, int>();
        objKey.key_1 = gunID;
        objKey.key_2 = 1;
        ConfigWeaponLevelRecord configWeaponLevel = ConfigManager.instance.configWeaponLevel.GetRecordByKeySearch(objKey);
        int potion = GetPotion();
        if(potion>=configWeaponLevel.Cost)
        {
            UpdatePotion(-configWeaponLevel.Cost);
            GunData gunData = new GunData();
            gunData.idGun = gunID;
            gunData.level = 1;
            model.UpdateDictionary<GunData>(DataPath.GUNS, gunID.ToKey(), gunData);
        }
        
    }
    public void UpgradeGun(int gunID)
    {
        GunData gundata=GetGunDataById(gunID);
        
        MakeCompare2keyObject<int, int> objKey = new MakeCompare2keyObject<int, int>();
        objKey.key_1 = gunID;
        objKey.key_2 = gundata.level+1;
        ConfigWeaponLevelRecord configWeaponLevel = ConfigManager.instance.configWeaponLevel.GetRecordByKeySearch(objKey);
        //check max level
        if(configWeaponLevel!=null)
        {
            
            int potion = GetPotion();
         
            if (potion >= configWeaponLevel.Cost)
            {
                

                UpdatePotion(-configWeaponLevel.Cost);
                gundata.level++;
                model.UpdateDictionary<GunData>(DataPath.GUNS, gunID.ToKey(), gundata);
            }
        }
        else
        {
            Debug.LogError(gundata.idGun +"null");
        }
       
    }
    public PlayerInfo GetPlayerInfo()
    {
        return model.ReadData<PlayerInfo>(DataPath.INFO);
    }
    public void SetGunEquip(int idGun,int slot)
    {
        /* set all
        PlayerInfo playerInfo = GetPlayerInfo();
        if (slot ==1)
        {
            playerInfo.id_Gun1 = idGun;
        }
        else
        {
            playerInfo.id_Gun2 = idGun;
        }
        model.UpdateData(DataPath.INFO, playerInfo);
        */
        if (slot == 1)
        {
            model.UpdateData(DataPath.GUN_1, idGun);
        }
        else
        {
            model.UpdateData(DataPath.GUN_2, idGun);
        }
    }
    public void OnChangeGunIngame()
    {
        PlayerInfo playerInfo = GetPlayerInfo();
        int id_1 = playerInfo.id_Gun2;
        int id_2 = playerInfo.id_Gun1;
        playerInfo.id_Gun1 = id_1;
        playerInfo.id_Gun2 = id_2;
        model.UpdateData(DataPath.INFO, playerInfo);
        

    }
    public int GetBestScore(int currentScore)
    {
        int bestScore = model.ReadData<int>(DataPath.BESTSCORE);
        if (bestScore < currentScore)
        {
            bestScore = currentScore;
            model.UpdateData(DataPath.BESTSCORE, bestScore);
        }
        return bestScore;
    }
    public void BuyPotion(ConfigShopRecord cf)
    {
        UpdatePotion(cf.Value);
    }
}
