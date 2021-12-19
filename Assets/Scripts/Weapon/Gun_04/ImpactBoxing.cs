using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactBoxing : MonoBehaviour
{
    [SerializeField] float timeHide;
    [SerializeField] string namePool = "Impact_boxing";
    [SerializeField] Animator animator;
    void OnEnable()
    {
        animator.Play("play");
        Invoke("EndFire", timeHide);
    }

    private void EndFire()
    {
        BYPoolManager.dicPool[namePool].OnDespwan(transform);
    }
}
