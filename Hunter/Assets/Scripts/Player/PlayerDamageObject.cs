using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageObject : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update() 
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        Debug.Log("other");

        if (other.gameObject.TryGetComponent<AttackRadius>(out AttackRadius attackRadius))
        {
            Destroy(gameObject);
        }
    }
}
