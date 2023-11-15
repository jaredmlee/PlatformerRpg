using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogsTrigger : MonoBehaviour
{
    public GameObject log;
    public Transform spawnLogs;

    private bool triggered = false;
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
            Instantiate(log, spawnLogs.position, spawnLogs.rotation);
        }
    }
}
