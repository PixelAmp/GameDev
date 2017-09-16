using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb; //variabe to hold refrence
    private int count; //hold how many objects were picked up


    public float speed; //shows up in inspector as an editable property
    public Text countText;//holds score data
    public Text winText; //holds Text at the end of the game
    public int colCount; //holds how many collectables there are

    void Start () //called at the first frame of the game
	{
		rb = GetComponent<Rigidbody> (); //finds and returns a reference to the attached rigid body if there is one
        count = 0; //Sets count to 0 at beggining of game
        SetCountText (); //sets text information
        winText.text = ""; //display nothing at first
        Cursor.lockState = CursorLockMode.Locked; //turns off cursor so it is not seen during gameplay
    }

	void FixedUpdate () //called before performing physics calculations
	{
		float moveHorizontal = Input.GetAxis ("Horizontal"); //grabs horizontal input from keyboard
		float moveVertical = Input.GetAxis ("Vertical"); //grabs vertical input from keyboard
	
		Vector3 movement = new Vector3 (moveHorizontal /* x direction */, 0.0f /* y direction (up and down)*/ , moveVertical /* z direction*/); //creates new 3-d vector used to determine direction of force

		rb.AddForce (movement * speed); //controls the forces on the object

        if (Input.GetKeyDown("escape")) //unlocks mouse after pressing escape key
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void OnTriggerEnter(Collider other) //Called when object toushes trigger collider
    {
        if (other.gameObject.CompareTag("Pick Up")) //if object has pickup tag
        {
            other.gameObject.SetActive(false); //deactivates object
            count++; //increments objects picked up
            SetCountText(); //updates text information
        }
    }


    void SetCountText() //function to update score information
    {
        countText.text = "Count: " + count.ToString(); //sets text information
        if (count >= colCount)
            winText.text = "You Win!";
    }
}
