using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreChangeCoins : MonoBehaviour
{
    public Text coinsCount;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        int coins = player.GetComponent<Player_script>().numCoins;
        coinsCount.text = coins.ToString();
    }
}
