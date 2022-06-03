using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    //[SerializeField] private int _reward;
    [SerializeField] private Player _target;
    private Vector2 _direction;
    [SerializeField] private Animator _animator;

    private void Start()
    {

    }

    private void Update()
    {
      _animator.SetFloat("Horizontal", _direction.x);
      _animator.SetFloat("Vertical", _direction.y);
      _animator.SetFloat("Speed", _direction.sqrMagnitude);
    }

    public Player Target => _target;

    public int TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy(gameObject);
        }

        return _health;
    }


}
 