using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_03_Behaviour : WeaponBehaviour
{

    public Muzzle3 muzzle;
    public Transform projecties;
    public string namePool = "Gun_02";
    public Transform impact;
    public string namePool_Impact = "Impact_01";
    
    public void CreateBullet()
    {
        Transform goBullet = BYPoolManager.dicPool[namePool].Spwan();
        goBullet.right = muzzle.GetDirFire();
        goBullet.position = muzzle.transform.position + goBullet.right * 0.5f;
        BulletInitData data = new BulletInitData();
        data.dir = goBullet.right;
        data.speed = 10;
        goBullet.GetComponent<BulletPlayer>().Setup(data);
        // anynomus 
        //goBullet.GetComponent<BulletPlayer>().Setup(new BulletInitData { dir=muzzleFlash.GetDirFire(),speed=10});
    }
    public override void Setup(WeaponDataInit weaponDataInit)
    {
        base.Setup(weaponDataInit);
        iWeapon = new I_Gun_03_Handle();
        iWeapon.Init(this);
        BYPool bulletPool = new BYPool();
        bulletPool.namePool = namePool;
        bulletPool.prefab = projecties;
        bulletPool.total = clipSize;
        BYPoolManager.AddNewPool(bulletPool);

        BYPool impactPool = new BYPool();
        impactPool.namePool = namePool_Impact;
        impactPool.prefab = impact;
        impactPool.total = clipSize;
        BYPoolManager.AddNewPool(impactPool);
    }
}

public class I_Gun_03_Handle : IWeaponHandle
{
    private Gun_03_Behaviour weapon;
    public void FireHandle()
    {
        Debug.Log("Gun_3 fire!");
    }

    public void Init(WeaponBehaviour weaponBehaviour)
    {
        weapon = (Gun_03_Behaviour)weaponBehaviour;
    }

    public void ReloadHandle()
    {
        
    }
}
