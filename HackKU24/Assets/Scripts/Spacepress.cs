using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spacepress : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the space bar has been pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Load the main menu scene
            SceneManager.LoadScene("MainMenu");
        }
    }
}
