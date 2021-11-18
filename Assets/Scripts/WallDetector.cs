using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("Obstacle") )
        {
            transform.parent.parent.GetComponentInParent<Stacker>().Remove(transform.parent.parent.gameObject);
            Debug.Log("walldedected");
        }
       
    }
}
