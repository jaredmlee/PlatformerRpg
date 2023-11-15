using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryChangeNums : MonoBehaviour
{
    public Text healthPotionsCount;
    public Text mannaPotionsCount;
    public Text coinsCount;
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
        int potions = player.GetComponent<Player_script>().numHealthPotions;
        int mannaPotions = player.GetComponent<Player_script>().numMannaPotions;
        int coins = player.GetComponent<Player_script>().numCoins;
        changeHealthNum(potions);
        changeMannaNum(mannaPotions);
        changeCoinNum(coins);
    }
    public void changeHealthNum(int numPotions)
    {
        healthPotionsCount.text = numPotions.ToString();
    }

    public void changeMannaNum(int numPotions)
    {
        mannaPotionsCount.text = numPotions.ToString();
    }

    public void changeCoinNum(int coins)
    {
        coinsCount.text = coins.ToString();
    }
}
