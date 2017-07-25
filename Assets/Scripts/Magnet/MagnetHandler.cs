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

    public float magnetForce = 5f;
    public float magneticActingDistance = 1.5f;

    void Update()
    {

        foreach (var currentMagnet in magnets)
        {
            Rigidbody rigidBody = currentMagnet.getGameObject().GetComponent<Rigidbody>();
            
            if (rigidBody == null)
            {
                continue;
            }

            Vector3 currentMagPos = currentMagnet.getGameObject().transform.position;

            foreach (var testingMagnet in magnets)
            {
                if(currentMagnet == testingMagnet)
                {
                    continue;
                }

                Vector3 testingMagPos = testingMagnet.getGameObject().transform.position;

                float distance = Vector3.Distance(currentMagPos, testingMagPos);

                if(distance > magneticActingDistance)
                {
                    continue;
                }

                float force = magnetForce * distance;
                Vector3 heading = currentMagPos - testingMagPos;
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
        }
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
