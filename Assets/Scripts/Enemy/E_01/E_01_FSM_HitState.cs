using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class E_01_FSM_HitState : FSMState
{
    [NonSerialized]
    public E_01_Control parent;
    private float timeCount;
    public override void OnEnter(object data)
    {
        timeCount = 0;
        HitType hitType = (HitType)data;
        parent.dataBiding.Hit = hitType;
        base.OnEnter(data);
    }
    public override void OnUpdate()
    {
        timeCount += Time.deltaTime;
        if (timeCount > 0.35f)
            parent.GotoState(parent.idleState);
    }
}
