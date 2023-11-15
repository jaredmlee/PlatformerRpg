using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerObjectDialogue : MonoBehaviour
{
   public  DialogueTrigger trigger;
    private bool beenTriggered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!beenTriggered && collision.name == "Player")
        {
            trigger.TriggerDialogue();
            beenTriggered = true;
        }
    }
}
