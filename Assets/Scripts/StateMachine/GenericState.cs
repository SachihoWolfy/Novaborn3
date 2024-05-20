using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class State : MonoBehaviour
{
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
}
