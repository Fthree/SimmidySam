using UnityEngine;
using System.Collections.Generic;

public class GravityCubeTrigger : MonoBehaviour {
    public List<Triggerable> triggerables;
	// Use this for initialization
	void OnTriggerEnter (Collider collider) {
        if(collider.tag.Equals("GravityCube"))
        {
            triggerables.ForEach((triggerable) => triggerable.trigger(collider.gameObject));
        }
	}
}
