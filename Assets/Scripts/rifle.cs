using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rifle : MonoBehaviour
{
    public float time;
    drone drone_sc;
    public float timer;
    Transform cam;
    public int maxBullet, totalBlulet, magazineBullet, magazineSize;
    public GameObject projectile;
    public Transform bulletPos;
    public ParticleSystem barrelFx;
    AudioSource Audio;
    void Start()
    {
        drone_sc=FindObjectOfType<drone>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        Audio = GetComponent<AudioSource>();
        time = 0;
    }


    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Mouse0) && (time <= 0) && magazineBullet > 0)
        {


            time = timer;
            Physics.Raycast(cam.position, cam.transform.forward, out RaycastHit rayInfo, Mathf.Infinity);
            GameObject newBullet = Instantiate(projectile, bulletPos.position, bulletPos.rotation);
            newBullet.GetComponent<armorPiercing>().targetPosition = rayInfo.point;
            drone_sc.fire(rayInfo);
            Audio.Play();
            magazineBullet--;


        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = magazineSize; i > 0; i--)
            {
                if (totalBlulet >= i)
                {
                    magazineBullet = i;
                    totalBlulet -= i;
                    break;
                }
            }

        }

    }
}
