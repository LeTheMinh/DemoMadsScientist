using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBoxing : MonoBehaviour
{
    [SerializeField] string namePool_Impact = "Impact_boxing";
    public BulletInitData boxingData { set; private get; }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Transform impact = BYPoolManager.dicPool[namePool_Impact].Spwan();
        impact.position = collision.contacts[0].point;
        collision.gameObject.GetComponent<EnemyControl>().OnDamage(boxingData);
    }
}
