using UnityEngine;
using System.Collections;

public class PlayerGun : MonoBehaviour {

    public Bullet blueMagnetBall;
    public Bullet orangeMagnetBall;
    private Bullet blueMagnetInstance;
    private Bullet orangeMagnetInstance;
    public GameObject bulletReleasePoint;

    public float force = 1000f;
    public int maxMagnets = 5;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    //if(Input.GetMouseButtonDown(0) )
     //   {
     //       if (blueMagnetInstance != null)
     //       {
     //           blueMagnetInstance.Destroy();
     //       }
     //       blueMagnetInstance = Instantiate(blueMagnetBall, bulletReleasePoint.transform.position, bulletReleasePoint.transform.rotation) as Bullet;
     //       blueMagnetInstance.Create(MagnetType.BLUE, force);
     //   }
        if (Input.GetMouseButtonDown(1))
        {
            //if (orangeMagnetInstance != null)
            //{
            //    orangeMagnetInstance.Destroy();
            //}
            orangeMagnetInstance = Instantiate(orangeMagnetBall, bulletReleasePoint.transform.position, bulletReleasePoint.transform.rotation) as Bullet;
            orangeMagnetInstance.Create(MagnetType.ORANGE, force);
        }
    }


}
