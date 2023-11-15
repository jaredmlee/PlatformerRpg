using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int health;
    public int manna;
    public int shieldDurrability;
    public int level = 1;
    public int maxHealth;
    public int maxShield;
    public int maxManna;
    public int coins;
    public int healthPotions;
    public int mannaPotions;
    public int xp;
    public bool learnedEnergy;
    public int attackDamage;
    public float attackSpeed;

    public PlayerData (Player_script player)
    {
        health = player.currentHealth;
        manna = player.manna;
        level = player.level;
        shieldDurrability = player.currentShield;
        maxHealth = player.maxHealth;
        maxShield = player.sheildDurability;
        maxManna = player.maxManna;
        coins = player.numCoins;
        healthPotions = player.numHealthPotions;
        mannaPotions = player.numMannaPotions;
        xp = player.experience;
        learnedEnergy = player.learnedEnergy;
        attackDamage = player.attackDamage;
        attackSpeed = player.attackSpeed;
       
    }
}
