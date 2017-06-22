using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public float currentX;
    public float currentY;

    // Update is called once per frame
    void Update () {
        Vector3 current = GetComponentInParent<Rigidbody>().transform.rotation.eulerAngles;
        Quaternion newQuat = Quaternion.Euler(new Vector3(current.x -= Input.GetAxis("Mouse Y"), current.y += Input.GetAxis("Mouse X"), 0));
        GetComponentInParent<Rigidbody>().transform.rotation = newQuat;
    }
}
