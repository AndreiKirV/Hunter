using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ViewingRadius : MonoBehaviour
{
    private Player _player;

    private int _maxRadius = 100;

    private List<GameObject> _enemies = new List<GameObject>();

    private void Start() 
    {
        _player = transform.parent.gameObject.GetComponent<Player>();
        ReSize(_player.Marksmanship);
    }

    private void Update() 
    {
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        TryAddEnemy(other);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        TryRemoveEnemy(other);
    }

    public void EnlargeSize (float value)
    {   
        Vector3 tempLocalScale = transform.localScale;

        if ((tempLocalScale.x += value) >= _maxRadius)
            transform.localScale += new Vector3(value, value, 0.0f);  
    }

    public void IncreaseSize (float value)
    {   
        Vector3 tempLocalScale = transform.localScale;

        if ((tempLocalScale.x -= value) >= 0)
            transform.localScale -= new Vector3(value, value, 0.0f);  
    }

    private bool MatchUp (List<GameObject> objects, GameObject targetObject)
    {
        bool isMatchesFound = false;

        for (int i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i] == targetObject.gameObject)
            {
                isMatchesFound = true;
                break;
            }
        }

        return isMatchesFound;
    }

    private void TryAddEnemy(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy) && MatchUp(_enemies, other.gameObject) == false)
        {
            _enemies.Add(other.gameObject);
        }
    }

    private void TryRemoveEnemy(Collider2D other)
    {
        if(MatchUp(_enemies, other.gameObject) == true) 
        {
            _enemies.Remove(other.gameObject);
        }
    }

    protected void ReSize (float value)
    {
        transform.localScale = new Vector3(value, value, 0.0f);
    }
}