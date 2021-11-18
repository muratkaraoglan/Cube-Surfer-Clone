using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private Stacker stacker;

    private void Awake()
    {
        stacker = GetComponentInParent<Stacker>();
    }
    bool wallChecked = false;
    private void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("Collectable") )
        {
            //stacker.Add(other.transform.parent.gameObject);
            stacker.Add();
            Destroy(other.transform.parent.gameObject);
            wallChecked = false;
        }
        else if ( other.CompareTag("Obstacle") && !wallChecked )
        {
            if ( stacker.CubeCount() != 0 && stacker.CubeCount() > other.transform.localScale.y )
            {
                Debug.Log("Wall checked " + stacker.CubeCount());
                wallChecked = true;
                return;
            }
            GameManager.Instance.gameState = GameManager.GameState.Fail;
        }
        else if ( other.CompareTag("Finish") )
        {
            if ( stacker.CubeCount() != 0 )
            {
                GameManager.Instance.gameState = GameManager.GameState.LevelUp;
                GameManager.Instance.LevelUp(stacker.CubeCount());
            }
            else
            {
                GameManager.Instance.gameState = GameManager.GameState.Fail;
            }
        }
    }
}
