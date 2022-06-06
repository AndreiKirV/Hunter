using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _rangeOfAttack = 2;
    [SerializeField] private int _baseDamage = 2;
    [SerializeField] private bool _isRanged = false;

    public bool IsRanged => _isRanged;
    public float RangeOfAttack => _rangeOfAttack;
    public int BaseDamage => _baseDamage;

    public Weapon (int baseDamage, float rangeOfAttack, bool isRanged = false)
    {
        _baseDamage = baseDamage;
        _rangeOfAttack = rangeOfAttack;
        _isRanged = isRanged;
    }

    public int CalculateDamage(int damage)
    {
        return _baseDamage += damage;
    }
}
