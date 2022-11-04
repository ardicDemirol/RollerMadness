using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{

    public int scoreAmount = 2;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager.score += scoreAmount;

        Destroy(gameObject); /// Destroys this game object 
                             /// Destroy(other.gameObject) => Destroys the object that collided with this object
    }
}
