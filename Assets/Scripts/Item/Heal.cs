using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public PlayerHealth playerHealth;
    
    public void OnTriggerEnter(Collider other){//kalo didalam /kena collider terdeteksi
        if (other.tag == "Player" && !other.isTrigger){
            int heal=100;
            playerHealth.Heal(heal);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
