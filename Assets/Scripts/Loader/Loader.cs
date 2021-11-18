using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Loader : MonoBehaviour
{

    void Start()
    {
        int level = PlayerPrefs.GetInt("Level", 1);
        if ( level == 5 )
        {
            level = Random.Range(1, 6);
        }
        StartCoroutine(LoadLevel(level));
    }

    IEnumerator LoadLevel(int level)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }
}
