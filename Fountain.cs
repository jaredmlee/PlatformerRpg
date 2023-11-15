using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : MonoBehaviour
{
    public GameObject player;
    public DialogueTrigger message;
    public Animator animator;

    bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("Activated", true);
            player.GetComponent<Player_script>().hasKey = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered && collision.name == "Player")
        {
            triggered = true;
            message.TriggerDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            triggered = false;
        }
    }
}
