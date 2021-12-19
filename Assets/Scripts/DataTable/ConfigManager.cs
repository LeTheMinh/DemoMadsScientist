using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : Singleton<ConfigManager>
{
    private ConfigItem configItem_;
    public ConfigItem configItem
    {
        get
        {
            return configItem_;
        }
    }
    private ConfigDefault configDefault_;
    public ConfigDefault configDefault
    {
        get
        {
            return configDefault_;
        }
    }
    private ConfigWeapon configWeapon_;
    public ConfigWeapon configWeapon
    {
        get
        {
            return configWeapon_;
        }
    }
    private ConfigWeaponLevel configWeaponLevel_;
    public ConfigWeaponLevel configWeaponLevel
    {
        get
        {
            return configWeaponLevel_;
        }
    }
    private ConfigWave configWave_;
    public ConfigWave configWave
    {
        get
        {
            return configWave_;
        }
    }
    private ConfigEnemy configEnemy_;
    public ConfigEnemy configEnemy
    {
        get
        {
            return configEnemy_;
        }
    }
    private ConfigEnemyLevel configEnemyLevel_;
    public ConfigEnemyLevel configEnemyLevel
    {
        get
        {
            return configEnemyLevel_;
        }
    }
    private ConfigTip configTip_;
    public ConfigTip configTip
    {
        get
        {
            return configTip_;
        }
    }
    private ConfigShop configShop_;
    public ConfigShop configShop
    {
        get
        {
            return configShop_;
        }
    }
    public void Init(Action callback)
    {
        StartCoroutine(StartConfig(callback));
    }
    // Start is called before the first frame update
    IEnumerator StartConfig(Action callback)
    {
        Debug.LogError("Init Config start.");
        configDefault_ = Resources.Load("DataTable/ConfigDefault", typeof(ScriptableObject)) as ConfigDefault;
        yield return new WaitUntil(() => configDefault_ != null);
        configItem_ = Resources.Load("DataTable/ConfigItem", typeof(ScriptableObject)) as ConfigItem;
        yield return new WaitUntil(() => configItem_ != null);
        configWeapon_ = Resources.Load("DataTable/ConfigWeapon", typeof(ScriptableObject)) as ConfigWeapon;
        yield return new WaitUntil(() => configWeapon_ != null);
        configWeaponLevel_ = Resources.Load("DataTable/ConfigWeaponLevel", typeof(ScriptableObject)) as ConfigWeaponLevel;
        yield return new WaitUntil(() => configWeaponLevel_ != null);
        configWave_ = Resources.Load("DataTable/ConfigWave", typeof(ScriptableObject)) as ConfigWave;
        yield return new WaitUntil(() => configWave_ != null);
        configEnemy_ = Resources.Load("DataTable/ConfigEnemy", typeof(ScriptableObject)) as ConfigEnemy;
        yield return new WaitUntil(() => configEnemy_ != null);
        configEnemyLevel_ = Resources.Load("DataTable/ConfigEnemyLevel", typeof(ScriptableObject)) as ConfigEnemyLevel;
        yield return new WaitUntil(() => configEnemyLevel_ != null);
        configTip_ = Resources.Load("DataTable/ConfigTip", typeof(ScriptableObject)) as ConfigTip;
        yield return new WaitUntil(() => configTip_ != null);
        configShop_ = Resources.Load("DataTable/ConfigShop", typeof(ScriptableObject)) as ConfigShop;
        yield return new WaitUntil(() => configShop_ != null);
        callback?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
