using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public float Density = 0.3f;
    private int currentHealth;
    private Animator animator;

    // get player transform
    public Transform player;

    

    // Start is called before the first frame update
    void Start()
    {
        // get component of Goblin
        
        
        currentHealth = maxHealth;
        // get current player's animator
        animator = player.GetComponent<Animator>();
        // animator.SetFloat("Density", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;

        //animator.SetFloat("density", (float)currentHealth / maxHealth);
        animator.SetFloat("density", Density);
    }

    private void Die()
    {
        // TODO: Add death animation or other effects here
        //Destroy(gameObject);
        Debug.Log("Goblin has died");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Damage(10); // Damage amount can be adjusted
        }
    }
}



/*
Can you help me write a enemy attack to object with Goblin tag? When the colliders contact the health slowly depletes by 10 points. To deplete the health the enemies invoke .damage function in goblin's healthmanager.cs script. 

*/