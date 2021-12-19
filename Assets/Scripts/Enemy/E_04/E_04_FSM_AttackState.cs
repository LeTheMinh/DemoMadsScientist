using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class E_04_FSM_AttackState : FSMState
{
    [NonSerialized]
    public E_04_Control parent;

    private float timeCount;
    public override void OnEnter(object data)
    {
        timeCount = Time.time;
        parent.dataBiding.Attack = true;
        parent.timeAttack = 0;
    }
    public override void OnUpdate()
    {
        if (Time.time - timeCount > 0.5f)
            parent.GotoState(parent.idleState);
    }
}
