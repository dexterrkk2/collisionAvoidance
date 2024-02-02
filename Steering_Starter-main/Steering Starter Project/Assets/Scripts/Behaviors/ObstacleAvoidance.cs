using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : Seek
{
    float lookAhead = 3f;
    float avoidDistance = 5f;
    protected override Vector3 getTargetPosition()
    {
        RaycastHit hit;
        if(Physics.Raycast(character.transform.position, character.linearVelocity, out hit, lookAhead))
        {
            return hit.point + (hit.normal * avoidDistance);
        }
        else
        {
            return base.getTargetPosition();
        }
    }
}
