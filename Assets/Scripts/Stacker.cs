using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacker : MonoBehaviour
{
    [SerializeField] Transform stickMan;
    [SerializeField] GameObject cubePrefab;
    [SerializeField] private float currentHeight = 0.5f;
    private float height = 1f;
    List<GameObject> cubes = new List<GameObject>();
    //public void Add(GameObject newCube)
    //{//-9.81
    //    stickMan.localPosition = new Vector3(0f, currentHeight + height - .5f, 0f);
    //    newCube.transform.parent = transform;
    //    newCube.transform.localPosition = new Vector3(0f, currentHeight + 0.02f, 0f);
    //    cubes.Add(newCube);
    //    currentHeight += height;
    //}
    public void Add()
    {
        stickMan.localPosition = new Vector3(0f, currentHeight + height , 0f);
        GameObject go = Instantiate(cubePrefab);
        go.transform.parent = transform;
        go.transform.localPosition = new Vector3(0f, currentHeight, 0f);
        cubes.Add(go);
        currentHeight += height;
    }
    public void Remove(GameObject cube)
    {
        if ( CubeCount() != 0 )
        {
            cubes.Remove(cube);
            cube.transform.parent = null;
            currentHeight -= height;
        }
        //stickMan.localPosition = new Vector3(0f, currentHeight + height - .5f, 0f);
    }

    public int CubeCount() => cubes.Count;
}
