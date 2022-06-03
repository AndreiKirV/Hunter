using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    [SerializeField] private List<Transform> _transformsPoints;
    [SerializeField] private float _speed;

    
    private void Start()
    {
        
    }

    
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _transformsPoints[0].position, _speed * Time.deltaTime);
    }

    private void Patrol()
    {
       
        
    }
}
