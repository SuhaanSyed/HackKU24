using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SecondLayerCloudOpacity : MonoBehaviour
{
    public Tilemap secondLayerCloudTilemap;
    public float fadeDuration = 30f; // Duration of the fading effect in seconds
    public float delay = 60f; // Delay before starting the fading effect

    private float timer; // Timer to keep track of the time
    private float maxTime = 150f; // 2 min 30 sec in seconds
    private bool isFading = false; // Flag to check if fading is in progress

    private void Awake()
    {
        timer = 0f; // Initialize the timer
    }

    private void Update()
    {
        timer += Time.deltaTime; // Increment the timer
        
        // Check if it's time to start fading
        if (timer >= delay && timer <= maxTime - fadeDuration && !isFading)
        {
            isFading = true;
            StartCoroutine(FadeCloud());
        }
    }

    IEnumerator FadeCloud()
    {
        float startOpacity = 0f; // Initial opacity
        float endOpacity = 1f; // Target opacity
        float elapsedTime = 0f; // Elapsed time for the fading effect

        Color color = secondLayerCloudTilemap.color; // Get the current color of the cloud
        
        // Fade from current opacity to 1 (fully visible) over 'fadeDuration' seconds
        while (elapsedTime < fadeDuration)
        {
            // Calculate the new opacity using lerp
            float t = elapsedTime / fadeDuration;
            color.a = Mathf.Lerp(startOpacity, endOpacity, t);

            // Apply the new color to the cloud's sprite renderer
            secondLayerCloudTilemap.color = color;

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Ensure the final opacity is set
        color.a = endOpacity;
        secondLayerCloudTilemap.color = color;
    }
}
