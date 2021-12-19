using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum HitType
{
    NORMAL = 1,
    FREEZ = 2,
    ELECTRIC = 3
}
public class EnemyCreateData
{
    public ConfigEnemyRecord config;
    public int round;
    public CharacterControl characterControl;
}
public class EnemyControl : FSMSystem
{
    public int currentHP;
    public int damage;
    public Transform trans;
    public float rof;
    public float rangeAttack;
    [HideInInspector]
    public float timeAttack;
    [HideInInspector]
    public CharacterControl characterControl;
    public bool isDetectCharacter;
    public int score;
    // Start is called before the first frame update
    public virtual void Setup(EnemyCreateData enemyCreateData)
    {
        characterControl = enemyCreateData.characterControl;
        trans = transform;
        if(enemyCreateData.round>GameConfig.maxRound)
        {
            enemyCreateData.round = GameConfig.maxRound;
        }
        MakeCompare2keyObject<int,int> objKey = new MakeCompare2keyObject<int,int>();
        objKey.key_1 = enemyCreateData.config.ID;
        objKey.key_2 = enemyCreateData.round;
        ConfigEnemyLevelRecord configEnemyLevel = ConfigManager.instance.configEnemyLevel.GetRecordByKeySearch(objKey);
        currentHP = configEnemyLevel.HP;
        damage = configEnemyLevel.Damage;
        score = configEnemyLevel.Score;
    }
    public virtual void OnDamage(BulletInitData damageData)
    {

    }
    public void OnDead()
    {
        Invoke("DelayDestroy", 1.2f);
        MissionControl.instance.OnEnemyDead(this);
    }
    private void DelayDestroy()
    {
        Destroy(gameObject);
    }
}
