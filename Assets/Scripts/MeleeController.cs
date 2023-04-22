using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour
{
    [SerializeField]
    Transform attackPoint;

    [SerializeField]
    float attackRadius;

    [SerializeField]
    float damage;

    //1. CORTAR Y HACER LAS ANIMACIONES DE IDLE, WALK, ATTACK, DIE DEL NUEVO SPRITE SHEET (25 PUNTOS)
    //2. AGREGAR ATTACK TIMES PER SECOND (25 PUNTOS)


    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("melee");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    public void OnAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius);

        foreach(Collider2D collider in colliders)
        {
            HealthController healthController = collider.GetComponent<HealthController>();
            if (healthController != null)
            {
                healthController.TakeDamage(damage);
            }
        }
    }

    
}
