using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    [SerializeField] private List<Transform> _patrolPoints;

    [Header("Enemy")]
    [SerializeField] private Transform _enemy;

    [Header("Movement parameters")]
    [SerializeField] private float _speed;

    [SerializeField] private Animator _animator;

    
    private void Start()
    {
        
    }

    
    private void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, _patrolPoints[0].position, _speed * Time.deltaTime);
    }

    private void MoveInDirection(int direction)
    {
        //Make enemy face direction
       
        //Move int that direction
        _enemy.position = new Vector3(_enemy.position.x +Time.deltaTime * direction * _speed,
            _enemy.position.y, _enemy.position.z);
    }
}
