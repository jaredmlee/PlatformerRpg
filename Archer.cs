using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public Transform player;
    public Animator animator;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public int maxHealth = 100;
    int currentHealth;
    public bool isAlive = true;
    public bool isFlipped = false;
    // Start is called before the first frame update
    void Start()
    {
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
        player.GetComponent<Player_script>().experience += 15;
        //Disable the Collider
        GetComponent<Collider2D>().enabled = false;
        //Disable the enemy
        this.enabled = false;

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

    public void attack()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
