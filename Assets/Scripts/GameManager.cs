using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemies;
    [SerializeField]
     float TotalTime;
    [HideInInspector]
    public float timeLeft;
    public List<GameObject> enemyList;
    bool enemyActive;
    
    // Start is called before the first frame update
    void Start()
    {
        timeLeft=TotalTime;
        enemies=GameObject.FindGameObjectsWithTag("ENEMY");
        for(int i=0;i<enemies.Length;i++){
           enemyList.Add(enemies[i]);
        }
        enemyActive=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft>0){
        timeLeft-=Time.deltaTime;
        }
        else if(!enemyActive){
         enemyActive=true;
         foreach(GameObject x in enemyList){
            x.GetComponent<ENEMY1>().isActive=true;
         }
        }

    }
}
