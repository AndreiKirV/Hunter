using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DistanceTransition))]
public class TargetDieTransition : Transition
{
    private float _distanceAttack;

    private void Start()
    {
        _distanceAttack = GetComponent<DistanceTransition>().TransitionRange;
    }

    private void Update()
    {
        if (Target.CurrentHealth <= 0)
            NeedTransitNext = true;
        else if (Vector2.Distance(transform.position, Target.transform.position) > _distanceAttack)
            NeedTransitPrevious = true;
    }
}
