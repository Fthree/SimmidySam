using UnityEngine;
using System.Collections;

public class MagneticObject : MonoBehaviour, Magnet {

    public MagnetType type;

	// Use this for initialization
	void Start () {
        Create(type, 0f);
	}

    public void Create(MagnetType type, float force)
    {
        MagnetHandler.RegisterMagnet(this);
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
