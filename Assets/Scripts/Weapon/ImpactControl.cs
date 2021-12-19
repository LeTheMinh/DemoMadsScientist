using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactControl : MonoBehaviour
{
    public Animator anim;
    public float lifeTime = 0.2f;
    // Start is called before the first frame update
    public string namePool = "Impact_01";

    public void OnSpwan()
    {
        StopAllCoroutines();
        StartCoroutine("LifeWait");
    }
    IEnumerator LifeWait()
    {
        anim.SetTrigger("Play");
        yield return new WaitForSeconds(lifeTime);
        BYPoolManager.dicPool[namePool].OnDespwan(transform);

    }
    public void OnDespwan()
    {

    }
}
