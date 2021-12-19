using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class E_04_FSM_DeathState : FSMState
{
    [NonSerialized]
    public E_04_Control parent;

    public override void OnEnter()
    {
        parent.dataBiding.Dead = true;
        parent.OnDead();
    }
}
