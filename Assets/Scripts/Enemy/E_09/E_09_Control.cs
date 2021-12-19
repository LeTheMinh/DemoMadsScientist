using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_09_Control : EnemyControl
{
    public E_09_DataBiding dataBiding;

    public E_09_FSM_IdleState idleState;
    public E_09_FSM_DeadState deadState;
    public E_09_FSM_HitState hitState;
    public E_09_FSM_MoveState moveState;
    public override void Setup(EnemyCreateData enemyCreateData)
    {
        base.Setup(enemyCreateData);
        idleState.parent = this;
        deadState.parent = this;
        hitState.parent = this;
        moveState.parent = this;
        GotoState(moveState);
    }
    
    public override void OnDamage(BulletInitData damageData)
    {
        base.OnDamage(damageData);
        currentHP -= damageData.damage;
        if (currentHP <= 0)
        {
            // dead
            if (currentState != deadState)
                GotoState(deadState);
        }
        else
        {
            //hit
            if (currentState != hitState)
                GotoState(hitState, damageData.hitType);
        }
    }

}
