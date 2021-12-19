using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class E_05_FSM_DeadState : FSMState
{
    [NonSerialized]
    public E_05_Control parent;
    public override void OnEnter()
    {
        parent.dataBiding.Dead = true;
        parent.OnDead();
    }
}