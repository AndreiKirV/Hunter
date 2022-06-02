using UnityEngine;

public class Patroler : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _positionOfPatrol;
    [SerializeField] private Transform _point;
    
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(transform.position, _point.position) < _positionOfPatrol)
        {
            Patrol();
        }
    }

    private void Patrol()
    {

    }

    private void Angry()
    {

    }

    private void ReturnToPosition()
    {

    }
}
