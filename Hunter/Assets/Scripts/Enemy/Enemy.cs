using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    //[SerializeField] private int _reward; награда за персонажа в денежном и опытном еквиваленте
    [SerializeField] private Player _target;

    public Player Target => _target;

    public void TakeDamage(int damage)
    {

    }


}
