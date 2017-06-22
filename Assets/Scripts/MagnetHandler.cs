using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MagnetHandler : MonoBehaviour
{
    static List<Magnet> magnets = new List<Magnet>();
    void Start()
    {
    }

    void Update()
    {
        magnets.ForEach(delegate (Magnet currentMagnet)
        {
            Rigidbody rigidBody = currentMagnet.getGameObject().GetComponent<Rigidbody>();

            magnets.ForEach(delegate (Magnet testingMagnet)
            {
                if (!currentMagnet.Equals(testingMagnet))
                {
                    Vector3 currentMagPos = currentMagnet.getGameObject().transform.position;
                    Vector3 testingMagPos = testingMagnet.getGameObject().transform.position;
                    float distance = Vector3.Distance(currentMagPos, testingMagPos);
                    Vector3 heading = currentMagPos - testingMagPos;
                    float force = 20 / distance;
                    heading.Scale(new Vector3(force, force, force));

                    //Same to same
                    if (currentMagnet.getMagnetType().Equals(testingMagnet.getMagnetType()))
                    {
                        rigidBody.AddForce(heading);
                    }
                    //different to different
                    else
                    {
                        rigidBody.AddForce(-heading);
                    }
                }
            });
        });
    }

    public static void RegisterMagnet(Magnet newMagnet)
    {
        magnets.Add(newMagnet);
    }

    public static void DeRegisterMagnet(Magnet currentMagnet)
    {
        magnets.Remove(currentMagnet);
    }
}
