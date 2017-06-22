using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour, Magnet {
    public MagnetType type;
	
    public void Create(MagnetType type, float force)
    {
        this.type = type;
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * force);
        MagnetHandler.RegisterMagnet(this);
    }

    public void Destroy()
    {
        MagnetHandler.DeRegisterMagnet(this);
        Destroy(gameObject);
    }

    public GameObject getGameObject()
    {
        return gameObject;
    }

    public MagnetType getMagnetType()
    {
        return type;
    }
}
