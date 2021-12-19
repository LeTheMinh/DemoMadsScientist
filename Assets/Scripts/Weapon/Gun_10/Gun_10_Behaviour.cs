using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_10_Behaviour : WeaponBehaviour
{
    public MuzzleFlash muzzleFlash;
    public Transform projecties;
    public string namePool = "Gun_10";
    public Transform impact;
    public string namePool_Impact = "Impact_09";
    public override void Setup(WeaponDataInit weaponDataInit)
    {
        base.Setup(weaponDataInit);
        iWeapon = new I_Gun_10_Handle();
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
    public void CreateBullet()
    {
        Transform goBullet = BYPoolManager.dicPool[namePool].Spwan();
        goBullet.right = muzzleFlash.GetDirFire();
        goBullet.position = muzzleFlash.transform.position + goBullet.right * 0.5f;
        BulletInitData data = new BulletInitData();
        data.dir = goBullet.right;
        data.speed = 10;
        goBullet.GetComponent<BulletPlayer>().Setup(data);
        data.damage = damage;
        // anynomus 
        //goBullet.GetComponent<BulletPlayer>().Setup(new BulletInitData { dir=muzzleFlash.GetDirFire(),speed=10});
    }
}

public class I_Gun_10_Handle : IWeaponHandle
{
    private Gun_10_Behaviour weapon;
    public void FireHandle()
    {
        Debug.LogError("Gun_10 Fire");
        weapon.muzzleFlash.OnFire();
        weapon.CreateBullet();
    }

    public void Init(WeaponBehaviour weaponBehaviour)
    {
        weapon = (Gun_10_Behaviour)weaponBehaviour;
    }

    public void ReloadHandle()
    {
    }
}