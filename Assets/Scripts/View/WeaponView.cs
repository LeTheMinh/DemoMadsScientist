using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponView : BaseView
{
    public WeaponViewItem prefabItem;
    private WeaponViewItem currentItem;
    public Transform parentItem;
    private List<WeaponViewItem> lsItem = new List<WeaponViewItem>();
    private Dictionary<int, GameObject> dicModel = new Dictionary<int, GameObject>();
    private GameObject currentModel;
    public Text levelLB;
    public Text damageLB;
    public Text hpLB;
    public Text speedLB;
    public Text costLB;
    public Text potionLB;
    public Text slotLB;
    public Button btnUnlock;
    public Button btnUpgrade;
    public GameObject potionObject;
    public GameObject maxLevel;
    public GameObject btnEquip;
    public Transform parentModel;
    private int potion;
    private PlayerInfo info;
    // Start is called before the first frame update
    public override void OnSetup(ViewParam param)
    {
        info = DataAPIController.instance.GetPlayerInfo();

        potion = DataAPIController.instance.GetPotion();
        potionLB.text = potion.ToString();
        List<ConfigWeaponRecord> cfWeapons = ConfigManager.instance.configWeapon.AllRecord;
        if (lsItem.Count <= 0)
        {
            for (int i = 0; i < cfWeapons.Count; i++)
            {
                WeaponViewItem item = Instantiate(prefabItem);
                item.transform.SetParent(parentItem, false);
                lsItem.Add(item);
            }
        }
        // set data for items
        for (int i = 0; i < cfWeapons.Count; i++)
        {
            lsItem[i].Setup(cfWeapons[i], this);
        }
        lsItem[0].OnSelectItem();
        
    }
   
    public override void OnShowView()
    {
        DataTrigger.RegisterValuachange(DataPath.POTION, OnPotionChange);
        DataTrigger.RegisterValuachange(DataPath.INFO, OnInfoChange);
    }

    public override void OnHideView()
    {
        DataTrigger.UnRegisterValuachange(DataPath.POTION, OnPotionChange);
        DataTrigger.UnRegisterValuachange(DataPath.INFO, OnInfoChange);
    }
    private void OnPotionChange(object dataChange)
    {
        potion = (int)dataChange;
        potionLB.text = potion.ToString();
    }
    private void OnInfoChange(object dataChange)
    {
        info = (PlayerInfo)dataChange;
        SetGunEquip();
    }
    private void OnGunChange(object dataChange)
    {
        GunData gunData = (GunData)dataChange;

        SetInfoByGunData(gunData);
    }
    public void OnItemSelect(WeaponViewItem item)
    {
       
        
        if(currentItem!=null)
        {
            currentItem.OnDeSelectItem();
            DataTrigger.UnRegisterValuachange(DataPath.GUNS + "/" + currentItem.configWeapon.ID.ToKey(), OnGunChange);
        }
        currentItem = item;
        DataTrigger.RegisterValuachange(DataPath.GUNS + "/" + currentItem.configWeapon.ID.ToKey(), OnGunChange);
        GunData gunData = DataAPIController.instance.GetGunDataById(currentItem.configWeapon.ID);

        SetInfoByGunData(gunData);

        currentModel?.SetActive(false);

        if (dicModel.ContainsKey(currentItem.configWeapon.ID))
        {
            currentModel = dicModel[currentItem.configWeapon.ID];
        }
        else
        {
            GameObject objModel = Instantiate(Resources.Load("Weapon UI/" + currentItem.configWeapon.Prefab,
                typeof(GameObject))) as GameObject;
            objModel.transform.SetParent(parentModel, false);
            dicModel.Add(currentItem.configWeapon.ID, objModel);
            currentModel = objModel;
        }
        currentModel.SetActive(true);

        
    }
    private void SetInfoByGunData(GunData gunData)
    {
        btnUnlock.gameObject.SetActive(false);
        btnUpgrade.gameObject.SetActive(false);
        maxLevel.SetActive(false);
        potionObject.SetActive(false);
        string damageNext = string.Empty;
        string speedNext = string.Empty;
        string hpNext = string.Empty;
        MakeCompare2keyObject<int, int> objKey = new MakeCompare2keyObject<int, int>();
        objKey.key_1 = currentItem.configWeapon.ID;
        if (gunData != null)
        {
            objKey.key_2 = gunData.level + 1;
            ConfigWeaponLevelRecord configWeaponLevelNext = ConfigManager.instance.configWeaponLevel.GetRecordByKeySearch(objKey);
            if (configWeaponLevelNext != null)
            {
                btnUpgrade.gameObject.SetActive(true);
                potionObject.SetActive(true);
                costLB.text = configWeaponLevelNext.Cost.ToString();
                damageNext = "<color=#FF6D00> +" + configWeaponLevelNext.Damage.ToString()+"</color>";
                speedNext = "<color=#FF6D00> +" + configWeaponLevelNext.Rof.ToString() + "</color>";
                hpNext = "<color=#FF6D00> +" + configWeaponLevelNext.HP.ToString() + "</color>";
                if (potion <= configWeaponLevelNext.Cost)
                {
                    btnUnlock.interactable = false;
                    btnUpgrade.interactable = false;
                }
                else
                {
                    btnUnlock.interactable = true;
                    btnUpgrade.interactable = true;
                }
            }
            else
            {
                maxLevel.SetActive(true);
                potionObject.SetActive(false);
            }
            objKey.key_2 = gunData.level;
        }
        else
        {
            objKey.key_2 = 1;

            potionObject.SetActive(true);
            ConfigWeaponLevelRecord configWeaponLevel_ = ConfigManager.instance.configWeaponLevel.GetRecordByKeySearch(objKey);
            btnUnlock.gameObject.SetActive(true);
        }

        ConfigWeaponLevelRecord configWeaponLevel = ConfigManager.instance.configWeaponLevel.GetRecordByKeySearch(objKey);
        
        // set data left info
        levelLB.text = "Level " + configWeaponLevel.Level.ToString();
        damageLB.text = configWeaponLevel.Damage.ToString()+ damageNext;
        hpLB.text = configWeaponLevel.HP.ToString()+hpNext;
        speedLB.text = configWeaponLevel.Rof.ToString()+speedNext;

        SetGunEquip();
    }
    private void SetGunEquip()
    {
        btnEquip.SetActive(false);
      
        if (currentItem.configWeapon.ID == info.id_Gun1)
        {
            slotLB.text = "Slot 1";
        }
        else if (currentItem.configWeapon.ID == info.id_Gun2)
        {

            slotLB.text = "Slot 2";
        }
        else
        {
            slotLB.text = string.Empty;
            if (!btnUnlock.gameObject.activeSelf)
                btnEquip.SetActive(true);
        }
    }
    public void OnBack()
    {
        ViewManager.instance.SwitchView(ViewIndex.HomeView);
    }
    public void UnLockGun()
    {
        DataAPIController.instance.UnlockGun(currentItem.configWeapon.ID);

    }
    public void UpgradeGun()
    {

        DataAPIController.instance.UpgradeGun(currentItem.configWeapon.ID);
    }
    public void OnEquipGun()
    {
        DialogEquipParam equipParam = new DialogEquipParam();
        equipParam.idGun = currentItem.configWeapon.ID;
        DialogManager.instance.ShowDialog(DialogIndex.DialogEquip, equipParam);
    }
}
