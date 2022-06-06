using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageObject : MonoBehaviour
{
    [SerializeField] private float _speed;
    private int _damage;
    private bool _isCritical = false;
    private Player _player;

    public int Damage => _damage;

    public PlayerDamageObject (int damage, bool  isCritical)
    {
        _damage = damage;
        _isCritical = isCritical;
    }

    private void Start() 
    {
        AssignDamage(_player.Damage);
    }

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
            Debug.Log($"Влетел в {enemy} {_damage}");
            Destroy(gameObject);
        }
    }

    private void AssignDamage (int damage)
    {
        _damage = damage;
        Debug.Log($"Присвоен урон пуле {_damage}");
    }

    public void TakeOwner(Player player)
    {
        _player = player;
    }
}
