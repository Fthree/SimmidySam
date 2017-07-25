using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float movementSpeed = 10;
    public float currentMovementSpeed;
    public float jumpForce = 200;
    public float jumpMovementSpeedDamper = 2;
    PlayerMovement playerMovement;
    public Vector3 speed;

    // Use this for initialization
    void Start()
    {
        PlayerStates.isJumping = false;
        PlayerStates.isMagnetized = false;
        playerMovement = new PlayerMovement();
        currentMovementSpeed = movementSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        playerMovement.Update();
        movePlayer();
	}

    void movePlayer()
    {
        Rigidbody playerRigidBody = GetComponent<Rigidbody>();
        Vector3 forwardDir = new Vector3(transform.forward.x, 0, transform.forward.z);
        if (playerMovement.forward)
        {
            playerRigidBody.AddForce(forwardDir.normalized * currentMovementSpeed);
        }
        if (playerMovement.backward)
        {
            playerRigidBody.AddForce(-forwardDir.normalized * currentMovementSpeed);
        }
        if (playerMovement.left)
        {
            playerRigidBody.AddForce(-transform.right * currentMovementSpeed);
        }
        if (playerMovement.right)
        {
            playerRigidBody.AddForce(transform.right * currentMovementSpeed);
        }
        if (playerMovement.jump && !PlayerStates.isJumping)
        {
            playerRigidBody.AddForce(new Vector3(0, transform.position.y, 0) * jumpForce);
            PlayerStates.isJumping = true;
            currentMovementSpeed = movementSpeed / jumpMovementSpeedDamper;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Platform"))
        {
            PlayerStates.isJumping = false;
            currentMovementSpeed = movementSpeed;
        }
    }

    public void clearCollisionObject()
    {
        foreach(var guns in GetComponentsInChildren<PlayerMagnetGun>())
        {
            guns.clearMagnet();
        }
    }
}
