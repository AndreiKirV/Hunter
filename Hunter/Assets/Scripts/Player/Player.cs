using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _strength = 1;
    [SerializeField] private int _masteryOfRanged = 1;
    [SerializeField] private int _agility = 1; 
    [SerializeField] private int _militaryLuck = 1;
    [SerializeField] private int _luck = 1;
    [SerializeField] private float _speed = 1;

    private StatsSheet _statsSheet;

    public float Speed => _speed;

    private void Start() 
    {
        _statsSheet = new StatsSheet(_strength, _masteryOfRanged, _agility, _militaryLuck, _luck);
    }
}