using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsChangeNums : MonoBehaviour
{
    public Text maxHealth;
    public Text HealthUpgradeCost;
    public Text AttackPower;
    public Text AttackPowerCost;
    public Text AttackSpeed;
    public Text AttackSppedCost;
    public Text ShieldDurability;
    public Text ShieldDurabilityCost;
    public GameObject player;

    private int healthUpgradeCost = 50;
    private int attackPowerUpgradeCost = 50;
    private int attackSpeedUpgradeCost = 50;
    private int shieldDurabilityUpgradeCost = 50;
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
    }
    public void changeHealthNum(int health)
    {
        maxHealth.text = health.ToString();
        player.GetComponent<Player_script>().setMaxHealth();
    }

    public void upgradeHealth()
    {
        if (player.GetComponent<Player_script>().experience >= healthUpgradeCost)
        {
            player.GetComponent<Player_script>().experience -= healthUpgradeCost;
            healthUpgradeCost += 10;
            player.GetComponent<Player_script>().maxHealth += 20;
            int health = player.GetComponent<Player_script>().maxHealth;
            changeHealthNum(health);
            HealthUpgradeCost.text = "Cost - " +healthUpgradeCost.ToString()+"xp";
        }
    }

    public void upgradeAttackPower()
    {
        if (player.GetComponent<Player_script>().experience >= attackPowerUpgradeCost)
        {
            player.GetComponent<Player_script>().experience -= attackPowerUpgradeCost;
            attackPowerUpgradeCost += 10;
            player.GetComponent<Player_script>().attackDamage += 2;
            AttackPower.text = player.GetComponent<Player_script>().attackDamage.ToString();
            AttackPowerCost.text = "Cost - " + attackPowerUpgradeCost.ToString() + "xp";
        }
    }

    public void upgradeAttackSpeed()
    {
        if (player.GetComponent<Player_script>().experience >= attackSpeedUpgradeCost && player.GetComponent<Player_script>().attackSpeed<=2)
        {
            player.GetComponent<Player_script>().experience -= attackSpeedUpgradeCost;
            attackSpeedUpgradeCost += 10;
            player.GetComponent<Player_script>().attackSpeed += 0.1f;
            AttackSpeed.text = player.GetComponent<Player_script>().attackSpeed.ToString();
            AttackSppedCost.text = "Cost - " + attackSpeedUpgradeCost.ToString() + "xp";
        }
        else if (player.GetComponent<Player_script>().attackSpeed > 2)
        {
            AttackSppedCost.text = "Maxed!";
        }
    }

    public void upgradeShieldDurability()
    {
        if (player.GetComponent<Player_script>().experience >= shieldDurabilityUpgradeCost)
        {
            player.GetComponent<Player_script>().experience -= shieldDurabilityUpgradeCost;
            shieldDurabilityUpgradeCost += 10;
            player.GetComponent<Player_script>().sheildDurability += 10;
            ShieldDurability.text = player.GetComponent<Player_script>().sheildDurability.ToString();
            ShieldDurabilityCost.text = "Cost - " + shieldDurabilityUpgradeCost.ToString() + "xp";
            player.GetComponent<Player_script>().setMaxSheildDurability();
        }
    }
}
