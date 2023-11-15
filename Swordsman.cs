using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordsman : MonoBehaviour
{
    public Transform player;
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    public bool isAlive = true;
    public Transform attackPoint;
    public LayerMask playerLayers;
    public float attackRange = 0.6f;
    public int attackDamage = 20;
    public bool isFlipped = false;
    public float runCoolDown = 0.2f;
    public int xpDrop = 10;

    private float nextRunTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, gameObject.transform.position);
        if (distance <= 3 && distance >=1)
        {
            if (Time.time >= nextRunTime)
            {
                animator.SetBool("run", true);
                FindObjectOfType<AudioManager>().play("Run");
                nextRunTime = Time.time + 1f / runCoolDown;
            }
        }
        //maybe try this again some day - make the swordsmans run away when close
        //if (distance <= 1)
        //{
        //    transform.position += Vector3.right * Time.deltaTime;
        //animator.SetBool("run", true);
        // }

        if (currentHealth <= 0)
        {
            Die();
        }
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
        Debug.Log("DIE!!!!!");
        isAlive = false;
        //Die Animation
        animator.SetBool("IsDead", true);
        player.GetComponent<Player_script>().experience += xpDrop;
        //Disable the Collider
        GetComponent<Collider2D>().enabled = false;
        //Disable the enemy
        this.enabled = false;
    }

    public void Attack()
    {
        FindObjectOfType<AudioManager>().play("Slash");
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
    public void stopRunning()
    {
        animator.SetBool("run", false);
    }

}