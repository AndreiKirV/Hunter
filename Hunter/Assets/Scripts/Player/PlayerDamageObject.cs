using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageObject : MonoBehaviour
{
    [SerializeField] private float _speed;
    private int _damage;
    private bool _isCritical = false;

    private void Update() 
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.TryGetComponent<AttackRadius>(out AttackRadius attackRadius))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
        }
    }

    public int AssignDamage (int damage, bool  isCritical)
    {
        _damage = damage;
        _isCritical = isCritical;
        return _damage;
    }
}
