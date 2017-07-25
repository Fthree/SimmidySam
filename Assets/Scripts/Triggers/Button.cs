using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public PuzzleLight puzzleLight;
    public PuzzleDoor puzzleDoor;
    public bool bounceBack;
    public bool isPressed;
    public float height;
    public float bounceBackForce = 150;

    GravityCube lastTouchingCube;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(isPressed)
        {
            height = lastTouchingCube.transform.position.y - transform.position.y;
            if (height < 1f)
            {
                float dist = Vector3.Distance(transform.position, lastTouchingCube.transform.position);
                if (dist < 1.5f)
                {
                    return;
                }
                
            }
            isPressed = false;
            GetComponent<Animator>().SetBool("IsPressed", isPressed);
        }

	}

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "GravityCube" && !isPressed)
        {
            isPressed = true;
            GetComponent<Animator>().SetBool("IsPressed", isPressed);
            
            collider.GetComponent<Rigidbody>().AddForce(transform.up * (bounceBack ? bounceBackForce : 0));
            puzzleLight.trigger();
            puzzleDoor.trigger();
            lastTouchingCube = collider.GetComponent<GravityCube>();
        }
    }
}
