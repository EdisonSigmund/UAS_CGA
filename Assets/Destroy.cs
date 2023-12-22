using System.Collections;
using UnityEngine;

public class Destroy : MonoBehaviour{
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy (gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
