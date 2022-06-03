using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerPunch : MonoBehaviour
{
    [SerializeField] private Enemy _target;
    [SerializeField] private float _distancePunch;

    private int _damage = 10;
     
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            Punch(_damage);

        }
    }

    public void Punch(int damage)
    {
        float distanceToEnemy = Vector3.Distance(_target.transform.position, transform.position);

        if(distanceToEnemy <= _distancePunch)
        {
            _target.TakeDamage(damage);
        }
        
    }
}
