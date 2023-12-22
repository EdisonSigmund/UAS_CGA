using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float delayTime = 3f;
    public string animationClipName = "Scene";
    public float yOffset = 0.3f; // Offset value to move the object upwards

    private GameObject trapPrefab; // Reference to the corridor_spike_trap prefab
    private Animation trapAnimation;
    private bool isAnimationPlaying = false; // Flag to control animation state

    void Start()
    {
        // Load the corridor_spike_trap prefab
        trapPrefab = Resources.Load<GameObject>("corridor_spike_trap");

        if (trapPrefab != null)
        {
            trapAnimation = trapPrefab.GetComponentInChildren<Animation>();
            StartCoroutine(PlayAnimationRepeatedly());
        }
        else
        {
            Debug.LogError("corridor_spike_trap prefab not found.");
        }
    }

    IEnumerator PlayAnimationRepeatedly()
    {
        while (true)
        {
            if (trapAnimation != null && !isAnimationPlaying) // Check animation and flag
            {
                trapAnimation.Play(animationClipName);
                isAnimationPlaying = true;
                
                yield return new WaitForSeconds(delayTime);

                isAnimationPlaying = false;
            }
            yield return null;
        }
    }
}
