using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    private Vector3 movement;
    [SerializeField] float speed = 10f;
    [SerializeField] Rigidbody rigidbody;
   

    void Start()
    {
        
    }

    void Update()
    {
        Movement();

    }


    void Movement()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        movement = new Vector3(x, 0f, z);
        //transform.position += movement;
        rigidbody.AddForce(movement);



    }



}
