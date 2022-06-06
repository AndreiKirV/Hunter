using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int _health = 100;
    [SerializeField] private int _strength = 1;
    [SerializeField] private int _masteryOfRanged = 1;
    [SerializeField] private int _agility = 1; 
    [SerializeField] private int _militaryLuck = 1;
    [SerializeField] private int _luck = 1;
    [SerializeField] private float _marksmanship = 2;
    [SerializeField] private int _playerLife;

    [Header("RealStats")]
    [SerializeField] private float _speed = 1;
    private Weapon _currentWeapon = new Weapon(2,2f); //SerializeField

    private int _currentHealth;
    private StatsSheet _statsSheet;
    private List<Weapon> _weapons;
    private List <Enemy> _enemiesInSight;
    private int _maxValueMilitaryLuck = 100;
    private int _minValueMilitaryLuck = 0;
    private Enemy _targetEnemy;

    private List<Enemy> _enemies;

    public int Strength => _strength;
    public int CurrentHealth => _currentHealth;
    public int MasteryOfRanged => _masteryOfRanged;
    public int Agility => _agility;
    public int MilitaryLuck => _militaryLuck;
    public int Luck => _luck;
    public int PlayerLife => _playerLife;
    public float Speed => _speed;
    public float Marksmanship => _marksmanship;
    public Weapon CurrentWeapon => _currentWeapon;

    private void Start() 
    {
        _statsSheet = new StatsSheet(_strength, _masteryOfRanged, _agility, _militaryLuck, _luck, _marksmanship);
    }

    public int DealDamage ()
    {
        if (_currentWeapon.IsRanged == true)
            return _currentWeapon.CalculateDamage(_masteryOfRanged);
        else
            return _currentWeapon.CalculateDamage(_strength);       
    }

    public void ApplayDamage(int damage)
    {
        _currentHealth -= damage;

        if(_currentHealth <= 0)
        {
       
        }
    }
}