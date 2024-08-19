using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class drone : MonoBehaviour
{
    public Transform bulletPos1, bulletPos2;
    public Vector3 targetPoint;
    public GameObject projectile;
    int barrelNo;
    void Start()
    {
        barrelNo = 1;

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void fire(RaycastHit ray)   
    {
        Transform barrelPos=gameObject.transform;
        switch (barrelNo)
        {
            case 1:
                barrelPos = bulletPos1;
                break;

            case 2:
                barrelPos = bulletPos2;
                break;
            default:
                break;
        }
        if(barrelNo==1){
            barrelNo=2;
        }else{
            barrelNo=1;
        }
        GameObject newBullet = Instantiate(projectile, barrelPos.position, barrelPos.rotation);
        newBullet.GetComponent<armorPiercing>().targetPosition = ray.point;
    }
}
