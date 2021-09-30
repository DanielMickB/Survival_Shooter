using UnityEngine;
 
public class PlayerDetector : MonoBehaviour
{
    public GameOverManager gameOverManager;
 
    private void OnTriggerEnter(Collider other){//kalo didalam /kena collider terdeteksi
        if (other.tag == "Enemy" && !other.isTrigger){
            float enemyDistance = Vector3.Distance(transform.position,other.transform.position);
            gameOverManager.ShowWarning(enemyDistance);//alesan gameover dipanggil krn yg megang objeknya gamover
        }
    }
}