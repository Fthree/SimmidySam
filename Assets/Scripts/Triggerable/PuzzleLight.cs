using UnityEngine;
using System.Collections;

public class PuzzleLight : MonoBehaviour {

    public Material on;
    public Material off;

    public bool status;
    bool wasOn;

	// Use this for initialization
	void Start () {
        GetComponent<MeshRenderer>().material = off;
        GetComponentInChildren<Light>().intensity = 0f;
        wasOn = false;
        status = false;

        Triggerable triggerEvent = GetComponent<Triggerable>();
        triggerEvent.OnTrigger += trigger;
    }
	
	// Update is called once per frame
	void Update () {
	    if(status && !wasOn)
        {
            GetComponent<Renderer>().material = on;
            GetComponentInChildren<Light>().intensity = 1.5f;
            wasOn = true;
        } 
        else if (!status && wasOn)
        {
            GetComponent<Renderer>().material = off;
            GetComponentInChildren<Light>().intensity = 0f;
            wasOn = false;
        }
    }

    public void trigger()
    {
        status = !status;
    }
}
