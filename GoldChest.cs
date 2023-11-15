using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldChest : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public GameObject potion;
    public GameObject coins;
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
                Debug.Log("open chest function called");
                trigger.TriggerDialogue();
                animator.SetBool("isOpened", true);
                player.GetComponent<Player_script>().numMannaPotions += 1;
                player.GetComponent<Player_script>().numCoins += 15;
                hasOpened = true;
                potion.SetActive(true);
                coins.SetActive(true);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ontriggerendter2d worked");
        Debug.Log(collision.name);
        if (collision.name == "Player")
        {
            Debug.Log("Triggered set to true;");
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
