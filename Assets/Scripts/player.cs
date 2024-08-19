using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    GameObject cam;
    public int hp;
    Rigidbody rb;
    Animator anim;
    Vector3 moveDir;
    float ileri,yan,moveSpeed,sensivity;
    bool running,jumping;
     int scaleType;
    public Transform mascot,mascotPos;
    public bool isAlive;
    void Start()
    {
        moveSpeed=5;
        sensivity=250;
        rb=GetComponent<Rigidbody>();
        //Player=GameObject.Find("Player");
        //anim=GameObject.Find("Character").GetComponent<Animator>();
        anim=transform.Find("Character").GetComponent<Animator>();
        Cursor.lockState=CursorLockMode.Locked;
        cam=GameObject.FindGameObjectWithTag("MainCamera");
        isAlive=true;
    }

    // Update is called once per frame
    void Update()
    {
     if(isAlive){
       movement();
     }
       
       //mascotPosition();
       
    }
    /*void mascotPosition(){
       mascot.transform.position=Vector3.Lerp(mascot.transform.position,mascotPos.position,moveSpeed*Time.deltaTime);
       mascot.transform.rotation=Quaternion.Lerp(mascot.transform.rotation,mascotPos.rotation,moveSpeed*Time.deltaTime);
    }
    */
    void movement(){
        running=Input.GetKey(KeyCode.LeftShift);
        jumping=Input.GetKeyDown(KeyCode.Space);//1 kere işlem yapıcak
        ileri=Input.GetAxis("Vertical");
        yan=Input.GetAxis("Horizontal");
        moveDir=new Vector3(yan,0,ileri);
        if(jumping){
            rb.AddForce(Vector3.up*5,ForceMode.Impulse);
        }
        transform.Translate(moveDir*moveSpeed*Time.deltaTime);
        transform.Rotate(0,Input.GetAxis("Mouse X")*sensivity*Time.deltaTime,0);
        cam.transform.Rotate(Input.GetAxis("Mouse Y")*-sensivity*Time.deltaTime,0,0);
        anim.SetFloat("forward",ileri);
        anim.SetFloat("side",yan);
        anim.SetBool("run",running);
        anim.SetBool("jump",jumping);
    }
    private void OnTriggerStay(Collider other){
         GameObject obj=other.gameObject;
         if(obj.tag=="chest" && Input.GetKeyDown(KeyCode.E)){
            obj.GetComponent<chest>().open();
         }
    
    }
}
