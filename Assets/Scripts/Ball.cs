using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{   
    float _speed = 20f;//store a specified speed value.
    Rigidbody _rigidbody;//create a rigidbody object
    Vector3 _velocity;//create a 3D vector that will represent a velocity
    Renderer _renderer;
    
    // Start is called before the first frame update
    void Start()
    {
        //assign the Rigidbody component of the unity inspector to the variable called _rigidbody
        _rigidbody = GetComponent<Rigidbody>();
        //set speed of the Rigidbocy component from the unity inspector
        _renderer = GetComponent<Renderer>();
        Invoke("Launch", 0.5f);
    }

    void Launch()
    {
        _rigidbody.velocity = Vector3.up * _speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Physics based stuff should be in the FixedUpdate method (100 times per second by default in Unity)
    private void FixedUpdate() 
    {
        //assign a velocity to the _rigidbody variable
        _rigidbody.velocity = _rigidbody.velocity.normalized * _speed;
        //store the value calculated above
        _velocity = _rigidbody.velocity;

        //destroy the ball game object when it is not visible
        if(!_renderer.isVisible)
        {
            GameManager.Instance.Balls--;//deduct the amount of balls we have in the game manager
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        //reflect the velocity of the _rigidbody on collision relative to the collision plane
        _rigidbody.velocity = Vector3.Reflect(_velocity, collision.contacts[0].normal);


    }
}
