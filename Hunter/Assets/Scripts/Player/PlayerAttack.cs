using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerDamageObject _bullet;
    [SerializeField] private float offset;
    [SerializeField] private Transform _shotDirection;
    [SerializeField] private float _startTime;
    private float _timeShot;

    private void Update() 
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

        if (_timeShot <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(_bullet, _shotDirection.position, transform.rotation);
                _timeShot = _startTime;
            }
        }
        else
            _timeShot -= Time.deltaTime;
    }
}