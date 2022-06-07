using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class TileRandomizator : MonoBehaviour
{
    [Header("compulsory facilities")]
    [SerializeField] private List<Tile> _tiles;

    [Header("optional objects")]
    [SerializeField] private List<Tile> _optionalTiles;
    [SerializeField] private int _chanceOfOptionalObjects;

    private int _maxChanceOfOptionalObjects = 100;
    private int _valueX;
    private int _valueY;
    private GeneratorLevel _settingsMap;

    private Tilemap _map;

    private void Start()
    {
        AssignStartingValues();
        _map = GetComponent<Tilemap>();
        AssignPosition(-_valueY / 2, -_valueX / 2);
        Generate();
    }   

    private void Update() 
    {
    }

    private void Generate()
    {
        if (TryGetComponent(out NoCollision noCollision) && _settingsMap.NoColisionCompleteChance > 0)
        {
            
        }
        else
        {
            FillOutMap();
        }
    }

    private bool GiveResultChance()
    {
        int tempResult = Random.Range(0, _maxChanceOfOptionalObjects + 1);

        if (_chanceOfOptionalObjects - 1 >= tempResult && _optionalTiles.Count > 0)
            return true;
        else
            return false;
    }

    private void AssignStartingValues()
    {
        _settingsMap = transform.parent.gameObject.GetComponent<GeneratorLevel>();
        _valueX = _settingsMap.SizeX;
        _valueY = _settingsMap.SizeY;
    }

    private void AssignPosition(int valueY, int valueX)
    {
        _map.transform.position = new Vector3(valueY, valueX, 0);
    }

    private void FillOutMap()
    {
        for (int i = 0; i < _valueY; i++)
        {
            for (int j = 0; j < _valueX; j++)
            {
                if (GiveResultChance() == true)
                    _map.SetTile(new Vector3Int(i,j,0), _optionalTiles[Random.Range(0, _optionalTiles.Count)]);
                else
                    _map.SetTile(new Vector3Int(i,j,0), _tiles[Random.Range(0, _tiles.Count)]);
            }
        }
    }
}