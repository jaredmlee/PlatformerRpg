using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterSwim : MonoBehaviour
{
    public GameObject player;
    public float swimStrength = 2f;

    private bool swimming;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && swimming)
        {
            player.transform.position += Vector3.up * swimStrength *  Time.deltaTime;
        }
        if (swimming)
        {
            player.transform.position += Vector3.down  * Time.deltaTime;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            swimming = false;
            collision.GetComponent<Rigidbody2D>().gravityScale = 1f;
            collision.GetComponent<Player_script>().jumpNotAllowed = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            swimming = true;
            collision.GetComponent<Rigidbody2D>().gravityScale = 0f;
            collision.GetComponent<Player_script>().jumpNotAllowed = true;
        }
    }
}
