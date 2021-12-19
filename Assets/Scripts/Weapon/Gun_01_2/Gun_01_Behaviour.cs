using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_01_Behaviour : WeaponBehaviour
{
    public LazerControl lazer;
    public GameObject parentLazer;
    private BulletInitData data = new BulletInitData();

    public override void Setup(WeaponDataInit weaponDataInit)
    {
        base.Setup(weaponDataInit);
        iWeapon = new I_Gun_01_Handle();
        iWeapon.Init(this);
        data.dir = Vector2.zero;
        data.speed = 0;
        data.damage = damage;
        data.hitType = hitType;
    }
    public void FireLazer()
    {
        StopCoroutine("FireLoop");
        StartCoroutine("FireLoop");
    }
    IEnumerator FireLoop()
    {
        parentLazer.SetActive(true);
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPoint.z = 0;
        lazer.impact.position = worldPoint;
        int count = 0;
        while (count < 5)
        {
            yield return new WaitForSeconds(0.1f);
            count++;
            Collider2D[] cols = Physics2D.OverlapCircleAll(worldPoint, 1.5f, 1 << 9);
            foreach (Collider2D e in cols)
            {

                e.gameObject.GetComponent<EnemyControl>().OnDamage(data);
            }

        }

        parentLazer.SetActive(false);
    }

}

public class I_Gun_01_Handle : IWeaponHandle
{
    private Gun_01_Behaviour weapon;
    public void FireHandle()
    {
        weapon.FireLazer();
    }

    public void Init(WeaponBehaviour weaponBehaviour)
    {
        weapon = (Gun_01_Behaviour)weaponBehaviour;
    }

    public void ReloadHandle()
    {
    }
}