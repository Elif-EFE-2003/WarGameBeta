using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    Vector3 startPos;
    GameObject player;
    NavMeshAgent agent;
    public int hp;
    
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindWithTag("Player");
        agent=GetComponent<NavMeshAgent>();
        startPos=transform.position;
 
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,player.transform.position)<5){//2 vector arası uzaklık hesaplar
           agent.SetDestination(player.transform.position);
        }
        else{
           agent.SetDestination(startPos);
        }
    
    }
    

}
