using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public int damage = 5; // set with positive value - our combat function will handle reversing the sign for modifying the opponent's health
    private int defaultDamage;

    private void Start()
    {
        defaultDamage = damage;
    }

    public void UpdateDamage(int newDamage)
    {
        damage = newDamage;
    }
}
