using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour
{
    public Transform player;
    public Animator animator;
    public int maxHealth = 40;
    int currentHealth;
    public bool isAlive = true;
    public Transform attackPoint;
    public LayerMask playerLayers;
    public float attackRange = 0.5f;
    public int attackDamage = 5;
    public bool isFlipped = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        FindObjectOfType<AudioManager>().play("Damaged");
        currentHealth -= damage;

        //play hurt animation
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isAlive = false;
        //Die Animation
        animator.SetBool("IsDead", true);
        player.GetComponent<Player_script>().experience += 2;
        //Disable the Collider
        GetComponent<Collider2D>().enabled = false;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1f;
        rb.constraints = rb.constraints & ~RigidbodyConstraints2D.FreezePositionY;
        //Disable the enemy
        this.enabled = false;
    }
    public void Attack()
    {
        FindObjectOfType<AudioManager>().play("GrossAttack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<Player_script>().isAlive)
            {
                enemy.GetComponent<Player_script>().takeDamage(attackDamage);

            }
        }
    }

    public void lookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}

