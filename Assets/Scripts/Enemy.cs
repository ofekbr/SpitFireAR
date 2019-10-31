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
        Combat combat = playerManager.player.GetComponent<Combat>();

        if (combat != null)
        {
            combat.Attack(myHealth);
        }
    }

    private void HandleAttack()
    {
        // Add visual effects for attack
        // Play sounds
    }
}
