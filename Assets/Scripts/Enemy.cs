using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float enemySpeed = 3f;
    [SerializeField] private float stopDistance = 5f;
    
    bool gameOver = false;

    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();   // FindWithTag() scans all object in scene and extracts tag we input.

    }

    void Update()
    {
        if(target != null)
        {
            transform.LookAt(target);
            float distance = Vector3.Distance(transform.position, target.position);  // Vector3.Distance() gives us the distance between two vectors
            if (distance > stopDistance)
            {
                transform.position += transform.forward * Time.deltaTime * enemySpeed;

            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            TimeManager timeManager = FindObjectOfType<TimeManager>();
            timeManager.gameOver = true;
        }
    }
}
