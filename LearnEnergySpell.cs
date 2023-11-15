using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnEnergySpell : MonoBehaviour
{
    public DialogueTrigger trigger;
    public GameObject player;
    private bool beenTriggered = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!beenTriggered && collision.name == "Player" && player.GetComponent<Player_script>().hasKey == true)
        {
            trigger.TriggerDialogue();
            beenTriggered = true;
            player.GetComponent<Player_script>().learnedEnergy = true;
        }
    }
}
