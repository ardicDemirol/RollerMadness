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

    [SerializeField] private GameObject deadEffect;



    void Start()
    {
       rigidbody = GetComponent<Rigidbody>(); 
       timeManager = FindObjectOfType<TimeManager>();
        teleportManager = FindObjectOfType<TeleportManager>();
    }

    void Update()
    {

        if(timeManager.gameOver == false && timeManager.gameFinished == false)
        {
            MoveThePlayer();
        }

        if(timeManager.gameOver || timeManager.gameFinished)
        {
            rigidbody.isKinematic = true;
        }

        Debug.Log(rigidbody.velocity);
    }


    void MoveThePlayer()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        movement = new Vector3(x, 0f, z);
        //transform.position += movement;
        base.GetComponent<Rigidbody>().AddForce(movement);

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



}
