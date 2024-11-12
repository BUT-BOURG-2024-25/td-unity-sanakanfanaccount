using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    Vector3 distance = new Vector3(0, 4f, -4f);
    GameObject player = null;
    GameObject camera = null;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        camera.transform.Rotate(0, 0, 0);
    }

    private void Update()
    {
        if (player != null)
            camera.transform.position = player.transform.position + distance;           
    }
}
