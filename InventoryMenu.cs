using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{

    public static bool inventoryOnScreen = false;
    public GameObject inventoryMenuUI;
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
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (inventoryOnScreen)
            {
                resume();
            }
            else
            {
                openInventory();
            }
        }
    }

    public void resume()
    {
        inventoryMenuUI.SetActive(false);
        Time.timeScale = 1f;
        inventoryOnScreen = false;
    }
    public void openInventory()
    {
        inventoryMenuUI.SetActive(true);
        Time.timeScale = 0f;
        inventoryOnScreen = true;
    }

    public void useHealthPotion()
    {
        int potions = player.GetComponent<Player_script>().numHealthPotions;
        int maxHealth = player.GetComponent<Player_script>().maxHealth;
        if (potions > 0)
        {
            player.GetComponent<Player_script>().numHealthPotions -= 1;
            player.GetComponent<Player_script>().currentHealth = maxHealth;
            player.GetComponent<Player_script>().setMaxHealth();
        }
    }

    public void useMannaPotion()
    {
        int potions = player.GetComponent<Player_script>().numMannaPotions;
        int maxManna = player.GetComponent<Player_script>().maxManna;
        if (potions > 0)
        {
            player.GetComponent<Player_script>().numMannaPotions -= 1;
            player.GetComponent<Player_script>().manna += maxManna;
            player.GetComponent<Player_script>().setMaxManna();
        }
    }
}
