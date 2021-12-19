using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class E_02_FSM_AttackState : FSMState
{
    public WeaponE2Control weapon;
    // Start is called before the first frame update
    [NonSerialized]
    public E_02_Control parent;
    private Coroutine coroutine;
    public override void OnEnter()
    {
        parent.dataBiding.Attack = true;
        parent.timeAttack = 0;
        weapon.OnFire(new BulletInitData { damage = parent.damage });

        coroutine = parent.StartCoroutine(WaitUpdate());

    }
    IEnumerator WaitUpdate()
    {
        yield return new WaitForSeconds(0.35f);
        parent.GotoState(parent.idleState);
    }
    public override void OnExit()
    {
        if (coroutine != null)
            parent.StopCoroutine(coroutine);
    }
}
