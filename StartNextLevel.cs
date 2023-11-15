using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNextLevel : MonoBehaviour
{
    public Animator animator;
    public Player_script player;
    public GameObject loadingScreen;
    public GameObject controlsTutorial;
    public Transform SpawnPoint;


    private void Start()
    {
        try
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_script>();
            SpawnPoint = GameObject.FindGameObjectWithTag("spawnPoint").transform;
        }
         catch(System.NullReferenceException ex)
        {
            Debug.Log("I just want these errors to shut up" + ex);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.GetComponent<Player_script>().level += 1;
            SavePlayer();
            StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex + 1, collision.gameObject));
            /*DontDestroyOnLoad(collision);
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("CineMachine"));
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("canvas"));
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("dialogueManager"));
            collision.GetComponent<Player_script>().setBarsNextLevel();
            collision.transform.position = new Vector3(0, -0.7f, 0);*/
        }
    }

    IEnumerator loadLevel(int levelIndex, GameObject collision)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelIndex);
        if (collision != null)
        {
            DontDestroyOnLoad(collision);
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("CineMachine"));
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("canvas"));
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("dialogueManager"));
            collision.GetComponent<Player_script>().setBarsNextLevel();
            collision.transform.position = SpawnPoint.position;
        }
        if (loadingScreen!=null)
            loadingScreen.SetActive(false);
    }

    public void PlayGame()
    {
        StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex + 1, null));
    }

    public void backToMenu()
    {
        Time.timeScale = 1f;
        StartCoroutine(loadLevel(0, null));
    }

    public void LoadSave()
    {

        PlayerData data = SaveSystem.LoadPlayer();
        player.currentHealth = data.health;
        player.manna = data.manna;
        player.level = data.level;
        player.currentShield = data.shieldDurrability;
        player.maxHealth = data.maxHealth;
        player.sheildDurability = data.maxShield;
        player.maxManna = data.maxManna;
        player.numCoins = data.coins;
        player.numHealthPotions = data.healthPotions;
        player.numMannaPotions = data.mannaPotions;
        player.experience = data.xp;
        player.learnedEnergy = data.learnedEnergy;
        player.attackDamage = data.attackDamage;
        player.attackSpeed = data.attackSpeed;
        if (player.level >= 2)
        {
            loadingScreen.SetActive(true);
            StartCoroutine(loadLevel(player.level, GameObject.FindGameObjectWithTag("Player")));
        }
        else
        {
            controlsTutorial.SetActive(true);
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(player);
    }
}