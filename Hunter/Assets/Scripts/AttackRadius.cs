using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRadius : ViewingRadius
{
    private Player _player;

    private void Start() 
    {
        _player = transform.parent.gameObject.GetComponent<Player>();
        ReSize(_player.CurrentWeapon.RangeOfAttack);
    }
}
