using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ENEMY1 : MonoBehaviour
{
    player player_sc;
    [HideInInspector]
    public GameObject player;
    public int hasar;
    [HideInInspector]
    public LayerMask layer;
    NavMeshAgent Agent;
    public GameObject target;
    [HideInInspector]
    public bool isActive, chase, attack;
    int targetIndex;
    public List<GameObject> patrolPoints;
    public int hp;
    Vector3 mainPos;
    void Start()
    {
        player_sc=FindObjectOfType<player>();
        mainPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        Agent = GetComponent<NavMeshAgent>();
        targetIndex = 0;
        isActive = false;
        chase = false;

    }
    private void OnDestroy()
    {
        FindObjectOfType<GameManager>().enemyList.Remove(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        navigation();
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(damaging());
        }
    }
    void navigation()
    {

        Vector3 rayDirection = player.transform.position - transform.position;
        Physics.Raycast(transform.position + Vector3.up, rayDirection, out RaycastHit playerCheck, 10f, layer);
        if (!isActive && !chase && playerCheck.collider.gameObject.tag == "Player")
        {
            chase = true;
        }
        else if (chase && Vector3.Distance(transform.position, player.transform.position) < 13)
        {
            chase = false;
        }
        else if (chase && Vector3.Distance(transform.position, mainPos) > 30)
        {
            chase = false;
            transform.position = mainPos;
        }



        if (isActive || chase)
        {
            Agent.SetDestination(player.transform.position);
            if (!attack && Vector3.Distance(transform.position, player.transform.position) < 2)
            {
                attack = true;
                StartCoroutine(damaging());
            }
        }
        else
        {
            Agent.SetDestination(patrolPoints[targetIndex].transform.position);
        }
        float distanceToTargetPosition = Vector3.Distance(transform.position, patrolPoints[targetIndex].transform.position);
        if (distanceToTargetPosition < 3)
        {
            targetIndex++;
            if (targetIndex == patrolPoints.Count)
            {
                targetIndex = 0;
            }
        }
        /*if(Vector3.Distance(transform.position,player.transform.position)<20){
           Agent.SetDestination(player.transform.position);
        }else{
            Agent.SetDestination(patrolPoints[targetIndex].transform.position);
            float distanceToTargetPosition=Vector3.Distance(transform.position,patrolPoints[targetIndex].transform.position);
            if(distanceToTargetPosition<3){
            targetIndex++;
            if(targetIndex==patrolPoints.Count){
                targetIndex=0;
            }
        }
          }
        */
    }
    IEnumerator damaging()
    {
        while (attack)
        {
            
            if(player.GetComponent<player>().hp>0){
                player_sc.hp-=hasar;
                
            }else if(player_sc.isAlive){
                player_sc.isAlive=false;
                isActive=false;
                chase=false;
                transform.position=mainPos;
            }
            yield return new WaitForSeconds(1);
            if (Vector3.Distance(transform.position, player.transform.position) > 2)
            {
                attack = false;
                break;
            }
        }

        //yield return null;
    }

}
