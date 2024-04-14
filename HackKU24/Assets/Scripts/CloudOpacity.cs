using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CloudOpacity : MonoBehaviour
{
    public Tilemap cloudTilemap;
    public GameObject gameOverScene;
    public int maxOpacity = 255; // Maximum opacity of the cloud
    public int goblinDeathThreshold = 5; // Number of goblin deaths required for maximum opacity

    public int goblinDeathCount = 0; // Number of goblin deaths
    private float targetOpacity = 0f; // Target opacity of the cloud
    private float currentOpacity = 0f; // Current opacity of the cloud
    private float fadeDuration = 1f; // Duration of the fading effect in seconds

    private Coroutine opacityCoroutine; // Coroutine for fading opacity

    private void Start()
    {
        UpdateCloudOpacity();
    }

    // Call this method whenever a goblin dies
    public void GoblinDied()
    {
        goblinDeathCount++; // Increment the goblin death count
        UpdateCloudOpacity(); // Update cloud opacity based on the new goblin death count

        // Check if all goblins are dead
        if (goblinDeathCount >= goblinDeathThreshold)
        {
            LoadGameOverScene(); // Load the game over scene
        }
    }

    // Update cloud opacity based on goblin death count
    private void UpdateCloudOpacity()
    {
        // Calculate target opacity based on goblin death count
        targetOpacity = (float)maxOpacity / goblinDeathThreshold * goblinDeathCount;
        targetOpacity = Mathf.Clamp(targetOpacity, 0f, maxOpacity); // Clamp the opacity between 0 and maxOpacity

        // Start fading opacity
        if (opacityCoroutine != null)
        {
            StopCoroutine(opacityCoroutine);
        }
        opacityCoroutine = StartCoroutine(FadeCloud());
    }

    // Coroutine for fading opacity
    private IEnumerator FadeCloud()
    {
        float elapsedTime = 0f; // Elapsed time for the fading effect
        float startingOpacity = currentOpacity; // Store the starting opacity

        while (elapsedTime < fadeDuration)
        {
            // Calculate the new opacity using lerp
            float t = elapsedTime / fadeDuration;
            currentOpacity = Mathf.Lerp(startingOpacity, targetOpacity, t);

            // Set the cloud's opacity
            Color color = cloudTilemap.color;
            color.a = currentOpacity / 255f; // Opacity values are usually between 0 and 1
            cloudTilemap.color = color;

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Ensure the final opacity is set
        currentOpacity = targetOpacity;

        // Set the cloud's opacity
        Color finalColor = cloudTilemap.color;
        finalColor.a = currentOpacity / 255f; // Opacity values are usually between 0 and 1
        cloudTilemap.color = finalColor;
    }

    // Load the game over scene
    private void LoadGameOverScene()
    {
        if (gameOverScene != null)
        {
            // You can use SceneManager.LoadScene() or any other method to load the game over scene
            // For now, let's just activate the game over scene GameObject if it's assigned
            gameOverScene.SetActive(true);
        }
        else
        {
            Debug.LogError("Game Over Scene is not assigned!");
        }
    }
}
