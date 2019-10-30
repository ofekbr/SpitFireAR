using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health)), RequireComponent(typeof(Power))]
public class Combat : MonoBehaviour
{
    public event Action OnAttack = delegate {}; // callback delegate to notify on attack - can be used , for example, to setup animation
    public float attackSpeed = 1f;
    public float attackDelay = 0.6f;
    private float attackCooldown = 0f; // time in seconds in which the enxt attack will take place
    private Transform target;
    private Health myHealth;
    private Power myPower;
    

    private void Start()
    {
        target = PlayerManager.instance.player.transform;
        myHealth = GetComponent<Health>();
        myPower = GetComponent<Power>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }
    public void Attack(Health opponentHealth)
    {
        if (attackCooldown <= 0 && IsInRange())
        {
            StartCoroutine(DoDamage(opponentHealth, attackDelay));

            if (OnAttack != null) 
            {
                OnAttack();
            }

            attackCooldown = 1f / attackSpeed;
        }
    }

    private bool IsInRange()
    {
        Vector3 directionToTarget = transform.position - target.position;
        float angle = Vector3.Angle(transform.forward, directionToTarget);

        bool inRange = (Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270);
        return inRange;
    }

    private IEnumerator DoDamage(Health opponentHealth, float delay)
    {
        yield return new WaitForSeconds(delay);

        opponentHealth.ModifyHealth(-1 * myPower.damage);
    }
}
