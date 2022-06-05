using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private List<Transform> _points;
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private int _delayRelocate = 1;
    [SerializeField] private int _valueAtOnce = 3;
    [SerializeField] private int _value = 3;
    [SerializeField] private bool _isSpawnAllTime = true;

    private void Start() 
    {
        StartCoroutine(Relocate(_delayRelocate));
    }

    private void Spawn (Transform spawnPoint, int value)
    {
        for (int i = 0; i < value; i++)
        {
            Vector3 tempSpawnPoistion = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z);
            Enemy tempEnemy = Instantiate(_enemies[Random.Range(0, _enemies.Count)], tempSpawnPoistion, Quaternion.identity);
            tempEnemy.AssignTarget(_player);
        }
    }

    private IEnumerator Relocate (int delay)
    {
        while (true)
        {
            for (int i = 0; i < _value; i++)
            {
                yield return new WaitForSeconds(delay);

                switch (Random.Range(0,4))
                    {
                        case 0:
                        _spawnPoint.transform.position = new Vector3(_points[0].position.x, Random.Range(_points[0].position.y, _points[1].position.y), 0);
                        break;
                        case 1:
                        _spawnPoint.transform.position = new Vector3(Random.Range(_points[1].position.x, _points[2].position.x), _points[1].position.y, 0);
                        break;
                        case 2:
                        _spawnPoint.transform.position = new Vector3(_points[2].position.x, Random.Range(_points[2].position.y, _points[3].position.y), 0);
                        break;
                        case 3:
                        _spawnPoint.transform.position = new Vector3(Random.Range(_points[0].position.x, _points[3].position.x), _points[3].position.y, 0);
                        break;
                    }

                Spawn(_spawnPoint.transform, _valueAtOnce);
            } 
        }
    }
}