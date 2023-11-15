using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    private float nextChangeTime = 0f;
    public float ChangeCoolDown = 0.5f;
    public float speed = 1f;
    public string type = "vertical";
    private bool change = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextChangeTime)
        {
            nextChangeTime = Time.time + 1f / ChangeCoolDown;
            change = !change;
        }
        if (change)
        {
            if (type == "vertical")
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
        else
        {
            if (type == "vertical")
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
    }
}
