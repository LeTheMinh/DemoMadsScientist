using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class E_03_FSM_AttackState : FSMState
{
    [NonSerialized]
    public E_03_Control parent;
    private Coroutine coroutine;
    public override void OnEnter()
    {
        parent.dataBiding.Attack = true;
        parent.timeAttack = 0;
        coroutine = parent.StartCoroutine(WaitUpdate());

    }
    IEnumerator WaitUpdate()
    {
        yield return new WaitForSeconds(0.4f);
        parent.characterControl.OnDamage(new BulletInitData { damage=parent.damage});
        yield return new WaitForSeconds(0.2f);
        parent.GotoState(parent.idleState);
    }
    public override void OnExit()
    {
        if (coroutine != null)
            parent.StopCoroutine(coroutine);
    }
}
