using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveGame : MonoBehaviour
{
    private bool triggered = false;
    public Transform spawn;
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
        if (collision.name == "Player" && !triggered)
        {
            triggered = true;
            spawn.position = gameObject.transform.position;
        }
    }
}
