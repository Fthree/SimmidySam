using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public float currentX;
    public float currentY;

    public float minimumX = -75f;
    public float maximumY = 75f;
    public Quaternion quat;
    // Update is called once per frame
    void Update () {
        Vector3 current = GetComponentInParent<Rigidbody>().transform.rotation.eulerAngles;
        float oldX = currentX;
        currentX = currentX - Input.GetAxis("Mouse Y");

        quat = Quaternion.Euler(new Vector3(currentX, current.y + Input.GetAxis("Mouse X"), 0));
        quat = ClampRotationAroundXAxis(quat);
        GetComponentInParent<Rigidbody>().transform.rotation = quat;
    }

    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
        angleX = Mathf.Clamp(angleX, minimumX, maximumY);
        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }
}
