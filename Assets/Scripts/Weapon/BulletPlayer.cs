﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInitData
{
    public Vector2 dir;
    public float speed;
    public int damage;
    public HitType hitType;
}
public class BulletPlayer : MonoBehaviour
{
    public Rigidbody2D rigidbody2D_;
    public string namePool = "Gun_02";
    public string namePool_Impact = "Impact_01";
    private BulletInitData data;

    // Start is called before the first frame update
    public void Setup(BulletInitData bulletInitData)
    {
        rigidbody2D_.velocity = bulletInitData.dir * bulletInitData.speed;
        data = bulletInitData;
    }

    private void OnBecameInvisible()
    {
        BYPoolManager.dicPool[namePool].OnDespwan(transform);
    }
     public void OnSpwan()
    {
    }
    public void OnDespwan()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Transform impact = BYPoolManager.dicPool[namePool_Impact].Spwan(); 
        impact.position=collision.contacts[0].point; 
        BYPoolManager.dicPool[namePool].OnDespwan(transform);
        collision.gameObject.GetComponent<EnemyControl>().OnDamage(data);
    }

}
