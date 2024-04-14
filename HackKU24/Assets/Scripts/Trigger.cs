using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Scene to Load")]
    [SerializeField] private SceneField _next;

    void Start()
    {
        
    }

    // Update is called once per frame
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(_next, LoadSceneMode.Single);
        }
    }
}
