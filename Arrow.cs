using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 0.1f;
    public Rigidbody2D rb;
    public GameObject hitEffect;
    public int attackDamage = 15;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed * -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player_script player = collision.GetComponent<Player_script>();
        if (player != null)
        {
            player.takeDamage(attackDamage);
        }
        //later, make it so there is a good effect when the arrow hits
        //Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }


}
