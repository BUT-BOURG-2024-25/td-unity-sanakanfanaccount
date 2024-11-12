using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAllCubes : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");

        foreach (GameObject cube in cubes)
        {
            Destroy(cube);
        }
    }
}
