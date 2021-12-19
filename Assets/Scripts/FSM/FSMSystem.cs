using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMSystem : MonoBehaviour
{
    public FSMState currentState;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnUpdate();
        }
        OnSystemUpdate();
    }
    private void LateUpdate()
    {
        if (currentState != null)
        {
            currentState.OnLateUpdate();
        }
        OnSystemLateUpdate();
    }
    private void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.OnFixedUpdate();
        }
        OnSystemFixedUpdate();
    }
    public void GotoState(FSMState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = newState;
        currentState.OnEnter();
    }
    public void GotoState(FSMState newState, object data)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = newState;
        currentState.OnEnter(data);
    }
    public virtual void OnSystemUpdate()
    {

    }
    public virtual void OnSystemLateUpdate()
    {

    }
    public virtual void OnSystemFixedUpdate()
    {

    }
    public void OnMiddleAnim()
    {
        currentState.OnEventMiddleAnimation();
    }
    public void OnEndAnim()
    {
        currentState.OnEventEndAnimation();
    }
}
