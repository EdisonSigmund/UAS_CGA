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
        moveSpeed = 2f;
    }
 

    void Update () {
        transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime,0f,moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);    
    }
    

    void FixedUpdate() {
        input = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
        if(GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
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
        if (other.transform.tag == "TrapCone")
        {
            Die ();
        }
        if (other.transform.tag =="Goal")
        {
            GameManager.CompleteLevel();
        }
    }

    void OnTriggerEnter (Collider other)
    {   
        if (other.CompareTag("TrapCone"))
        {
            Die();
        }
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
        transform.position = spawn;
        Instantiate(deathParticies, transform.position, Quaternion.Euler(270,0,0));
    }

}
