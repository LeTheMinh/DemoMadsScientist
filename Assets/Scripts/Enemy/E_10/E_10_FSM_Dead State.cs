using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class E_10_FSM_DeadState : FSMState
{
    [NonSerialized]
    public E_10_Control parent;
    public override void OnEnter()
    {
        parent.dataBiding.Dead = true;
        parent.OnDead();
    }
}
