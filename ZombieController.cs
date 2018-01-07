using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour
{
    void Start()
    {
        BlackboardZombie.Instance.setTarget1(false);
        BlackboardZombie.Instance.setTarget2(false);
        BlackboardZombie.Instance.setPlayerHealth(20);
        BlackboardZombie.Instance.setIsPlayerAlive(true);
        BlackboardZombie.Instance.setIsPlayerAlive(true);
        BlackboardZombie.Instance.setZombieAttackCooldown(0);
    }

    void Update()
    {
        if (BlackboardZombie.Instance.getTarget1() && BlackboardZombie.Instance.getTarget2())
        {
            BlackboardZombie.Instance.setTarget1(false);
            BlackboardZombie.Instance.setTarget2(false);
        }
        if (BlackboardZombie.Instance.getPlayerHealth() == 0 && BlackboardZombie.Instance.getIsPlayerAlive() == true)
        {
            Debug.Log("- PLAYER KILLED");
            BlackboardZombie.Instance.setIsPlayerAlive(false);
            Destroy(GameObject.Find("Target1"));
        }
    }
}
