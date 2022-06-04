using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _strength = 1;
    [SerializeField] private int _masteryOfRanged = 1;
    [SerializeField] private int _agility = 1; 
    [SerializeField] private int _militaryLuck = 1;
    [SerializeField] private int _luck = 1;
    [SerializeField] private int _marksmanship = 1;
    [SerializeField] private float _speed = 1;
    [SerializeField] private Weapon _currentWeapon;

    private int _currentHealth;
    private StatsSheet _statsSheet;
    private List<Weapon> _weapons;
    private List <Enemy> _enemiesInSight;
    private Enemy _targetEnemy;
    private int _maxValueMilitaryLuck = 100;
    private int _minValueMilitaryLuck = 0;
    private GameObject _player;

    public int Strength => _strength;
    public int MasteryOfRanged => _masteryOfRanged;
    public int Agility => _agility;
    public int MilitaryLuck => _militaryLuck;
    public int Luck => _luck;
    public float Speed => _speed;
    public int Marksmanship => _marksmanship;

    public GameObject PlayerLife => _player;

    private void Start() 
    {
        _statsSheet = new StatsSheet(_strength, _masteryOfRanged, _agility, _militaryLuck, _luck, _marksmanship);
    }

    public int DealDamage ()
    {
        if (_currentWeapon.IsRanged == true)
            return _currentWeapon.CalculateDamage(_masteryOfRanged);
        else
            return _currentWeapon.CalculateDamage(_masteryOfRanged);       
    }

    public bool TryDoCriticalDamage ()
    {
        int tempRandom = 0;

        if(_targetEnemy.TakeDamage(_militaryLuck += DealDamage()) <= 0)
            tempRandom = Random.Range(_minValueMilitaryLuck, _maxValueMilitaryLuck);

        if(tempRandom <= _militaryLuck) 
            return true;
        else
            return false;
    }

    public void ApplayDamage(int damage)
    {
        _currentHealth -= damage;

        if(_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}