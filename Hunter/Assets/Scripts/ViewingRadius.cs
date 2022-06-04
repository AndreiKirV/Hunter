using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ViewingRadius : MonoBehaviour
{
    [SerializeField] private Player _player;

    private List<GameObject> _enemies = new List<GameObject>();

    private void Start() 
    {
        ReSize(_player.Marksmanship);
    }

    private void Update() 
    {
        IncreaseSize(0.1f);
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        TryAddEnemy(other);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        TryRemoveEnemy(other);
    }

    public void IncreaseSize (float value)
    {   
        Vector3 tempLocalScale = transform.localScale;

        if ((tempLocalScale.x -= value) >= 0)
        {
            transform.localScale -= new Vector3(value, value, 0.0f);
            Debug.Log($"Уменьшена дальность поля зрения на {value}, тепер поле зрения равна {transform.localScale}");
        }
        else
            Debug.Log($"Уменьшена дальность поля зрения на {value}, тепер поле зрения равна {transform.localScale}");
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
            Debug.Log("Объект добавлен");
        }
    }

    private void TryRemoveEnemy(Collider2D other)
    {
        if(MatchUp(_enemies, other.gameObject) == true) 
        {
            _enemies.Remove(other.gameObject);
            Debug.Log(other + "удален" + "В поле видимости " + _enemies.Count + "врагов");
        }
    }

    private void ReSize (float value)
    {
        transform.localScale = new Vector3(value, value, 0.0f);
    }
}