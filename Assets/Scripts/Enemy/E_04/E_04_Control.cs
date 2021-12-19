using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_04_Control : EnemyControl
{
    public E_04_DataBiding dataBiding;

    public E_04_FSM_IdleState idleState;
    public E_04_FSM_DeathState deadState;
    public E_04_FSM_GetHitState hitState;
    public E_04_FSM_WalkState walkState;
    public E_04_FSM_AttackState attackState= new E_04_FSM_AttackState();

    public override void Setup(EnemyCreateData enemyCreateData)
    {
        base.Setup(enemyCreateData);
        
        idleState.parent = this;
        deadState.parent = this;
        hitState.parent = this;
        walkState.parent = this;
        attackState.parent = this;
        GotoState(walkState);

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
        if (Vector3.Distance(characterControl.trans.position, trans.position) <= rangeAttack)
        {
            if (timeAttack >= rof)
            {
                //GotoState(attackState);
            }
        }
    }
}
