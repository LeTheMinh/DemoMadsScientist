using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class E_09_FSM_DeadState : FSMState
{
    [NonSerialized]
    public E_09_Control parent;
    public override void OnEnter()
    {
        parent.dataBiding.Dead = true;
        parent.OnDead();
    }
}
