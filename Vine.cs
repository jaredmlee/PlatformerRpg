using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{
    bool isInside = false;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isInside)
        {
            player.GetComponent<Player_script>().climbVine();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "VineCheck")
        {
            isInside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInside = false;
        player.GetComponent<Player_script>().resumeNormalMovement(player.GetComponent<Rigidbody2D>());
    }
}
