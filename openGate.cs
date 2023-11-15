using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openGate : MonoBehaviour
{
    public GameObject player;
    public GameObject gate;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (player.GetComponent<Player_script>().hasKey && collision.name == "Player")
        {
            gate.SetActive(false);
        }
    }
}
