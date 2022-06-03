using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ViewingRadius : MonoBehaviour
{
    [SerializeField] private Player _player;

    private List<GameObject> _enemies = new List<GameObject>();

    public UnityEvent <Enemy> EnemyInCollider = new UnityEvent<Enemy>();

    private void Update() 
    {
        ReSize(_player.Marksmanship);
    }
    

    private void ReSize (float value)
    {
        transform.localScale = new Vector3(value, value, 0.0f);
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("Надо добавить объект");
        GameObject enteredObject = other.gameObject;
        Debug.Log(enteredObject);
        _enemies.Add(enteredObject);
        Debug.Log("добавил врага");

        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            Debug.Log("Надо добавить врага");
            

            foreach (GameObject enemy1 in _enemies)
            {
                Debug.Log(enemy1);
            }
        }
    }
}