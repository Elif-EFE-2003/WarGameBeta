using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    public int extraBullet;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void open(){
        if(Input.GetKeyDown(KeyCode.E)){
        anim.Play("open");
        FindObjectOfType<rifle>().totalBlulet +=20;
        }
    }
}
