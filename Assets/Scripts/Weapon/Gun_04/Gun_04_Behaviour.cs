using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_04_Behaviour : WeaponBehaviour
{
    [SerializeField] MuzzleBoxingControl muzzleBoxingControl;
    [SerializeField] BoxingControl boxingControl;
    [SerializeField] Transform impact;
    [SerializeField] CollisionBoxing collisionBoxing;
    [SerializeField] string namePool_Impact = "Impact_boxing";
    public override void Setup(WeaponDataInit weaponDataInit)
    {
        base.Setup(weaponDataInit);
        iWeapon = new I_Gun_04_Handle();
        iWeapon.Init(this);

        BulletInitData data = new BulletInitData();
        data.dir = Vector2.zero;
        data.speed = 0;
        data.damage = damage;
        data.hitType = hitType;
        collisionBoxing.boxingData = data;

        BYPool impactPool = new BYPool();
        impactPool.namePool = namePool_Impact;
        impactPool.prefab = impact;
        impactPool.total = clipSize;
        BYPoolManager.AddNewPool(impactPool);
    }

    public void Fire()
    {
        muzzleBoxingControl.Fire();
        boxingControl.Fire();
    }
}

public class I_Gun_04_Handle : IWeaponHandle
{
    private Gun_04_Behaviour weapon;
    public void FireHandle()
    {
        weapon.Fire();
    }

    public void Init(WeaponBehaviour weaponBehaviour)
    {
        weapon = (Gun_04_Behaviour)weaponBehaviour;
    }

    public void ReloadHandle()
    {
    }
}