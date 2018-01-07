using UnityEngine;
using System;
using System.Collections;
using UnitySteer.Behaviors;

using FluentBehaviourTree;


public class ZombieBT_2 : MonoBehaviour
{

    private IBehaviourTreeNode tree;
	private Vector3 targetPosition;

    void Start()
    {
        Debug.Log("ZombieBT start");

        var builder = new BehaviourTreeBuilder();
//        var targetPosition = GameObject.Find("Player").transform.position;
        targetPosition = GameObject.Find("Player").transform.position;

        this.tree = builder
            .Selector("ChooseAction")
                .Sequence("tryToGoToPlayer")
                    // If player is alive and close then go to it
                    .Condition("isPlayerClose", t => (BlackboardZombie.Instance.getIsPlayerAlive() == true && Vector3.Distance(transform.position, targetPosition) < 8
                                                    && Vector3.Distance(transform.position, targetPosition) > 2))
                    .Do("GoToPlayer", t =>
                    {
                        GetComponent<Animator>().SetBool("bool_walk", true);
                        GetComponent<Animator>().SetBool("bool_attack", false);
                        Debug.Log("~~~ GoToPlayer");
                        BehaviourTreeStatus bts;
                        bts = GoToTarget("target1", targetPosition);
                        BlackboardZombie.Instance.setTarget1(bts == BehaviourTreeStatus.Success);
                        return bts;
                    })
                .End()
                .Sequence("tryToAttackPlayer")
                    // If player is alive and in range then attack him
                    .Condition("isPlayerInRange", t => (BlackboardZombie.Instance.getIsPlayerAlive() == true && Vector3.Distance(transform.position, targetPosition) <= 2))
                    .Do("AttackPlayer", t =>
                    {
                        GetComponent<Animator>().SetBool("bool_walk", false);
                        GetComponent<Animator>().SetBool("bool_attack", true);
                        Debug.Log("~~~ AttackPlayer");
                        return AttackPlayer();
                    })
                .End()
                .Do("Wander", t =>
                {
                    GetComponent<Animator>().SetBool("bool_walk", true);
                    GetComponent<Animator>().SetBool("bool_attack", false);
                    GetComponent<SteerForWander>().enabled = true;
                    Debug.Log("~~~ Wander");
                    return Wander();
                })
            .End()
            .Build();
    }
    // Update is called once per frame
    void Update()
    {
        this.tree.Tick(new TimeData(Time.deltaTime));
		targetPosition = GameObject.Find("Player").transform.position;
		Debug.Log (Vector3.Distance (transform.position, targetPosition));
    }

    BehaviourTreeStatus GoToTarget(String targetName, Vector3 targetPosition)
    {
        GetComponent<SteerForPoint>().TargetPoint = targetPosition;
        GetComponent<SteerForPoint>().enabled = true;
        GetComponent<SteerForWander>().enabled = false;
        Debug.Log("- Going to " + targetName + ", return RUNNING");
        return BehaviourTreeStatus.Running;
    }

    BehaviourTreeStatus AttackPlayer()
    {
        GetComponent<SteerForPoint>().enabled = false;
        GetComponent<SteerForWander>().enabled = false;
        if (BlackboardZombie.Instance.getIsPlayerAlive() == false)
        {
            return BehaviourTreeStatus.Success;
        }
        if (BlackboardZombie.Instance.getZombieAttackCooldown() == 100)
        {
            Debug.Log("- Hit player (" + Blackboard.Instance.getPlayerHealth() + " - 1 HP), return RUNNING");
            Blackboard.Instance.setPlayerHealth(Blackboard.Instance.getPlayerHealth() - 10);
            BlackboardZombie.Instance.setZombieAttackCooldown(0);
        }
        else
        {
            Debug.Log("- Attack on cooldown");
            BlackboardZombie.Instance.setZombieAttackCooldown(BlackboardZombie.Instance.getZombieAttackCooldown() + 1);
        }

        return BehaviourTreeStatus.Running;
    }

    BehaviourTreeStatus Idle(int seconds)
    {
        return BehaviourTreeStatus.Success;

    }

    BehaviourTreeStatus Wander()
    {
        GetComponent<SteerForPoint>().enabled = false;
        GetComponent<SteerForWander>().enabled = true;
        var wanderSteering = GetComponent<SteerForWander>();
        wanderSteering.MaxLatitudeSide = 2;
        wanderSteering.MaxLatitudeUp = 2;
        wanderSteering.enabled = true;
        return BehaviourTreeStatus.Success;
    }

}