using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _damping = 0.009f;
    
    private Vector3 _target;
    private Vector3 _tempPosition;

    private void Update() 
    {
        _target = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);
        _tempPosition = Vector3.Lerp(transform.position, _target, _damping);
        transform.position = _tempPosition;
    }
}