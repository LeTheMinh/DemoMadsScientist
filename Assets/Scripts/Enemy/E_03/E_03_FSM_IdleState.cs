using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class E_03_FSM_IdleState : FSMState
{
    // Start is called before the first frame update
    [NonSerialized]
    public E_03_Control parent;
    private float timeDelay;
    private float timeWait;
    public override void OnEnter()
    {
        timeDelay = 0;
        timeWait = UnityEngine.Random.Range(2f, 6f);
        base.OnEnter();
    }
    public override void OnUpdate()
    {
        timeDelay += Time.deltaTime;
        if (timeDelay >= timeWait && !parent.isDetectCharacter)
            parent.GotoState(parent.moveState);
    }
}
