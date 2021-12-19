﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class E_05_FSM_MoveState : FSMState
{
    [NonSerialized]
    public E_05_Control parent;
    public float SpeedMove = 1;
    public override void OnEnter()
    {
        parent.dataBiding.Speed = 1;
        base.OnEnter();
    }
    public override void OnUpdate()
    {
        parent.trans.position = Vector3.Lerp(parent.trans.position, parent.trans.position - Vector3.right * 0.2f, Time.deltaTime * SpeedMove);
    }
    public override void OnExit()
    {
        parent.dataBiding.Speed = 0;
        base.OnExit();
    }
}
