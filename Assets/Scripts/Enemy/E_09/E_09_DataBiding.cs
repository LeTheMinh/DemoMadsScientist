using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_09_DataBiding : MonoBehaviour
{
    public Animator animator;
    public float Speed
    {
        set
        {
            animator.SetFloat(animKey_Speed, value);
        }
    }
    public bool Dead
    {
        set
        {
            if (value)
                animator.SetTrigger(animKey_Dead);
        }
    }
    public HitType Hit
    {
        set
        {
            animator.SetInteger(animKey_HitType, (int)value);
            animator.SetTrigger(animKey_Hit);
        }
    }
    private int animKey_Hit;
    private int animKey_HitType;
    private int animKey_Speed;
    private int animKey_Dead;
    // Start is called before the first frame update
    void Awake()
    {
        animKey_Hit = Animator.StringToHash("Hit");
        animKey_HitType = Animator.StringToHash("HitType");
        animKey_Speed = Animator.StringToHash("Speed");
        animKey_Dead = Animator.StringToHash("Dead");

    }
}
