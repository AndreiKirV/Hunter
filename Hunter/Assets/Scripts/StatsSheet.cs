using UnityEngine;

public class StatsSheet : MonoBehaviour
{
    private int _strength;
    private int _masteryOfRanged;
    private int _agility; 
    private int _militaryLuck;
    private int _luck;

    public StatsSheet(int strength, int masteryOfRanged, int agility, int militaryLuck, int luck)
    {
        _strength = strength;
        _masteryOfRanged = masteryOfRanged;
        _agility = agility;
        _militaryLuck = militaryLuck;
        _luck = luck;
    }
}