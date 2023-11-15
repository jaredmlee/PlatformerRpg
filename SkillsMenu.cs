using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsMenu : MonoBehaviour
{
    public static bool skillsOnScreen = false;
    public GameObject skillsMenuUI;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (skillsOnScreen)
            {
                resume();
            }
            else
            {
                openSkills();
            }
        }
    }

    public void resume()
    {
        skillsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        skillsOnScreen = false;
    }
    public void openSkills()
    {
        skillsMenuUI.SetActive(true);
        Time.timeScale = 0f;
        skillsOnScreen = true;
    }
}
