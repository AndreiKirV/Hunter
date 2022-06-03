using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    //[SerializeField] private int _reward;
    [SerializeField] private Player _target;

    public Player Target => _target;

    public int TakeDamage(int damage)
    {
        _health -= damage;
        return _health;
    }
}
 