using UnityEngine;
using System.Collections;

public class PingPongDistance : MonoBehaviour {

    //direction to move
    public Vector3 MoveDir = Vector3.zero;

    //Speed to move (units per second)
    public float Speed = 0.0f;

    //Distance to travel in world units (before inverting direction and turning back)
    public float TravelDistance = 0.0f;

    //cache transform
    private Transform ThisTransform = null;

	// Use this for initialization
	IEnumerator Start () {
        //Get cached transform
        ThisTransform = transform;

        //Loop forever
        while (true)
        {
            //Invert direction
            MoveDir = MoveDir * -1;

            //Stard movement
            yield return StartCoroutine(Travel());
        }
	}

    //Travel full distance in direction, from current position
    IEnumerator Travel()
    {
        //Distrance travelled so far
        float DistanceTravelled = 0;

        //move
        while(DistanceTravelled < TravelDistance)
        {
            //Get new position based on speed and direction
            Vector3 DistToTravel = MoveDir * Speed * Time.deltaTime;

            //Update position
            ThisTransform.position += DistToTravel;

            //Ipdate distance travveled so far
            DistanceTravelled += DistToTravel.magnitude;

            //wait until next update
            yield return null;
        }
    }
}
