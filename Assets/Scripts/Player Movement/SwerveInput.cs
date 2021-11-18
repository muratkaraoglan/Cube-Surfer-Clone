using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveInput : MonoBehaviour
{
    private float inputX;
    private float deltaX;
    public float GetDeltaX => deltaX;
    void Update()
    {
        if ( Input.GetMouseButtonDown(0) )
        {
            inputX = Input.mousePosition.x;
        }
        else if ( Input.GetMouseButton(0) )
        {
            deltaX = Input.mousePosition.x - inputX;
            inputX = Input.mousePosition.x;
        }
        else
        {
            deltaX = 0f;
        }
    }
}
