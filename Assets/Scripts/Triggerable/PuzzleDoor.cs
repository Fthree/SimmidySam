using UnityEngine;

public class PuzzleDoor : MonoBehaviour {

    public bool status = false;
    bool wasOpen = false;

	// Use this for initialization
	void Start () {
        Triggerable triggerEvent = GetComponent<Triggerable>();
        triggerEvent.OnTrigger += trigger;
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
