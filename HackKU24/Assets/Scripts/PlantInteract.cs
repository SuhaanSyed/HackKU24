using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantInteract : MonoBehaviour
{
    // Start is called before the first frame update
    // current player rigid body
    public Rigidbody2D player;

    public int seedlingCount = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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


}
