using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponE2Control : MonoBehaviour
{
    public MuzzleFlash muzzleFlash;
    public Transform projecties;
    public string namePool = "Bullet_E";
    public Transform impact;
    public string namePool_Impact = "Impact_E";
    // Start is called before the first frame update
    void Start()
    {
       
        BYPool bulletPool = new BYPool();
        bulletPool.namePool = namePool;
        bulletPool.prefab = projecties;
        bulletPool.total = 10;
        BYPoolManager.AddNewPool(bulletPool);

        BYPool impactPool = new BYPool();
        impactPool.namePool = namePool_Impact;
        impactPool.prefab = impact;
        impactPool.total = 10;
        BYPoolManager.AddNewPool(impactPool);
    }

    public void OnFire(BulletInitData bulletInitData)
    {
        muzzleFlash.OnFire();
        Transform goBullet = BYPoolManager.dicPool[namePool].Spwan();
        goBullet.right = muzzleFlash.GetDirFire();
        goBullet.position = muzzleFlash.transform.position + goBullet.right * 0.5f;
        bulletInitData.dir = goBullet.right;
        bulletInitData.speed = 10;
        goBullet.GetComponent<BulletEnemyControl>().Setup(bulletInitData);
    }
}
