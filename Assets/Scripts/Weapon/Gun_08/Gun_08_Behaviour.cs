using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_08_Behaviour : WeaponBehaviour
{
    public MuzzleFlash muzzleFlash;
    public Transform anchorAim;
    public Transform projecties;
    public string namePool = "Gun_08";
    public Transform impact;
    public string namePool_Impact = "Impact_01";
    public override void Setup(WeaponDataInit weaponDataInit)
    {
        base.Setup(weaponDataInit);
        iWeapon = new I_Gun_08_Handle();
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

        float angle = Random.Range(-15f*Mathf.Deg2Rad, 15f*Mathf.Deg2Rad);

        Vector2 accuracy = new Vector2(muzzleFlash.GetDirFire().x * Mathf.Cos(angle) - muzzleFlash.GetDirFire().y* Mathf.Sin(angle), muzzleFlash.GetDirFire().x * Mathf.Sin(angle) + muzzleFlash.GetDirFire().y * Mathf.Cos(angle));
        
        goBullet.right = accuracy;
        goBullet.position = muzzleFlash.transform.position + goBullet.right * 0.5f;

        BulletInitData data = new BulletInitData();
        data.damage = damage;
        data.dir = accuracy;
        data.speed = 10;
        goBullet.GetComponent<BulletPlayer>().Setup(data);
        // anynomus 
        //goBullet.GetComponent<BulletPlayer>().Setup(new BulletInitData { dir=muzzleFlash.GetDirFire(),speed=10});
    }
}
public class I_Gun_08_Handle : IWeaponHandle
{
    private Gun_08_Behaviour weapon;
    public void FireHandle()
    {
        weapon.CreateBullet();
    }

    public void Init(WeaponBehaviour weaponBehaviour)
    {
        weapon = (Gun_08_Behaviour)weaponBehaviour;
    }

    public void ReloadHandle()
    {
    }
}
