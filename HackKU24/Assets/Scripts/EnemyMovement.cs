// using UnityEngine;

// public class EnemyMovement : MonoBehaviour
// {
//     [SerializeField]
//     public Transform target;


//     [SerializeField]
//     public float speed = 1.0f;



//     // Start is called before the first frame update
//     void Start()
//     {


//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (target != null)
//         {
//             Vector3 direction = target.position - transform.position;
//             transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
//         }
//     }
// }


// using UnityEngine;

// public class EnemyMovement : MonoBehaviour
// {
//     [SerializeField]
//     public Transform target;

//     [SerializeField]
//     public float speed = 1.0f;

//     // Start is called before the first frame update
//     void Start()
//     {
//         FindNearestTarget();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (target != null)
//         {
//             Vector3 direction = target.position - transform.position;
//             transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
//         }
//         else
//         {
//             FindNearestTarget();
//         }
//     }

//     void FindNearestTarget()
//     {
//         if (target == null) return;

//         GameObject[] targets = GameObject.FindGameObjectsWithTag(target.tag);
//         float closestDistance = Mathf.Infinity;
//         GameObject closestTarget = null;

//         foreach (GameObject currentTarget in targets)
//         {
//             float distanceToTarget = (currentTarget.transform.position - transform.position).sqrMagnitude;
//             if (distanceToTarget < closestDistance)
//             {
//                 closestDistance = distanceToTarget;
//                 closestTarget = currentTarget;
//             }
//         }

//         if (closestTarget != null)
//         {
//             target = closestTarget.transform;
//         }
//     }
// }

using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    public Transform target;

    [SerializeField]
    public float speed = 1.0f;

    private bool isMoving = true;

    // Start is called before the first frame update
    void Start()
    {
        FindNearestTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && isMoving)
        {
            Vector3 direction = target.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
        else
        {
            FindNearestTarget();
        }
    }

    void FindNearestTarget()
    {
        if (target == null) return;

        GameObject[] targets = GameObject.FindGameObjectsWithTag(target.tag);
        float closestDistance = Mathf.Infinity;
        GameObject closestTarget = null;

        foreach (GameObject currentTarget in targets)
        {
            float distanceToTarget = (currentTarget.transform.position - transform.position).sqrMagnitude;
            if (distanceToTarget < closestDistance)
            {
                closestDistance = distanceToTarget;
                closestTarget = currentTarget;
            }
        }

        if (closestTarget != null)
        {
            target = closestTarget.transform;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(target.tag) || other.gameObject.CompareTag("Plant"))
        {
            isMoving = false;
        }
    }
}