using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //create some variables
    Rigidbody _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        //hook the _rigidbody variable to the Rigidbody component of the object
        _rigidbody = GetComponent<Rigidbody>();
    }

    //use FixedUpdate method because we are dealing with physics
    void FixedUpdate()
    {
        //update the Player position to correspond with the mouse movement
        _rigidbody.MovePosition(new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,0,50)).x, -17, 0));
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
