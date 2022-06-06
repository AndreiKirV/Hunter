using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgroDistanceTransition : Transition
{
    [SerializeField] private float _agroRange;
    [SerializeField] private CircleCollider2D _circleCollider;

    public float AgroRange => _agroRange;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) < _agroRange)
            NeedTransitNext = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_circleCollider.bounds.center, _agroRange);
    }
}
