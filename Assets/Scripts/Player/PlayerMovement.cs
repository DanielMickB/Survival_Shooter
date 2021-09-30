using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    Vector3 movement;
    Animator anim;// menghubungkan dengan unity 
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;

    private void Awake(){
        //mendapatkan nilai mask dari layer yang bernama Floor
        floorMask = LayerMask.GetMask("Floor");
        
        //Mendapatkan komponen Animator
        anim = GetComponent<Animator>();
        
        //Mendapatkan komponen Rigidbody
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate(){
        //Mendapatkan nilai input horizontal (-1,0,1)
        float h = Input.GetAxisRaw("Horizontal");
        
        //Mendapatkan nilai input vertical (-1,0,1)
        float v = Input.GetAxisRaw("Vertical");
        
        Move(h, v);//gerak karakter
        Turning();//gerak menghadap senjata/karakter
        Animating(h, v);//supaya animasi jalan
    }
//Method player dapat berjalan
    void Move(float h, float v){
        //Set nilai x dan y
        movement.Set(h, 0f, v);//posisi awal
        
        //Menormalisasi nilai vector agar total panjang dari vector adalah 1
        movement = movement.normalized * speed * Time.deltaTime;
        
        //Move to position
        playerRigidbody.MovePosition(transform.position + movement);
    }
//Method kontrol hadap player
    void Turning(){
        //Buat Ray dari posisi mouse di layar
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        //Buat raycast untuk floorHit
        RaycastHit floorHit;
        
        //Lakukan raycast
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)){
            //Mendapatkan vector dari posisi player dan posisi floorHit
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            
            //Mendapatkan look rotation baru ke hit position
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            
            //Rotasi player
            playerRigidbody.MoveRotation(newRotation);
        }
    }
//Method animasi
    void Animating(float h, float v){
        bool walking = h != 0f || v != 0f;// nilai walking adalah h tidak bertambah atau v tidak bertambah
        anim.SetBool("IsWalking", walking);
    }
    public void Speedup(float amount){
        
        speed *= amount;
        
        
        
    }
    public void Speedreset(float amount){
        speed /=amount;
        
        
        
    }

}
