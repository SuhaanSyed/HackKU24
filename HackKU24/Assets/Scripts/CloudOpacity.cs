using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CloudOpacity : MonoBehaviour
{
    public Tilemap cloudTilemap;
    public float fadeDuration = 30f; // Duration of the fading effect in seconds

    private float timer; // Timer to keep track of the time
    private float maxTime = 90f; // 1 min 30 sec in seconds
    private bool isFading = false; // Flag to check if fading is in progress

    private void Awake()
    {
        timer = 0f; // Initialize the timer
    }

    private void Update()
    {
        timer += Time.deltaTime; // Increment the timer
        
        // Check if it's time to start fading
        if (timer <= maxTime - fadeDuration && !isFading)
        {
            isFading = true;
            StartCoroutine(FadeCloud());
            MoveClouds();
        }
    }

    IEnumerator FadeCloud()
    {
        float startOpacity = 0f; // Initial opacity
        float endOpacity = 1f; // Target opacity
        float elapsedTime = 0f; // Elapsed time for the fading effect

        Color color = cloudTilemap.color; // Get the current color of the cloud
        
        // Fade from current opacity to 1 (fully visible) over 'fadeDuration' seconds
        while (elapsedTime < fadeDuration)
        {
            // Calculate the new opacity using lerp
            float t = elapsedTime / fadeDuration;
            color.a = Mathf.Lerp(startOpacity, endOpacity, t);

            // Apply the new color to the cloud's sprite renderer
            cloudTilemap.color = color;

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Ensure the final opacity is set
        color.a = endOpacity;
        cloudTilemap.color = color;
    }

    // Move Clouds to the left
    public void MoveClouds()
    {
        cloudTilemap.transform.position = new Vector3(cloudTilemap.transform.position.x - 0.5f, cloudTilemap.transform.position.y, cloudTilemap.transform.position.z);
    }


}
