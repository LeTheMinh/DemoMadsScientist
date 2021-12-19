using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class E_08_FSM_HitState : FSMState
{
    // Start is called before the first frame update
    [NonSerialized]
    public E_08_Control parent;
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
