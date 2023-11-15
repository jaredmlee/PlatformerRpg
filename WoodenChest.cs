using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenChest : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public GameObject potion;
    public DialogueTrigger trigger;

    private bool triggered = false;
    private bool hasOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered && Input.GetKeyDown(KeyCode.E) && !hasOpened)
        {
            {
                trigger.TriggerDialogue();
                animator.SetBool("isOpened", true);
                player.GetComponent<Player_script>().numHealthPotions += 1;
                hasOpened = true;
                potion.SetActive(true);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            triggered = true;
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
