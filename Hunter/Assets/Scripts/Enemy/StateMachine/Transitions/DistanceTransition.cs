using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AgroDistanceTransition))]
public class DistanceTransition : Transition
{
    [SerializeField] private float _transitionRange;
    [SerializeField] private CircleCollider2D _circleCollider;

    public float TransitionRange => _transitionRange;

    private float _agroRange;

    private void Start()
    {
        _agroRange = GetComponent<AgroDistanceTransition>().AgroRange;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) < _transitionRange)
            NeedTransitNext = true;
        if (Vector2.Distance(transform.position, Target.transform.position) > _agroRange)
            NeedTransitPrevious = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_circleCollider.bounds.center, _transitionRange);
    }
}
