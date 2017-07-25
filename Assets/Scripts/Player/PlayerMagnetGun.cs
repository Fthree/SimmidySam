using UnityEngine;
using UnityEditor;
using System.Collections;

public class PlayerMagnetGun : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public MagneticObject currentMagnet;
    public MagnetType type;
    public KeyCode code;

    bool leftClick, rightClick;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(code))
        {
            leftClick = true;
        }
        if (Input.GetKeyUp(code))
        {
            leftClick = false;
        }

        if (currentMagnet != null)
        {
            Vector3 heading = currentMagnet.transform.position - transform.position;
            GetComponentInParent<Rigidbody>().AddForce(heading * 5);
        }

        if (leftClick || rightClick)
        {
            Ray ray = new Ray(transform.position, transform.forward);

            RaycastHit[] hits = Physics.RaycastAll(ray);
            foreach (var hit in hits)
            {
                MagneticObject magObj = hit.collider.GetComponent<MagneticObject>();
                if (magObj != null)
                {
                    if (magObj.type == type && magObj != currentMagnet)
                    {
                        //Vector3 heading = magObj.transform.position - transform.position;
                        //GetComponentInParent<Rigidbody>().AddForce(heading * 5);
                        currentMagnet = magObj;
                        return;
                    }
                }
            }
        }
    }
    
    public void clearMagnet()
    {
        currentMagnet = null;
    }
}
