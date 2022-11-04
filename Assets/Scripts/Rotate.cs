using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField] private float x, y, z;
 // [SerializeField] private Vector3 angle;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(x, y, z,Space.World);
        //transform.Rotate(angle, Space.World);
    }
}
