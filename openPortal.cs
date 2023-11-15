using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openPortal : MonoBehaviour
{
    public GameObject portal;
    public GameObject boss;

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
       bool isAlive = boss.GetComponent<BoxCollider2D>().isActiveAndEnabled;
        if (!isAlive && !triggered && collision.name == "Player")
        {
            triggered = true;
            portal.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
