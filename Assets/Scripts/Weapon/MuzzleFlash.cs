using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    public Animator animator;
    public Transform aim;
    public void OnFire()
    {
        animator.SetTrigger("Fire");
    }
    public Vector2 GetDirFire()
    {

        return (aim.position - transform.position).normalized;
    }
}
