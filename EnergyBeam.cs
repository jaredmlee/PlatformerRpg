using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBeam : MonoBehaviour
{
    public Transform player;
    public float speed = 10f;
    public int damage = 20;
    public Rigidbody2D rb;
    public GameObject hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Archer archer = collision.GetComponent<Archer>();
        Swordsman swordsman = collision.GetComponent<Swordsman>();
        FireWizard fireWizard = collision.GetComponent<FireWizard>();
        Worm worm = collision.GetComponent<Worm>();
        if (archer != null)
        {
            archer.TakeDamage(damage);
        }
        if (swordsman != null)
        {
            swordsman.TakeDamage(damage);
        }
        if (fireWizard != null)
        {
            fireWizard.TakeDamage(damage);
        }
        if (worm != null)
        {
            worm.TakeDamage(damage);
        }

        if (collision.name != "Player" && collision.transform.parent.name != "Player" && !collision.isTrigger)
        {
            Instantiate(hitEffect, collision.transform.position, collision.transform.rotation);
            Destroy(gameObject);
        }
    }
}
