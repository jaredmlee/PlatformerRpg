using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1ConditionalDialogue : MonoBehaviour
{
    public GameObject wizard;
    public GameObject Key;
    public DialogueTrigger trigger;
    private bool beenTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!beenTriggered && !wizard.GetComponent<FireWizard>().isAlive && collision.name == "Player")
        {
            trigger.TriggerDialogue();
            beenTriggered = true;
            Key.SetActive(true);
        }
    }
}
