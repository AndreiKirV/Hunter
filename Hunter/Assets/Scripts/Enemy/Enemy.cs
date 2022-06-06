using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    //[SerializeField] private int _reward;
    [SerializeField] private Animator _animator;
    [SerializeField] private Player _target;

    private Vector2 _direction;
    private int _currentHealth;

    private void Update()
    {
      _animator.SetFloat("Horizontal", _direction.x);
      _animator.SetFloat("Vertical", _direction.y);
      _animator.SetFloat("Speed", _direction.sqrMagnitude);
    }

    public Player Target => _target;

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        Debug.Log(_health);

        if (_health <= 0)
        {
            Debug.Log("Ай эм умер");
            Destroy(gameObject);
        }
    }

    public void AssignTarget(Player player)
    {
        _target = player;
    }
}
 