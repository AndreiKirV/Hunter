using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _rangeOfAttack = 10;
    [SerializeField] private int _baseDamage = 1;

    private bool _isRanged;
    private Player _player;

    public bool IsRanged => _isRanged;
    public int RangeOfAttack => _rangeOfAttack;

    public int CalculateDamage(int damage)
    {
        return _baseDamage += damage;
    }
}
