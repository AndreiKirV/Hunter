using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private int _delayRelocate = 1;
    [SerializeField] private List<Enemy> _enemies;
    
    private bool _isSpawn = true;

    private void Start() 
    {
        StartCoroutine(Relocate(_delayRelocate));
    }

    private void Spawn (Transform spawnPoint)
    {
        Vector3 tempSpawnPoistion = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z);
        Instantiate(_enemies[Random.Range(0, _enemies.Count)], tempSpawnPoistion, Quaternion.identity);
    }

    private IEnumerator Relocate (int delay)
    {
       while (_isSpawn == true)
       {
           yield return new WaitForSeconds(delay);

           switch (Random.Range(0,5))
           {
                case 1:
                _spawnPoint.transform.position = new Vector3(_points[0].position.x, Random.Range(_points[0].position.y, _points[1].position.y), 0);
                break;
                case 2:
                _spawnPoint.transform.position = new Vector3(Random.Range(_points[1].position.x, _points[2].position.x), _points[1].position.y, 0);
                break;
                case 3:
                _spawnPoint.transform.position = new Vector3(_points[2].position.x, Random.Range(_points[2].position.y, _points[3].position.y), 0);
                break;
                case 4:
                _spawnPoint.transform.position = new Vector3(Random.Range(_points[0].position.x, _points[3].position.x), _points[3].position.y, 0);
                break;
           }

           Spawn(_spawnPoint.transform);
       }
    }
}