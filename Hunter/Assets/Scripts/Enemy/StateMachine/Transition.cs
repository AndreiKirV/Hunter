using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;
    [SerializeField] private State _previousState;

    protected Player Target { get; private set; }

    public State TargetState => _targetState;
    public State PreviousState => _previousState;


    public bool NeedTransitNext { get; protected set;}
    public bool NeedTransitPrevious { get; protected set;}

    public void Init(Player target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        NeedTransitNext = false;
        NeedTransitPrevious = false;
    }
}
