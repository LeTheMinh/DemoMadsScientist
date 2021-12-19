using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAnimBehaviour : StateMachineBehaviour
{
    FSMSystem fsmSystem;
    private float timeCount;
    public float timeAttack;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeCount = 0;
        fsmSystem = animator.GetComponentInParent<FSMSystem>();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeCount += Time.deltaTime ;
        if(timeCount>= timeAttack)
        {
            fsmSystem.OnMiddleAnim();
            timeCount =-stateInfo.length;
        }
        base.OnStateUpdate(animator, stateInfo, layerIndex);
    }
    public override void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        base.OnStateMachineExit(animator, stateMachinePathHash);
    }
}
