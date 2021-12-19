using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class E_04_FSM_IdleState : FSMState
{
    [NonSerialized]
    public E_04_Control parent;
}
