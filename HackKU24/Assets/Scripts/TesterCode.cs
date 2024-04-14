

using UnityEngine;

public class TesterCode : MonoBehaviour
{
    public CloudOpacity cloudOpacity; // Reference to the CloudOpacity script

    // Start is called before the first frame update
    void Start()
    {
        // Ensure that the CloudOpacity script reference is set
        if (cloudOpacity == null)
        {
            Debug.LogError("CloudOpacity script reference is not set!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Dummy condition to simulate checking a variable
        // You can replace this with your actual condition
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Call the GoblinDied() function of the CloudOpacity script
            cloudOpacity.GoblinDied();
        }
    }
}

