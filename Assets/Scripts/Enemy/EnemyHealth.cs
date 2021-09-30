using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;
//slider
    [SerializeField] private SpriteRenderer hpFill;
    public SpriteRenderer hpBar;

    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;


    void Awake (){
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = startingHealth;
        hpBar.size = hpFill.size;
    }


    void Update ()
    {
        if (isSinking){
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
        
    }

//fungsi kena dmg
    public void TakeDamage (int amount, Vector3 hitPoint){
        Debug.Log("Player Attack");
        if (isDead)
            return;

        enemyAudio.Play ();

        currentHealth -= amount;
        
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if (currentHealth <= 0)
        {
            Death ();
        }
        float healthPercentage = (float) currentHealth / startingHealth;
        hpFill.size = new Vector2 (healthPercentage * hpBar.size.x,hpBar.size.y);
    }

//fungsi mati
    void Death (){
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger ("Dead");//jalanin animasi dead

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
    }

//fungsi menghilang
    public void StartSinking (){
        GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent<Rigidbody> ().isKinematic = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f);
    }
}
