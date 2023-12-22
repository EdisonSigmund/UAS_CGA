using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed;
    public GameObject deathParticies;

    private float maxSpeed = 5f;
    private Vector3 input;

    private Vector3 spawn;

    void Start () {
        spawn = transform.position;
        GameManager;
    }

    void FixedUpdate() {
        input = new Vector3 (input.GetAxisRaw ("Horizontal"), 0, input.GetAxisRaw ("Vertical"));
        if(GetComponent<Rigidbody>().velocity.magnitude < maxspeed)
        {
            GetComponent<Rigidbody>().AddForce(input * moveSpeed);
        }

        if (transform.position.y < -2)
        {
            Die ();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Enemy")
        {
            Die ();
        }
    }

    void onTriggerEnter (Collider other)
    {   
        if (other.transform.tag =="Enemy")
        {
            Die ();
        }
        if (other.transform.tag =="Goal")
        {
            GameManager.CompleteLevel();
        }
    }

    void Die()
    {
        Instantiate(deathParticies, transform.position, Quaternion.Euler(270,0,0));
        transform.position = spawn;
    }

}
