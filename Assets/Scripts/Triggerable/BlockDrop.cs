﻿using UnityEngine;
using System.Collections;

public class BlockDrop : MonoBehaviour {

    public void Start()
    {
        GetComponent<Triggerable>().OnTriggerWithObject += trigger;
    }

	// Use this for initialization
	public void trigger(GameObject gravityCube) {
        Rigidbody body = gravityCube.GetComponent<Rigidbody>();
        body.transform.position = transform.position;
        body.velocity = new Vector3();
	}
}
