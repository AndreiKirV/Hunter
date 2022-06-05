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
    [SerializeField] private float _delay;
    [SerializeField] private float _startWaitTime;
 
    [SerializeField] private Animator _animator;

    private int _randomPoint;

    private void Start()
    {
        _delay = _startWaitTime;
        _randomPoint = Random.Range(0, _patrolPoints.Count);
    }

    
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _patrolPoints[_randomPoint].position, 
            _speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, _patrolPoints[_randomPoint].position) < 0.2f)
        { 
            if(_delay <= 0)
            {
                _randomPoint = Random.Range(0, _patrolPoints.Count);
                _delay = _startWaitTime;
            }
            else
            {
                _delay -= Time.deltaTime;
            }
        }

    }

    private void MoveInDirection(int direction)
    {
        //Make enemy face direction
       
        //Move int that direction
        _enemy.position = new Vector3(_enemy.position.x +Time.deltaTime * direction * _speed,
            _enemy.position.y, _enemy.position.z);
    }
}
