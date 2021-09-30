using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public PlayerMovement playerspd;
    float timer=0f;
    float duration = 5f;
    float spd=1.5f;
    bool buffed = false;
    public void OnTriggerEnter(Collider other){//kalo didalam /kena collider terdeteksi
        if (other.tag == "Player" && !other.isTrigger &&buffed == false){
            
            playerspd.Speedup(spd);
            buffed= true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= duration && buffed ==true){//durasi abis
            playerspd.Speedreset(spd);
            timer=0;
            buffed= false;
        }
        timer += Time.deltaTime;
        
    }
}
