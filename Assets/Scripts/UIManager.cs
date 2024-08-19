using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    rifle rifle_sc;
    player player_sc;
    GameManager gameManager_sc;
    public Text hpText,enemyCountText,timerText,magazineText,ammoText;
    void Start()
    {
        rifle_sc=FindObjectOfType<rifle>();
        gameManager_sc=FindObjectOfType<GameManager>();
        player_sc=FindObjectOfType<player>();
        InvokeRepeating("textUpdate",.1f,0.1f);
    }
      void textUpdate(){
        ammoText.text=rifle_sc.totalBlulet.ToString() + " / "+rifle_sc.maxBullet.ToString();
        magazineText.text=rifle_sc.magazineBullet.ToString() + " / " +rifle_sc.magazineSize.ToString();
        timerText.text=((int)gameManager_sc.timeLeft).ToString();
        hpText.text="HP: "+player_sc.hp.ToString();
        enemyCountText.text="Enemy Left: "+gameManager_sc.enemyList.Count.ToString();

      }
    // Update is called once per frame
    void Update()
    {
        
    }
}
