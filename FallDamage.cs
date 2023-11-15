using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    public float changey = 3f;
    public float changex = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            collision.GetComponent<Player_script>().takeDamage(10);
            Vector3 currentPosition = collision.transform.position;
            currentPosition.y += changey;
            currentPosition.x -= changex;
            collision.transform.position = currentPosition;
        }
    }
}
