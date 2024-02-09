using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
   public float getNode(Vector3 position)
   {
        float x = position.x;
        float z = position.z;
        float combined = (x * 10) + z;
        return combined;
   }
}
