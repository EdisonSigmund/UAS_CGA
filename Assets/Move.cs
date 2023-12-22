using System.Collections;
using UnityEngine;

public class MoveUpDownWithAnimation : MonoBehaviour
{
    public string animationClipName = "Scene"; // Change this to your animation clip's name
    public float moveAmount = 1f;
    private bool isMoving = false;
    private Vector3 initialPosition;

    private Animation anim;

    void Start()
    {
        anim = GetComponent<Animation>();
        initialPosition = transform.position;
        StartCoroutine(MoveObjectUpDown());
    }

    IEnumerator MoveObjectUpDown()
    {
        while (true)
        {
            if (!isMoving && anim.IsPlaying(animationClipName))
            {
                isMoving = true;
                MoveObject(Vector3.up * moveAmount); // Move up
            }
            else if (isMoving && !anim.isPlaying)
            {
                isMoving = false;
                MoveObject(Vector3.down * moveAmount); // Move down
            }
            yield return null;
        }
    }

    void MoveObject(Vector3 direction)
    {
        transform.position += direction;
    }
}
