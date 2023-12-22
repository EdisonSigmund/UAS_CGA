using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public GameManager manager;
    public float moveSpeed;
    public GameObject  deathParticles;

    private float maxSpeed = 5f;
    private Vector3 input;
    private Vector3 spawn;

    void Start () {
        spawn = transform.position;
        manager = manager.GetComponent<GameManager>();
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
            manager.AddToken();
            Destroy(other.gameObject, 4f);
        }
        if (other.transform.tag == "Goal")
        {
            manager.CompleteLevel();
        }
    }
    
    void Die()
    {
        Instantiate(deathParticles, transform.positionm, Quaternion.Euler(270, 0,0));
        transform.position = spawn;
    }
}


