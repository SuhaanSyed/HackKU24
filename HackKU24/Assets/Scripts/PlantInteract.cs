using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantInteract : MonoBehaviour
{
    // Start is called before the first frame update
    // current player rigid body
    public Rigidbody2D player;

    public int seedlingCount = 0;
    public Animator animator;
    public GameObject plantPrefab;
    PlayerController playerController;
    
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && seedlingCount > 0)
        {
            
            // calculate a position 1 unit in front of the player
            Vector3 plantPosition = CalculatePlantPosition();
            // instantiate the plant at the calculated position and the player's rotation
            GameObject plant = Instantiate(plantPrefab, plantPosition, transform.rotation);
            // decrease the seedling count
            Animator plantAnimator = plant.GetComponent<Animator>();
            if (plantAnimator != null)
            {
                plantAnimator.SetBool("planted", true);
            }
            seedlingCount--;
            Debug.Log("Seedling count: " + seedlingCount);
            // trigger the planting animation
            //animator.SetTrigger("Plant");
            
            
        }   
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Seed"))
        {
            Destroy(other.gameObject);
            seedlingCount++;
            Debug.Log("Seedling count: " + seedlingCount);
        }
    }

    private Vector3 CalculatePlantPosition()
    {
        Vector3 offset;
        Vector2 movementInput = playerController.GetMovementInput();
        if (movementInput.x > 0) // facing right
        {
            offset = Vector3.right;
        }
        else if (movementInput.x < 0) // facing left
        {
            offset = Vector3.left;
        }
        else if (movementInput.y > 0) // facing up
        {
            offset = Vector3.up;
        }
        else // facing down
        {
            offset = Vector3.down;
        }
        return transform.position + offset;
    }

}
