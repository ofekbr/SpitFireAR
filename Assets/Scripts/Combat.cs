﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(Health)), RequireComponent(typeof(Power))]
public class Combat : MonoBehaviour
{
    public event Action<GameObject> OnAttack = delegate { }; // callback delegate to notify on attack - can be used , for example, to setup animation
    public float attackSpeed = 1f;
    public float attackDelay = 0.6f;
    private float attackCooldown = 0f; // time in seconds in which the enxt attack will take place
    private Transform target;
    private Health myHealth;
    private Power myPower;
    private bool isEnemy;
    private bool isPlayer;
    private ARSessionOrigin aRSessionOrigin;


    private void Start()
    {
        myHealth = GetComponent<Health>();
        myPower = GetComponent<Power>();

        isEnemy = GetComponent<Enemy>() != null;
        isPlayer = GetComponent<Player>() != null;

        aRSessionOrigin = FindObjectOfType<ARSessionOrigin>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }
    public void Attack()
    {
        if (attackCooldown <= 0)
        {
            GameObject opponent = OpponentInRange();

            if (opponent != null && IsFoe(opponent))
            {
                Health opponentHealth = opponent.GetComponent<Health>();
                StartCoroutine(DoDamage(opponentHealth, attackDelay));

                if (OnAttack != null)
                {
                    OnAttack(opponent);
                }
            }

            attackCooldown = 1f / attackSpeed;
        }
    }

    public bool IsFoe(GameObject opponent)
    {
        bool isOpponentEnemy = opponent.GetComponent<Enemy>() != null;
        bool isOpponentPlayer = opponent.GetComponent<Player>() != null;
        return (isEnemy && isOpponentPlayer) || (isPlayer && isOpponentEnemy);
    }

    private GameObject OpponentInRange()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, myPower.maxDistance))
        {
            return hit.collider.gameObject;
        }
        return null;
    }

    private IEnumerator DoDamage(Health opponentHealth, float delay)
    {
        yield return new WaitForSeconds(delay);

        opponentHealth.ModifyHealth(-1 * myPower.damage);
    }
}
