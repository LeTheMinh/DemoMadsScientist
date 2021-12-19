using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDataInit
{
    public ConfigWeaponRecord configWP;
}
public class WeaponBehaviour : MonoBehaviour
{
    public CharacterDataBinding dataBinding;
  
    public IWeaponHandle iWeapon;
    public event Action<int, int> OnAmoUpdate;
    public event Action<int, int> OnHPUpdate;
    public Action<float> StartReload;
    public Action EndReloadReload;
    public Sprite iconGun;
    public int numberBullet;
    public int clipSize;
    public float rof;
    public float timeReload;
    protected bool isFire;
    private float timeFire;
    private bool isReload;
    protected int damage;
    public HitType hitType;
    public GunData gunData;
    public int currentHP, totalHP;
    public virtual void Setup(WeaponDataInit weaponDataInit)
    {
         gunData = DataAPIController.instance.GetGunDataById(weaponDataInit.configWP.ID);
        MakeCompare2keyObject<int, int> keySearch = new MakeCompare2keyObject<int, int>();
        keySearch.key_1 = gunData.idGun;
        keySearch.key_2 = gunData.level;
        ConfigWeaponLevelRecord cfWeaponLevel = ConfigManager.instance.configWeaponLevel.GetRecordByKeySearch(keySearch);
        dataBinding = gameObject.GetComponent<CharacterDataBinding>();
        dataBinding.UpdateLocalAnim = UpdateLocalAnim;

        clipSize = cfWeaponLevel.ClipSize;
        numberBullet = cfWeaponLevel.ClipSize;
        rof = cfWeaponLevel.Rof;
        timeReload = cfWeaponLevel.Reload;
        damage = cfWeaponLevel.Damage;
        currentHP = cfWeaponLevel.HP;
        totalHP = cfWeaponLevel.HP;
    }
    public void OnReady()
    {
        if(isReload)
        {
            Reload();
        }
        isFire = false;
        OnAmoUpdate?.Invoke(numberBullet, clipSize);
    }
    public void OnFire(bool isFire, Vector2 point)
    {
        this.isFire = isFire;
    }
    private void UpdateLocalAnim()
    {
        timeFire += Time.deltaTime;
        if (isFire&&!isReload)
        {
            if (timeFire >= rof)
            {
                if(numberBullet>0)
                {
                    dataBinding.Fire = true;
                    numberBullet--;
                    OnAmoUpdate?.Invoke(numberBullet, clipSize);
                    timeFire = 0;
                    iWeapon.FireHandle();
                    if (numberBullet <= 0 )
                    {
                        Reload();
                    }
                }
                else
                {
                    // dry
                }
               
        
            }
          

        }
     
    }
  
    private void Reload()
    {
       
        StopCoroutine("ReloadProcess");
        StartCoroutine("ReloadProcess");
    }
    IEnumerator ReloadProcess ()
    {
        isReload = true;
        StartReload?.Invoke(timeReload);
        yield return new WaitForSeconds(timeReload);
        EndReloadReload?.Invoke();
        
        numberBullet = clipSize;
        OnAmoUpdate?.Invoke(numberBullet, clipSize);
        isReload = false;
    }
    public void OnDamage(BulletInitData data)
    {
        currentHP -= data.damage;
        if(currentHP<=0)
        {
            MissionControl.instance.OnWeaponHpEnd(this);
        }
        OnHPUpdate?.Invoke(currentHP, totalHP);

    }
}
