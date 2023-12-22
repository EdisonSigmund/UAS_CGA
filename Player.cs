using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    
    public GameManager manager;
    public float moveSpeed;
    public GameObject deathParticles;
    public bool userManager = true

    private float maxSpeed = 5f;
    private Vector3 input;

    private Vector3 spawn;

    public AudioClip[] audioClip;

    void Start () {
        spawn = transform.positionl;
        if (userManager)
        {
            manager = manager.GetComponent<GameManager>();
        }
    }


    void FixedUpdate () {
        input = new Vector3 (input.GetAxisRaw ("Horizontal"), 0, input.GetAxisRaw ("Vertical"));
        if (rigidbody.velocity.magnitude < maxSpeed)
        {
            rigidbody.AddRelativeForce(input * moveSpeed);
        }

        if (transform.position.y <-2)
        {
            Die();
        }

        Physics.gravity = Physics.Raycast(transform.position, Vector3.down, .45f) ? Vector3.zero : new Vector3(0, -25f, 0); 
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Enemy")
        {
            Die();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            Die();
        }
        if (other.transform.tag == "Token")
        {
            if (userManager)
            {
               manager.tokenCount += 1;
            }
            PlaySound(0);
            Destroy(other.gameObject);
        }
        if (other.transform.tag == "Goal")
        {
            PlaySound(1);
            Time.timeScale = 0f;
            manager.CompleteLevel();
        }
    }
    
    void PlaySound () 
    {
        audioClip = audioClip[clip];
        audio.Play();
    }
    void Die()
    {
        Instantiate(deathParticles, transform.positionm, Quaternion.Euler(270, 0,0));
        transform.position = spawn;
    }
}


