using UnityEngine;
using System.Collections;

public class BlackboardZombie : MonoBehaviour
{
    private int playerHealth;
    private bool isPlayerAlive;
    private int zombieAttackCooldown;

    static readonly BlackboardZombie instance = new BlackboardZombie();
    static BlackboardZombie() { }

    public static BlackboardZombie Instance { get { return instance; } }


    public void setPlayerHealth(int value)
    {
        playerHealth = value;
    }

    public void setIsPlayerAlive(bool t)
    {
        isPlayerAlive = t;
    }

    public void setZombieAttackCooldown(int t)
    {
        zombieAttackCooldown = t;
    }

    public int getPlayerHealth()
    {
        return playerHealth;
    }

    public bool getIsPlayerAlive()
    {
        return isPlayerAlive;
    }

    public int getZombieAttackCooldown()
    {
        return zombieAttackCooldown;
    }
}