using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class E_09_FSM_MoveState : FSMState
{
    [NonSerialized]
    public E_09_Control parent;
    public float SpeedMove = 1;
    private Vector3 a;
    private bool up = true;
    public override void OnEnter()
    {
        parent.dataBiding.Speed = 1;
        a = new Vector3(1, 0, 0);
    }
    public override void OnUpdate()
    {
        if (up)
        {
            if (a.y <= 1) a.y += Time.deltaTime;
            else up = false;
        }
        else{
            if(a.y >= -1) a.y -= Time.deltaTime;
            else up = true;
        }

        parent.trans.position = Vector3.Lerp(parent.trans.position, parent.trans.position - a * SpeedMove, Time.deltaTime);
        base.OnUpdate();
        
    }
   
    public override void OnExit()
    {
        parent.dataBiding.Speed = 0;
        base.OnExit();
    }
}
