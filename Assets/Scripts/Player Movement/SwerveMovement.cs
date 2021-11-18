using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    SwerveInput swerveInput;

    [SerializeField] private float speed = .5f;
    private float xRange = 4f;
    void Start()
    {
        swerveInput = GetComponent<SwerveInput>();
    }

    void Update()
    {
        if ( GameManager.Instance.gameState != GameManager.GameState.Playing ) return;
        float swerveAmount = swerveInput.GetDeltaX * Time.deltaTime * speed;
        if ( Mathf.Abs(swerveAmount + transform.position.x) > xRange ) return;
        transform.Translate(swerveAmount, 0, 0);
    }
}
