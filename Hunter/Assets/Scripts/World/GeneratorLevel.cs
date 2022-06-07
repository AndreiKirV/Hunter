using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorLevel : MonoBehaviour
{
    [SerializeField] private int _sizeX;
    [SerializeField] private int _sizeY;
    [SerializeField] private int _noColisionCompleteChance;

    public int SizeX => _sizeX;
    public int SizeY => _sizeY;
    public int NoColisionCompleteChance => _noColisionCompleteChance;
}