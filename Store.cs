using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public static bool storeOnScreen = false;
    public GameObject storeMenuUI;
    public GameObject player;
    public GameObject openS;
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
        if (openS == null)
        {
            openS = GameObject.FindGameObjectWithTag("storeTrigger");
        }
        if (openS == null)
        {
            return;
        }
        if (openS.GetComponent<openStore>().open && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("hi");
            if (storeOnScreen)
            {
                resume();
            }
            else
            {
                openStore();
            }
            openS.GetComponent<openStore>().open = false;
        }
    }

    public void resume()
    {
        storeMenuUI.SetActive(false);
        Time.timeScale = 1f;
        storeOnScreen = false;
    }
    public void openStore()
    {
        storeMenuUI.SetActive(true);
        Time.timeScale = 0f;
        storeOnScreen = true;
    }

    public void buyHealthPotion()
    {
        int coins = player.GetComponent<Player_script>().numCoins;
        if (coins >= 10)
        {
            player.GetComponent<Player_script>().numCoins -= 10;
            player.GetComponent<Player_script>().numHealthPotions += 1;
        }
    }

    public void buyMannaPotion()
    {
        int coins = player.GetComponent<Player_script>().numCoins;
        if (coins >= 25)
        {
            player.GetComponent<Player_script>().numCoins -= 25;
            player.GetComponent<Player_script>().numMannaPotions += 1;
        }
    }
}
