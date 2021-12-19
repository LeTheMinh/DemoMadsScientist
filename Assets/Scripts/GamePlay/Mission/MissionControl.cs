using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class DataHPGun
{
    public int totalHP;
    public int currentHP;
    public DataHPGun(int hp)
    {
        totalHP = hp;
        currentHP = hp;

    }
}
public class MissionControl : Singleton<MissionControl>
{

    public CharacterControl characterControl;
    public event Action<int> OnScoreCalculator;
    private int round = 1;
    private int indexWave = -1;
    private ConfigWaveRecord currentCFWave;
    private int totalWave;
    private List<ConfigWaveRecord> configWaveRecords;
    public event Action<bool> OnMoveEvent;
    private int countEnemyDead;
    private int distance;
    private int scoreEnemy;
    private int countHPEnd;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoopCountDistance");
        // create enemy
        totalWave = ConfigManager.instance.configWave.TotalWave;
        configWaveRecords = ConfigManager.instance.configWave.AllRecord;
        StartCoroutine("StartNewWave");

       
    }
    
    IEnumerator StartNewWave()
    {
        indexWave++;
        if (indexWave >= totalWave)
        {
            indexWave = 0;
            round++;
            Debug.LogError("New round: " + round);

        }
        currentCFWave = configWaveRecords[indexWave];
        countEnemyDead = 0;
        // start move
        OnMoveEvent?.Invoke(true);
        yield return new WaitForSeconds(currentCFWave.Delay);
        // stop move
        OnMoveEvent?.Invoke(false);
        WaitForSeconds waitRate = new WaitForSeconds(currentCFWave.Rate);
        int countEnemy = 0;
        List<int> enemyIDs = currentCFWave.GetEnemies;
        while (countEnemy < currentCFWave.Number)
        {
            yield return waitRate;
            int idEnemy = 0;
            if (currentCFWave.Random)
            {
                idEnemy = enemyIDs.OrderBy(x => new Guid()).FirstOrDefault();
            }
            else
            {
                idEnemy = enemyIDs[countEnemy];
            }
            // create enemy :
            // get config enemy
            ConfigEnemyRecord configEnemy = ConfigManager.instance.configEnemy.GetRecordByKeySearch(idEnemy);
            // create enemy
            GameObject object_E = Instantiate(Resources.Load("Enemy/" + configEnemy.Prefab, typeof(GameObject))) as GameObject;
            object_E.transform.position = characterControl.anchorFront.position;
            object_E.GetComponent<EnemyControl>().Setup(new EnemyCreateData { config = configEnemy, round = round, characterControl = characterControl });
            countEnemy++;
        }

    }

    IEnumerator LoopCountDistance()
    {
        float startX = characterControl.trans.position.x;
        WaitForSeconds wait = new WaitForSeconds(1);
        while (true)
        {
            yield return wait;
            // debug .....
            float currentX = characterControl.trans.position.x;
            distance = Mathf.RoundToInt(currentX - startX);
            OnScoreCalculator?.Invoke(distance + scoreEnemy);

        }

    }
    public void OnEnemyDead(EnemyControl e)
    {
        countEnemyDead++;
        scoreEnemy += e.score;
        OnScoreCalculator?.Invoke(distance + scoreEnemy);
        if (countEnemyDead >= currentCFWave.Number)
        {
            StopCoroutine("StartNewWave");
            StartCoroutine("StartNewWave");
        }
    }
    public void OnWeaponHpEnd(WeaponBehaviour weaponBehaviour)
    {
        countHPEnd++;
        if(countHPEnd<2)
        {
            InputManager.instance.OnChangeGun();
        }
        else
        {
            int score = distance + scoreEnemy;
   
            DialogManager.instance.ShowDialog(DialogIndex.DialogGameEnd, new DialogGameEndParam { score = score });
        }
    }
}
