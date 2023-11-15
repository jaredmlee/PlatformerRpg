using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Transform spawn;
    public GameObject player;
    public void restartGame()
    {
        gameOverScreen.SetActive(false);
        spawn = GameObject.FindGameObjectWithTag("spawnPoint").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = spawn.position; 
        player.GetComponent<Player_script>().enabled = true;
        player.GetComponent<Player_script>().repsawn();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
