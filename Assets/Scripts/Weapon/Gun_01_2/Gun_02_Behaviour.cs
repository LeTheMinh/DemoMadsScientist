using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_02_Behaviour : WeaponBehaviour
{
    public MuzzleFlash muzzleFlash;
    public Transform projecties;
    public string namePool= "Gun_02";
    public Transform impact;
    public string namePool_Impact = "Impact_01";
    public override void Setup(WeaponDataInit weaponDataInit)
    {
        base.Setup(weaponDataInit);
        iWeapon = new I_Gun_02_Handle();
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
        goBullet.position = muzzleFlash.transform.position + goBullet.right*0.5f;
        BulletInitData data = new BulletInitData();
        data.dir = goBullet.right;
        data.speed = 10;
        data.damage = damage;
        data.hitType = hitType;
        goBullet.GetComponent<BulletPlayer>().Setup(data);
        // anynomus 
        //goBullet.GetComponent<BulletPlayer>().Setup(new BulletInitData { dir=muzzleFlash.GetDirFire(),speed=10});
    }
}

public class I_Gun_02_Handle : IWeaponHandle
{
    private Gun_02_Behaviour weapon;
    public void FireHandle()
    {
        weapon.muzzleFlash.OnFire();
        weapon.CreateBullet();
    }

    public void Init(WeaponBehaviour weaponBehaviour)
    {
        weapon = (Gun_02_Behaviour)weaponBehaviour;
    }

    public void ReloadHandle()
    {
    }
}