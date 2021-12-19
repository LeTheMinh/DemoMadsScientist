using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class E_09_FSM_IdleState : FSMState
{
    [NonSerialized]
    public E_09_Control parent;
    private float timeDelay;
    private float timeWait = 0.5f;
    public override void OnEnter()
    {
        base.OnEnter();
    }
    public override void OnUpdate()
    {
        timeDelay += Time.deltaTime;
        if (timeDelay >= timeWait && !parent.isDetectCharacter)
            parent.GotoState(parent.moveState);
    }
}
