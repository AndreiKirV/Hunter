using UnityEngine;

public class StatsSheet : MonoBehaviour
{
    private int _strength;
    private int _masteryOfRanged;
    private int _agility; 
    private int _militaryLuck;
    private int _luck;
    private int _marksmanship;

    public int Strength => _strength;
    public int MasteryOfRanged => _masteryOfRanged;
    public int Agility => _agility;
    public int MilitaryLuck => _militaryLuck;
    public int Luck => _luck;
    public int Marksmanship => _marksmanship;

    public StatsSheet(int strength, int masteryOfRanged, int agility, int militaryLuck, int luck, int marksmanship)
    {
        _strength = strength;
        _masteryOfRanged = masteryOfRanged;
        _agility = agility;
        _militaryLuck = militaryLuck;
        _luck = luck;
        _marksmanship = marksmanship;
    }

    public void ShowStates ()
    {
        string tempString = ($"{_strength} + {_masteryOfRanged} + {_agility} + {_militaryLuck} + {_luck} + {_marksmanship}");
        Debug.Log(tempString);
    }
}