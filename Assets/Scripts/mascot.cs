using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class mascot : MonoBehaviour
{
    public Transform mascotPos;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=Vector3.Lerp(transform.position,mascotPos.position,moveSpeed*Time.deltaTime);// hızlı başlar ortada yavaşlar Adan B ye parabolik geçiş
        //lerp yerine MoveTowards olsaydı aynı hızla giderdi
        transform.rotation=Quaternion.Lerp(transform.rotation,mascotPos.rotation,moveSpeed*Time.deltaTime);
    }
}
