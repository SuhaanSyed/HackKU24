using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    public Transform target;

    [SerializeField]
    public float speed = 1.0f;



    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
    }
}
