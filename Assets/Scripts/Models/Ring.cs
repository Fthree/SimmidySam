using UnityEngine;
using System.Collections;

public class Ring : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter (Collider collider) {
        Debug.Log(collider.tag + " has Hit me");
        Rigidbody body = collider.GetComponent<Rigidbody>();

        Player player = collider.GetComponent<Player>();

        if(player != null)
        {
            player.clearCollisionObject();
        }

        collider.GetComponent<Rigidbody>().AddForce(body.transform.forward * 1000f);
        
	}
}
