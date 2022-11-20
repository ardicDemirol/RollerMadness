using System;
using UnityEngine;

public class Move : MonoBehaviour
{

    private Vector3 movement;
    [SerializeField] float speed = 10f;
    private Rigidbody rigidbody;
    private TimeManager timeManager;
    private TeleportManager teleportManager;
    private bool teleport = true;

    
    private bool isGround = true;
   
    [SerializeField] float jumpSpeed = 10f;




    [SerializeField] private GameObject deadEffect;



    void Start()
    {
       rigidbody = GetComponent<Rigidbody>(); 
       timeManager = FindObjectOfType<TimeManager>();
        teleportManager = FindObjectOfType<TeleportManager>();
    }

    void Update()
    {

        if(timeManager.gameOver == false && timeManager.gameFinished == false )
        {
            MoveThePlayer();
        }

        if(timeManager.gameOver || timeManager.gameFinished)
        {
            rigidbody.isKinematic = true;
        }

        // Debug.Log(rigidbody.velocity);   this line shows us the velocity vector of our player
    }


    void MoveThePlayer()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        float y = Input.GetAxis("Jump") * Time.deltaTime * jumpSpeed;

        movement = new Vector3(x, y, z);

        if (rigidbody.velocity.y == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody.AddForce(movement,ForceMode.Impulse);
            }
        }

        
        rigidbody.AddForce(movement);
    }




    private void OnDisable()
    {
        Instantiate(deadEffect, transform.position, transform.rotation);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Teleporter")
        {
            if (teleport)
            {
                teleport = false;
                int boxNum = Int16.Parse(other.name);

                transform.position = teleportManager.GetTeleportPosition(boxNum);
                rigidbody.velocity = Vector3.zero;
            }
            else Invoke("AllowToTeleport", 3f);
            
        }
    }

    private void AllowToTeleport()
    {
        teleport = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }





}
