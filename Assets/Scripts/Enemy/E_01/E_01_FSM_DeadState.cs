using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class E_01_FSM_DeadState : FSMState
{
    [NonSerialized]
    public E_01_Control parent;
    public override void OnEnter()
    {
        parent.dataBiding.Dead = true;
        parent.OnDead();
    }
}
