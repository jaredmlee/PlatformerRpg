using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWizard : MonoBehaviour
{
    //public MannaBar mannaBar;
    public GameObject projectile;
    public Transform player;
    public Animator animator;
    public int maxHealth = 150;
    int currentHealth;
    public bool isAlive = true;
    public Transform attackPoint;
    public LayerMask playerLayers;
    public float attackRange = 1f;
    public int attackDamage = 30;
    public bool isFlipped = false;
    public float speed = 0.5f;
    public float runCoolDown = 0.1f;

    private float nextRunTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (Time.time >= nextRunTime && distance <= 2)
        {
            animator.SetBool("run", true);
            nextRunTime = Time.time + 1f / runCoolDown;
        }
    }

    public void stopRunning()
    {
        Debug.Log("Stop running!");
        animator.SetBool("run", false);
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
    public void Attack()
    {
        if (projectile != null)
        {
            Instantiate(projectile, attackPoint.position, attackPoint.rotation);
        }
        FindObjectOfType<AudioManager>().play("Fire");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<Player_script>().isAlive)
            {
                enemy.GetComponent<Player_script>().takeDamage(attackDamage);

            }
        }
    }
    public void TakeDamage(int damage)
    {
        FindObjectOfType<AudioManager>().play("Damaged");
        currentHealth -= damage;

        //play hurt animation
        animator.SetTrigger("hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isAlive = false;
        //Die Animation
        animator.SetBool("isDead", true);
        player.GetComponent<Player_script>().manna += 15;
        if (player.GetComponent<Player_script>().manna > player.GetComponent<Player_script>().maxManna)
        {
            player.GetComponent<Player_script>().manna = player.GetComponent<Player_script>().maxManna;
        }
        //mannaBar.SetManna(player.GetComponent<Player_script>().manna);
        player.GetComponent<Player_script>().experience += 40;
        //Disable the Collider
        GetComponent<Collider2D>().enabled = false;
        //Disable the enemy
        this.enabled = false;
    }
}
