using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class CloudCovered : MonoBehaviour
{
    public Tilemap secondLayerCloudTilemap;
    public string gameOverSceneName; // Name of the game over scene
    public CloudOpacity cloudOpacity; // Reference to the CloudOpacity script
<<<<<<< HEAD
    public float fadeDuration = 2f; // Duration of the fading effect in seconds

    private bool isFading = false; // Flag to check if fading is in progress

    private void Update()
    {
        // Check if all goblins are dead and the clouds are not already fading in
        if (cloudOpacity != null && cloudOpacity.goblinDeathCount >= cloudOpacity.goblinDeathThreshold && !isFading)
        {
            isFading = true;
=======
    public float fadeDuration = 1f; // Duration of the fading effect in seconds

    private void Update()
    {
        if (cloudOpacity == null)
        {
            Debug.LogError("CloudOpacity script reference is not set!");
            return;
        }

        Debug.Log("Goblin Death Count: " +  cloudOpacity.goblinDeathCount);
        Debug.Log("Goblin Death Threshold: " + cloudOpacity.goblinDeathThreshold);

        // Check if all goblins are dead and the clouds are not already fading in
        if (cloudOpacity.goblinDeathCount >= cloudOpacity.goblinDeathThreshold)
        {
            Debug.Log("All goblins are dead. Fading in large cloud...");

>>>>>>> main
            StartCoroutine(FadeInCloudAndLoadGameOverScene());
        }
    }

<<<<<<< HEAD
    IEnumerator FadeInCloudAndLoadGameOverScene()
=======
    public IEnumerator FadeInCloudAndLoadGameOverScene()
>>>>>>> main
    {
        float startOpacity = 0f; // Initial opacity
        float endOpacity = 1f; // Target opacity
        float elapsedTime = 0f; // Elapsed time for the fading effect

        // Ensure the clouds are at the starting opacity before fading
        SetCloudOpacity(startOpacity);

<<<<<<< HEAD
=======
        Debug.Log("Fading in large cloud...");

>>>>>>> main
        // Fade from current opacity to 1 (fully visible) over 'fadeDuration' seconds
        while (elapsedTime < fadeDuration)
        {
            // Calculate the new opacity using lerp
            float t = elapsedTime / fadeDuration;
            float currentOpacity = Mathf.Lerp(startOpacity, endOpacity, t);

            // Set the cloud's opacity
            SetCloudOpacity(currentOpacity);

            // Update the elapsed time
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Ensure the clouds are at the target opacity after fading
        SetCloudOpacity(endOpacity);
<<<<<<< HEAD

        // Wait for a few seconds
        yield return new WaitForSeconds(3f); // Change this to the number of seconds you want to wait

        // Load the game over scene
        SceneManager.LoadScene(gameOverSceneName);
=======
>>>>>>> main
    }

    private void SetCloudOpacity(float opacity)
    {
        // Get the current color of the clouds
        Color cloudColor = secondLayerCloudTilemap.color;

        // Set the new opacity
        cloudColor.a = opacity;

        // Apply the new color to the clouds
        secondLayerCloudTilemap.color = cloudColor;
    }
}