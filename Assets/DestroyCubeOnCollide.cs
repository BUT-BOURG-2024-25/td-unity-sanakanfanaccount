using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCubeOnCollide : MonoBehaviour
{

    [SerializeField]
    GameObject gameobject;
    public void OnCollisionEnter(Collision collision)
    {
        if(gameobject!=null && collision.gameObject.layer != gameobject.layer)
        Destroy(gameobject);
    }
}
