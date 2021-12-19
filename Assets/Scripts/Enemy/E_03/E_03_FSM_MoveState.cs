using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class E_03_FSM_MoveState : FSMState
{
    [NonSerialized]
    public E_03_Control parent;
    public float SpeedMove = 1;
    private float timeDelay;
    private float timeWait;
    public override void OnEnter()
    {
        timeDelay = 0;
        timeWait = UnityEngine.Random.Range(2f, 6f);
        parent.dataBiding.Speed = 1;
        base.OnEnter();
    }
    public override void OnUpdate()
    {
        timeDelay += Time.deltaTime;
        if (timeDelay >= timeWait)
            parent.GotoState(parent.idleState);
        parent.trans.position = Vector3.Lerp(parent.trans.position, parent.trans.position - Vector3.right * 0.2f, Time.deltaTime * SpeedMove);
    }
    public override void OnExit()
    {
        parent.dataBiding.Speed = 0;
        base.OnExit();
    }
}
