using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Planter : MonoBehaviour
{
    public GameObject plantPrefab; // The plant prefab to instantiate

    public bool isPlanted = false; // Whether a plant has been planted on this tile
    private bool isPlayerNearby = false; // Whether the player is nearby

    void OnTriggerEnter2D(Collider2D other)
    {
        // If the other collider is the player
        if (other.tag == "Player")
        {
            // Mark that the player is nearby
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // If the other collider is the player
        if (other.tag == "Player")
        {
            // Mark that the player is no longer nearby
            isPlayerNearby = false;
        }
    }

    public void Plant()
    {
        // If a plant hasn't been planted yet and the player is nearby
        if (!isPlanted && isPlayerNearby)
        {
            // Instantiate the plant at the center of the tile
            GameObject plant = Instantiate(plantPrefab, transform.position, Quaternion.identity);

            // Mark the tile as planted
            isPlanted = true;

            // Start the plant animation
            Animator plantAnimator = plant.GetComponent<Animator>();
            if (plantAnimator != null)
            {
                plantAnimator.SetBool("planted", true);
            }
        }
    }
}



// using UnityEngine;

// public class Planter : MonoBehaviour
// {
//     public GameObject plantPrefab;

//     private bool isPlanted = false;
//     private bool isPlayerNearby = false;

//     void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.tag == "Player")
//         {
//             isPlayerNearby = true;
//         }
//     }

//     void OnTriggerExit2D(Collider2D other)
//     {
//         if (other.tag == "Player")
//         {
//             isPlayerNearby = false;
//         }
//     }

//     public void Plant()
//     {
//         if (!isPlanted && isPlayerNearby)
//         {
//             GameObject plant = Instantiate(plantPrefab, transform.position, Quaternion.identity);
//             isPlanted = true;
//             Animator plantAnimator = plant.GetComponent<Animator>();
//             if (plantAnimator != null)
//             {
//                 plantAnimator.SetBool("planted", true);
//             }
//         }
//     }
// }
