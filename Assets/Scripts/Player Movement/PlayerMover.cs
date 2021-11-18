using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    void Update()
    {
        if ( GameManager.Instance.gameState != GameManager.GameState.Playing ) return;
        transform.Translate(0, 0, Time.deltaTime * speed);
    }
}
