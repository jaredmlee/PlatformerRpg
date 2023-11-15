using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRepair : MonoBehaviour
{
    public GameObject player;
    public DialogueTrigger trigger;

    private bool triggered = false;
    private bool hasRepaired = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered && Input.GetKeyDown(KeyCode.E) && !hasRepaired)
        {
            {
                player.GetComponent<Player_script>().setMaxSheildDurability();
                hasRepaired = true;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            if (!hasRepaired)
            {
                trigger.TriggerDialogue();
            }
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
