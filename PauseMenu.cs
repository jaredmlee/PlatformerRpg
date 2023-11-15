using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public Player_script player;
    public GameObject resetConfirm;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_script>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            resetGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }
    public void resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void quitGame()
    {
        Debug.Log("quitting game");
        Application.Quit();
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(player);
    }

    public void resetGame()
    {
        player.level = 1;
        player.currentHealth = 200;
        player.manna = 0;
        player.currentShield = 15;
        player.maxHealth = 200;
        player.sheildDurability = 15;
        player.maxManna = 100;
        player.numCoins = 0;
        player.numHealthPotions = 0;
        player.numMannaPotions = 0;
        player.experience = 0;
        player.learnedEnergy = false;
        player.attackDamage = 20;
        player.attackSpeed = 0.5f;
        SavePlayer();
        mainMenu();
    }

    public void openResetConfirmation()
    {
        resetConfirm.SetActive(true);
    }
    public void mainMenu()
    {
        resume();
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.FindGameObjectWithTag("CineMachine"));
        Destroy(GameObject.FindGameObjectWithTag("canvas"));
        Destroy(GameObject.FindGameObjectWithTag("dialogueManager"));
        SceneManager.LoadScene(0);
    }
}
