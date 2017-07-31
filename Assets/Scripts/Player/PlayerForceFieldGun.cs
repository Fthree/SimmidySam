using UnityEngine;
using System.Collections;

public class PlayerForceFieldGun : MonoBehaviour {

    private GravityCube currentlyHeldCube;
    public Camera camera;
    public float forwardForce = 500f;
    public float upForce = 1.1F;
    public float cursorOffset = 20f;

    // Use this for initialization
    void Start () {
	
	}

    bool clicked = false;

	// Update is called once per frame
	void Update () {
        //Keep object in front of player
        if(currentlyHeldCube != null)
        {
            Vector3 forwardPlus = transform.position + transform.forward;
            currentlyHeldCube.transform.position = forwardPlus;
            currentlyHeldCube.transform.rotation = new Quaternion();
            //currentlyHeldCube.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(5f, 7f), Random.Range(5f, 7f), Random.Range(5f, 7f)), ForceMode.Impulse);
        }

        //Pickup object
	    if(Input.GetMouseButtonDown(0) && !clicked && currentlyHeldCube == null)
        {
            clicked = true;
            Ray ray = new Ray(transform.position, transform.forward);
            Debug.DrawRay(transform.position, transform.forward);
            RaycastHit[] hits = Physics.RaycastAll(ray, 100f);

            //Get all possible hits
            foreach(var hit in hits)
            {
                GravityCube hitCube = hit.collider.GetComponent<GravityCube>();
                //Is this an object that can be managed by the forcefield gun?
                if (hitCube != null)
                {
                    currentlyHeldCube = hitCube;
                    return;
                }
            }
        }
        //Throw object
        else if (Input.GetMouseButtonDown(0) && !clicked && currentlyHeldCube != null)
        {
            Vector3 forwardForce = transform.forward;
            forwardForce.y += 0.35f;
            currentlyHeldCube.GetComponent<Rigidbody>().velocity = forwardForce  * 15;
            //currentlyHeldCube.GetComponent<Rigidbody>().AddTorque(new Vector3(10f, 0f, 0f));
            currentlyHeldCube = null;
        }
        //drop
        else if (Input.GetMouseButtonDown(1) && !clicked && currentlyHeldCube != null)
        {
            Vector3 forwardForce = transform.forward;
            currentlyHeldCube.GetComponent<Rigidbody>().velocity = forwardForce * 1;
            currentlyHeldCube = null;
        }


        if (Input.GetMouseButtonUp(0) && clicked)
        {
            clicked = false;
        }

    }

    void OnGUI()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit[] hit;
        hit = Physics.RaycastAll(ray, 100f);
        Rect drawingRect;
        if (hit.Length == 0 || currentlyHeldCube != null && hit.Length == 1)  
        {
            drawingRect = new Rect(Screen.width / 2, Screen.height / 2, 150, 150);
            GUI.Label(drawingRect, "+");
            return;
        }
        if (hit[0].collider != null && currentlyHeldCube == null)
        {
            Vector3 screenPoint = camera.WorldToScreenPoint(hit[0].point);
            drawingRect = new Rect(screenPoint.x - cursorOffset, Screen.height - (screenPoint.y + cursorOffset), 150, 150);
            GUI.Label(drawingRect, "o");
        }
        else if (hit[0].collider.GetComponent<GravityCube>() == currentlyHeldCube)
        {
            Vector3 screenPoint = camera.WorldToScreenPoint(hit[1].point);
            drawingRect = new Rect(screenPoint.x - cursorOffset, Screen.height - (screenPoint.y + cursorOffset), 150, 150);
            GUI.Label(drawingRect, "o");
            return;
        }
        else if (hit[0].collider != null && currentlyHeldCube != null) {
            Vector3 screenPoint = camera.WorldToScreenPoint(hit[0].point);
            drawingRect = new Rect(screenPoint.x - cursorOffset, Screen.height - (screenPoint.y + cursorOffset), 150, 150);
            GUI.Label(drawingRect, "o");
        }
    }
}
