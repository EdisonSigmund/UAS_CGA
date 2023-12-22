using UnityEngine;

public class AnimateCollider : MonoBehaviour
{
    private Animation anim;
    private Collider coll;
    private Vector3 initialColliderSize;
    public string animationClipName = "Scene";

    void Start()
    {
        anim = GetComponent<Animation>();
        coll = GetComponent<MeshCollider>();
        initialColliderSize = coll.bounds.size; 
    }

    void Update()
    {
        if (anim.isPlaying)
        {
            float animYScale = transform.localScale.y;
            Vector3 newColliderSize = initialColliderSize;

            newColliderSize.y *= animYScale;
            coll.transform.localScale = newColliderSize;
        }
    }
}
