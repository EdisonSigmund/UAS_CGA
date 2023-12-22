using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour{
    public float delayTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Go ());
    }

    IEnumerator Go()
    {
        while(true)
        {
            GetComponent<Animation>().Play ();
            yield return new WaitForSeconds(3f);
        }
    }
}
