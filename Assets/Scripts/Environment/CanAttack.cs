using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanAttack : MonoBehaviour
{
    public int enemyStrength;
    public Animator animator;
    public float enemyCooldown = 1;
    public float damage = 1;
    private bool canAttack = true;
 
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("hurt");
            PlayerMovement playerMovementComponent = GameObject.Find("Player").GetComponent<PlayerMovement>();
            playerMovementComponent.takeDamage(enemyStrength);
            animator.SetTrigger("Attack 01");
            StartCoroutine(AttackCooldown());
        }
    }

    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(enemyCooldown);
        canAttack = true;
    }
}
