using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logScript : MonoBehaviour
{
    private bool beenHit = false;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && !beenHit)
        {
            beenHit = true;
            collision.gameObject.GetComponent<Player_script>().takeDamage(10);
        }
    }
}
