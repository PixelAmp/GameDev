﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour {

    Rigidbody rb; //rigid body for the player character

    //public to allow speed to be changed
    public float speed = 10.0F;
    //controls sprint and crouch speed
    public float speedMult = 1.5f;
    //change jumpspeed
    public float jumpForce = 2.0f;
    //checks to see if player is on the ground
    public bool isGrounded;
    //max speed (fixes super jump)
    public float maxSpeed;
    //hold jump transform
    private Vector3 jump;

    public AudioClip[] AudioEffect;
    public AudioSource source;


    // Use this for initialization
    void Start ()
    {
        //turns off cursor so it is not seen during gameplay
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        source = GetComponent<AudioSource>();

    }

    void OnCollisionStay() //If object collides with something, it is grounded
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update ()
    {
        float translation = Input.GetAxis("Vertical") * speed; //gets input forwards and backwards
        float straffe = Input.GetAxis("Horizontal") * speed; //gets input left and right
        translation *= Time.deltaTime; //keeps movements smooth and in time with update
        straffe *= Time.deltaTime; //keeps movements smooth and in time with update

        transform.Translate(straffe /*z-axis*/, 0, translation/*x-axis*/);

        //half speed to crouch or return back to normal after sprint
        if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed/speedMult;
        }

        //double speed to normal after crouch or to sprint 
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= speedMult;
        }
        
        //adds jump function if player is in the ground
        if ((Input.GetButton("Jump")) && isGrounded)
        {
            isGrounded = false; //for some reason grounded isn't being updated until a second jump is completed ??????!?!?!???
            isGrounded = false;

            //adds upward force, using gravity to mke jump smooth 
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            PlaySound(0);
            isGrounded = false;
            isGrounded = false;
        }
        
        if (Input.GetKeyDown("escape")) //unlocks mouse after pressing escape key
        {
            Cursor.lockState = CursorLockMode.None;
        }
	}

    
    void OnTriggerEnter(Collider other) //Called when object touches trigger collider
    {
        print("checkpoint");
        if (other.gameObject.CompareTag("CP 1")) //if object has pickup tag
        {
            other.gameObject.SetActive(false); //deactivates object
            gameObject.GetComponent<PlayerHealth>().checkpoint++;
            //SetCountText(); //updates text information            
        }
       
        else if (other.gameObject.CompareTag("CP 2")) //if object has pickup tag
        {
            other.gameObject.SetActive(false); //deactivates object
            gameObject.GetComponent<PlayerHealth>().checkpoint++;
            //SetCountText(); //updates text information            
        }

        else if (other.gameObject.CompareTag("CP 3")) //if object has pickup tag
        {
            other.gameObject.SetActive(false); //deactivates object
            gameObject.GetComponent<PlayerHealth>().checkpoint++;
            //SetCountText(); //updates text information            
        }

        else if (other.gameObject.CompareTag("CP 4")) //if object has pickup tag
        {
            other.gameObject.SetActive(false); //deactivates object
            gameObject.GetComponent<PlayerHealth>().checkpoint++;
            //SetCountText(); //updates text information            
        }
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
            print(rb.velocity);
        }
    }

    public void PlaySound(int clip)
    {
        source.PlayOneShot(AudioEffect[clip]);
    }
}