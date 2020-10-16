using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float ForceMultiplier;

    private float _moveHorizontal, _moveVertical;
    private Rigidbody _rigidbody;
    
    // Each time script is loaded
    private void Awake()
    {
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Update is called 60 times per second
    // Good for physics
    private void FixedUpdate()
    {
        _moveHorizontal = Input.GetAxis("Horizontal") * ForceMultiplier;
        _moveVertical = Input.GetAxis("Vertical") * ForceMultiplier;
        
        _rigidbody.AddForce(_moveHorizontal, 0, _moveVertical, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScoreObject"))
        {
            // Destroy
            Destroy(other.gameObject);
            // Increase Score
            // Check if 100
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Hazard"))
            Debug.Log("Ouch!");
    }
}
