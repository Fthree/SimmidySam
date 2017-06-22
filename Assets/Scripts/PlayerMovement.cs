using UnityEngine;
using System.Collections;

public class PlayerMovement  {

    // Use this for initialization
    public void Start () {
	
	}

    public bool forward = false, backward = false, left = false, right = false, jump = false, isJumping = false;

    // Update is called once per frame
    public void Update () {
        if (Input.GetKeyDown(KeyCode.W))
        {
            forward = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            backward = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            left = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            right = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jump = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            right = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            left = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            backward = false;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            forward = false;
        }
    }
}
