using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MeleeEnemy : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _attackCooldown;
    [SerializeField] private float _range;
    [SerializeField] private float _location;
    [SerializeField] private int _damage;
    [SerializeField] private CircleCollider2D _circleCollider;
    [SerializeField] private LayerMask _playerLayer;

    private float _cooldownTimer = Mathf.Infinity; //чтобы враг аттакавал сразу, 
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        _cooldownTimer += Time.deltaTime;

        //Attack only when player in sight?
        if (PlayerInSight())
        {
            if (_cooldownTimer >= _attackCooldown)
            {
                _cooldownTimer = 0;
                _animator.SetTrigger("Boom");
                
                //attack
            }
        }

    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.CircleCast(_circleCollider.bounds.center * _location, _circleCollider.radius * _range,
            Vector2.one, 0, _playerLayer);

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_circleCollider.bounds.center * _location, _circleCollider.radius * _range);
    }

}

   