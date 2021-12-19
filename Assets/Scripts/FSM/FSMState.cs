using System;

[Serializable]
public class FSMState
{
    public virtual void OnEnter()
    {

    }
    public virtual void OnEnter(object data)
    {

    }
    public virtual void OnUpdate()
    {

    }
    public virtual void OnLateUpdate()
    {

    }
    public virtual void OnFixedUpdate()
    {

    }

    public virtual void OnExit()
    {

    }
    public virtual void OnEventMiddleAnimation()
    {

    }
    public virtual void OnEventEndAnimation()
    {

    }
}
