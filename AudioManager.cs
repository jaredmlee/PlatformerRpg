using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject player;
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            play("Menu");
        }
        else if (player.GetComponent<Player_script>().level == 1)
        {
            play("Lv1Music");
        }
        else if (player.GetComponent<Player_script>().level == 2)
        {
            play("Lv2Music");
        }
        else if (player.GetComponent<Player_script>().level == 3)
        {
            play("Level3Music");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Play();
    }
}
