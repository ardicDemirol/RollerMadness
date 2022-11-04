using System;
using UnityEngine;

public class Move : MonoBehaviour
{

    private Vector3 movement;
    [SerializeField] float speed = 10f;
    private Rigidbody rigidbody;
   

    void Start()
    {
       rigidbody = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        MoveThePlayer();

    }


    void MoveThePlayer()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        movement = new Vector3(x, 0f, z);
        //transform.position += movement;
        base.GetComponent<Rigidbody>().AddForce(movement);

    }



}
