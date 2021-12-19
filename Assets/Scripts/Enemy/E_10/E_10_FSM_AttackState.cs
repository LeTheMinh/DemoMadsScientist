using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class E_10_FSM_AttackState : FSMState
{
    [NonSerialized]
    public E_10_Control parent;
    private float timeCount;
    public override void OnEnter(object data)
    {
        timeCount = 0;
        parent.dataBiding.Attack = true;
        parent.timeAttack = 0;
    }
    public override void OnUpdate()
    {
        timeCount += Time.deltaTime;
        if (timeCount > 0.35f)
            parent.GotoState(parent.idleState);
    }
}

