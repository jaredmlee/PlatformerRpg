using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AttatchPlayer : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.Follow == null)
        {
            cam.Follow = GameObject.FindGameObjectWithTag("player").transform;
        }
    }
}
