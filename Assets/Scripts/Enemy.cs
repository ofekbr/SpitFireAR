using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health)), RequireComponent(typeof(Combat))]
public class Enemy : Interactable
{
    private PlayerManager playerManager;
    private Health myHealth;
    private Combat combat;

    private void Start() {
        playerManager = PlayerManager.instance;
        myHealth = GetComponent<Health>();
        combat = GetComponent<Combat>();
        combat.OnAttack += HandleAttack;
    }

    public override void Interact()
    {
        base.Interact();

        Attack();
    }

    private void Attack()
    {
        Combat combat = GetComponent<Combat>();
        if (combat != null)
        {
            combat.Attack();
        }
    }

    private void HandleAttack(GameObject opponent)
    {
        // Add visual effects for attack
        // Play sounds
    }
}
