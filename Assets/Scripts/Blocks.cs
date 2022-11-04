using UnityEngine;

public class Blocks : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private bool isCollided;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isCollided)
        {
            print(collision.gameObject.name);
            meshRenderer.material.color = Color.black;
            ///         if we want to change the color of we collide object, we can easily to this
            ///         
            ///         GetComponent<MeshRenderer>().material.color = Color.black;
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.score--;
            isCollided = true;

        }

    }
}
