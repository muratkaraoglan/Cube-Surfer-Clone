using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Preparing,
        Playing,
        Fail,
        LevelUp
    }

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }


    public GameState gameState;
    [Header("--------------------UI--------------------")]
    public GameObject playPanel;
    public GameObject failPanel;
    public GameObject levelUpPanel;
    public TMPro.TextMeshProUGUI scoreText;

    [Header("-----------------Random Generate Objects-----------------")]
    public GameObject collectablePrefab;
    public GameObject obstaclePrefab;

    bool levelGenerate = false;
    public int level;
    public int cubeSpawnCount;
    public int obstacleSpawnCount;
    private void Awake()
    {
        if ( instance != null && instance != this )
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        gameState = GameState.Preparing;
    }

    private void Update()
    {
        switch ( gameState )
        {
            case GameState.Preparing://Generate Map
                GenerateLevel();
                break;
            case GameState.Fail://Game ove reload scene
                Fail();
                break;
        }
    }


    public void Play()
    {
        gameState = GameState.Playing;
        playPanel.SetActive(false);
    }

    void GenerateLevel()
    {
        if ( !levelGenerate )
        {
            for ( int i = 0; i < cubeSpawnCount; i++ )
            {
                int cubeCountPerLine = Random.Range(1, level);
                int z = (i + 1) * 8;
                if ( (i + 1) % 3 == 0 )
                {
                    int scaleY = Random.Range(1, level);
                    GameObject go = Instantiate(obstaclePrefab, new Vector3(0f, 0.5f * scaleY, z), Quaternion.identity);
                    go.transform.localScale += new Vector3(0f, scaleY - 1, 0f);
                }
                else
                {

                    for ( int j = 0; j < cubeCountPerLine; j++ )
                    {
                        int x = Random.Range(-4, 5);
                        Vector3 spanwPos = new Vector3(x, 0.5f, z);
                        Instantiate(collectablePrefab, spanwPos, Quaternion.identity);
                    }
                }

            }
        }
        levelGenerate = true;
    }

    void Fail()
    {
        if ( !failPanel.activeInHierarchy )
        {
            Debug.Log("Fail");
            failPanel.SetActive(true);
        }
    }

    public void LevelUp(int cubeCount)
    {
        //level up panel and show cube count
        if ( !levelUpPanel.activeInHierarchy )
        {
            Debug.Log("Level Up");
            levelUpPanel.SetActive(true);
            scoreText.text = "Score: " + cubeCount.ToString();
        }
    }

    public void LevelUpLoadScene()
    {
        int scene;
        if ( PlayerPrefs.GetInt("Level", 1) == 5 )
        {
            scene = Random.Range(1, 6);
        }
        else
        {
            scene = level + 1;
            PlayerPrefs.SetInt("Level", scene);
        }
        SceneManager.LoadScene(scene);
    }

    public void FailReloadScene()
    {
        SceneManager.LoadScene(level);
    }
}