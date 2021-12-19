using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_01_Control : EnemyControl
{
    public E_01_DataBiding dataBiding;
    // state 
    public E_01_FSM_IdleState idleState;
    public E_01_FSM_AttackState attackState;
    public E_01_FSM_DeadState deadState;
    public E_01_FSM_HitState hitState;
    public E_01_FSM_MoveState moveState;
    public override void Setup(EnemyCreateData enemyCreateData)
    {
        base.Setup(enemyCreateData);
        //
        idleState.parent = this;
        attackState.parent = this;
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
    public override void OnSystemUpdate()
    {
        timeAttack += Time.deltaTime;
        if(Vector3.Distance(characterControl.trans.position,trans.position)<=rangeAttack)
        {
            if(timeAttack>=rof)
            {
                isDetectCharacter = true;
                GotoState(attackState);
            }
        }
    }
}
