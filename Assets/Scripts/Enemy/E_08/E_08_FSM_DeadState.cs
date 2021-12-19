using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class E_08_FSM_DeadState : FSMState
{
    // Start is called before the first frame update
    [NonSerialized]
    public E_08_Control parent;
    public override void OnEnter()
    {
        parent.dataBiding.Dead = true;
        parent.OnDead();
    }
}

