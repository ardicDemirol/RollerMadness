using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{

    public int scoreAmount = 2;

    [SerializeField] private GameObject deadEffect;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.score += scoreAmount;

            Destroy(gameObject); /// Destroys this game object 
                                 /// Destroy(other.gameObject) => Destroys the object that collided with this object

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.score += scoreAmount;

            Destroy(gameObject);

        }

    }

    private void OnDisable()
    {
        Instantiate(deadEffect, transform.position, transform.rotation);
    }
}
