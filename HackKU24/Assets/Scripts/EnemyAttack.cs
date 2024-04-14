
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damageAmount = 10;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Goblin"))
        {
            HealthManager healthManager = other.gameObject.GetComponent<HealthManager>();
            if (healthManager != null)
            {
                healthManager.Damage(damageAmount);
                //show debug
                Debug.Log("Goblin has been attacked");
            }
        }
    }
}
