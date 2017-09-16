using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

	// Update is called once per frame
	void Update ()
    {
        //rotates along selected axis
        //larger the number, faster the rotation
        transform.Rotate(new Vector3(0 , 30, 0) * Time.deltaTime); 
    }
}
