// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlantInteract : MonoBehaviour
// {
//     // Start is called before the first frame update
//     // current player rigid body
//     private Dictionary<Vector3, bool> plantedTiles = new Dictionary<Vector3, bool>();
//     public Rigidbody2D player;

//     public int seedlingCount = 0;
//     public Animator animator;
//     public GameObject plantPrefab;
//     public int totalPlantsPlanted = 0;
//     PlayerController playerController;
//     public int plantCount = 0;


//     void Start()
//     {
//         playerController = player.GetComponent<PlayerController>();
//     }

//     // Update is called once per frame
//     void Update()
//     {

//         if (Input.GetKeyDown(KeyCode.E) && seedlingCount > 0)
//         {
//             // Calculate the planting position
//             Collider2D plantCollider = CalculatePlantPosition();
//             if (plantCollider != null)
//             {
//                 // Get the Planter component of the collider's game object
//                 Planter planter = plantCollider.gameObject.GetComponent<Planter>();

//                 // If the collider's game object has a Planter component
//                 if (planter != null && planter.isPlanted == false)
//                 {
//                     // Call the Plant method of the Planter
//                     planter.Plant();

//                     // Decrease the seedling count
//                     seedlingCount--;
//                     plantCount++;
//                 }
//             }
//         }
//         // if (Input.GetKeyDown(KeyCode.E) && seedlingCount > 0)
//         // {
//         //     // Calculate the planting position
//         //     Collider2D plantCollider = CalculatePlantPosition();
//         //     Vector3? plantPosition = plantCollider != null ? (Vector3?)plantCollider.transform.position : null;

//         //     // If a valid planting position was found
//         //     if (plantPosition != null)
//         //     {
//         //         // Instantiate the plant at the calculated position and the player's rotation
//         //         GameObject plant = Instantiate(plantPrefab, plantPosition.Value, transform.rotation);

//         //         // Set the "planted" boolean of the plant's animator to true
//         //         Animator plantAnimator = plant.GetComponent<Animator>();
//         //         if (plantAnimator != null)
//         //         {
//         //             plantAnimator.SetBool("planted", true);
//         //         }

//         //         // Decrease the seedling count
//         //         seedlingCount--;
//         //         Debug.Log("Seedling count: " + seedlingCount);

//         //         // Increase the total number of plants planted
//         //         totalPlantsPlanted++;
//         //         Debug.Log("Total plants planted: " + totalPlantsPlanted);

//         //         // Trigger the planting animation
//         //         animator.SetTrigger("Plant");
//         //     }
//         // }

//         // Collider2D planter = CalculatePlantPosition();

//         // // If the player is in contact with a planter and E is pressed
//         // if (planter != null && Input.GetKeyDown(KeyCode.E) && seedlingCount > 0)
//         // {
//         //     // Add the planter tile to the dictionary and mark it as planted
//         //     plantedTiles[planter.transform.position] = true;

//         //     // Increase the plant count
//         //     seedlingCount--;
//         //     Debug.Log("Seedling count: " + seedlingCount);
//         //     plantCount++;
//         //     Debug.Log("Total plants planted: " + totalPlantsPlanted);
//         // }
//     }

//     void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.gameObject.CompareTag("Seed"))
//         {
//             Destroy(other.gameObject);
//             seedlingCount++;
//             Debug.Log("Seedling count: " + seedlingCount);
//         }
//     }

//     //     private Vector3? CalculatePlantPosition()
//     //     {
//     //         // Radius of the circle to check for planter tiles
//     //         float radius = 1f;

//     //         // Check for any colliders within the radius
//     //         Collider2D hit = Physics2D.OverlapCircle(transform.position, radius);

//     //         // If a collider was found and it has the "Planter" tag and it hasn't been planted yet
//     //         if (hit != null && hit.tag == "Planter" && !plantedTiles.ContainsKey(hit.transform.position))
//     //         {
//     //             // Add the planter tile to the dictionary and mark it as planted
//     //             plantedTiles[hit.transform.position] = true;

//     //             // Return the position of the planter tile
//     //             return hit.transform.position;
//     //         }

//     //         // If no planter tile was found or it has already been planted, return null
//     //         return null;
//     //     }

//     // }
//     private Collider2D CalculatePlantPosition()
//     {
//         // Decrease the radius of the circle to check for planter tiles
//         float radius = 0.5f;

//         // Check for any colliders within the radius
//         Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);

//         foreach (var hit in hits)
//         {
//             // If the collider has the "Planter" tag and it hasn't been planted yet
//             if (hit.tag == "Planter" && !plantedTiles.ContainsKey(hit.transform.position))
//             {
//                 // Return the planter tile
//                 return hit;
//             }
//         }

//         // If no planter tile was found or it has already been planted, return null
//         return null;
//     }

//     void OnDrawGizmos()
//     {
//         // Draw a wire sphere at the player's position with the radius used for the OverlapCircle
//         Gizmos.DrawWireSphere(transform.position, 0.5f);
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlantInteract : MonoBehaviour
{
    public int seedlingCount = 0;
    public Animator animator;
    public GameObject plantPrefab;

    public int seedlingPlanted = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && seedlingCount > 0)
        {
            Collider2D plantCollider = CalculatePlantPosition();
            if (plantCollider != null)
            {
                Planter planter = plantCollider.gameObject.GetComponent<Planter>();
                if (planter != null && planter.isPlanted == false)
                {
                    planter.Plant();
                    seedlingCount--;
                    seedlingPlanted++;
                }
            }
        }

        if(seedlingPlanted == 10)
        {
            // Win the game
            Debug.Log("You win!");
            // load the win scene
            SceneManager.LoadScene("WinScene");
        }
    }

    private Collider2D CalculatePlantPosition()
    {
        float radius = 0.5f;
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (var hit in hits)
        {
            if (hit.tag == "Planter")
            {
                return hit;
            }
        }
        return null;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Seed"))
        {
            Destroy(other.gameObject);
            seedlingCount++;
        }
    }
}
