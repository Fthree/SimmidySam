using UnityEngine;
using System.Collections;

public class BlockRespawn : MonoBehaviour {
    public BlockDrop drop;
	// Use this for initialization
	void OnTriggerEnter (Collider collider) {
        if(collider.tag.Equals("GravityCube"))
        {
            drop.trigger(collider.gameObject);
        }
        
	}
}
