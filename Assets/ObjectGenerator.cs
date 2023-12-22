using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject prefabToInstantiate1;
    public GameObject prefabToInstantiate2;
    public Vector3 position1 = new Vector3(-3.8499999f, 0.25f, 3.44000006f);
    public Vector3 position2 = new Vector3(-3.8499999f, 0.25f, 3.44000006f);

    void Start()
    {
        GameObject instantiatedPrefab1 = Instantiate(prefabToInstantiate1, position1, Quaternion.identity);
        GameObject instantiatedPrefab2 = Instantiate(prefabToInstantiate2, position2, Quaternion.identity);

        SetPatrolPoints1(instantiatedPrefab1);
        SetPatrolPoints2(instantiatedPrefab2);
    }

    void SetPatrolPoints1(GameObject prefabInstance)
    {
        Patrol patrolScript = prefabInstance.GetComponent<Patrol>();
        if (patrolScript != null)
        {
            Transform[] points = new Transform[2];
            GameObject point1 = new GameObject("Point1");
            GameObject point2 = new GameObject("Point2");

            point1.transform.position = new Vector3(-1.17999995f, 0.430000007f, 5.30000019f);
            point2.transform.position = new Vector3(-0.920000017f, 0.430000007f, -2.80999994f);

            points[0] = point1.transform;
            points[1] = point2.transform;

            patrolScript.patrolPoints = points;
        }
        else
        {
            Debug.LogError("Patrol script not found on the instantiated prefab.");
        }
    }

    void SetPatrolPoints2(GameObject prefabInstance)
    {
        Patrol patrolScript = prefabInstance.GetComponent<Patrol>();
        if (patrolScript != null)
        {
            Transform[] points = new Transform[2];
            GameObject point1 = new GameObject("Point1");
            GameObject point2 = new GameObject("Point2");

            point1.transform.position = new Vector3(-3.96000004f, 0.430000007f, 3.51999998f);
            point2.transform.position = new Vector3(-0.839999974f, 0.430000007f, 3.45000005f);

            points[0] = point1.transform;
            points[1] = point2.transform;

            patrolScript.patrolPoints = points;
        }
        else
        {
            Debug.LogError("Patrol script not found on the instantiated prefab.");
        }
    }
}
