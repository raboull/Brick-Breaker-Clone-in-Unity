using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    
    //lets define some variables
    public int hits = 1;//counter of how many times this Brick has been hit by the ball
    public int points = 100;//how many points are gained every time this brick is hit
    public Vector3 rotator;//vector that stores rotation values of this brick
    public Material hitMaterial;//reference to a hit material for this brick
    Material _orglMaterial;//go back to this material after this brick is hit
    Renderer _renderer;//responsible from showing this object on the screen

    // Start is called before the first frame update
    void Start()
    {
       //start rotations according to position of the brick
       transform.Rotate(rotator *(transform.position.x + transform.position.y)*0.1f);
       //set the initial material of this brick
       _renderer = GetComponent<Renderer>();//hook into the renderer component of this Brick
       _orglMaterial = _renderer.sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotator*Time.deltaTime);//rotate the brick objects constantly
    }

    private void OnCollisionEnter(Collision collision) 
    {
        hits--;//decrement the hits counter
        //logic to score points
        if (hits <= 0)
        {
            GameManager.Instance.Score += points;
            Destroy(gameObject);
        }
        //flash this object when hit
        _renderer.sharedMaterial = hitMaterial;
        Invoke("RestoreMaterial", 0.05f);    
    }

    void RestoreMaterial()
    {
        _renderer.sharedMaterial = _orglMaterial;
    }
}
