using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openStore : MonoBehaviour
{
    public bool open = false;
    public DialogueTrigger trigger;
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
        if (collision.name == "Player")
        {
            trigger.TriggerDialogue();
            open = true;
        }
    }
}
