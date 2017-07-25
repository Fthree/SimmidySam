using UnityEngine;
using System.Collections;

public class PuzzleDoor : MonoBehaviour {

    bool status = false;
    bool wasOpen = false;

	// Use this for initialization
	void Start () {
        GetComponentInChildren<Light>().intensity = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (status && !wasOpen)
        {
            GetComponent<Animator>().SetBool("IsOpen", status);
            wasOpen = true;
        }
        else if (!status && wasOpen)
        {
            GetComponent<Animator>().SetBool("IsOpen", status);
            wasOpen = false;
        }
    }

    public void trigger()
    {
        status = !status;
    }
}
