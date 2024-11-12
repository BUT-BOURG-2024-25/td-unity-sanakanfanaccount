using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using System;

public class SpawnEnnemys : MonoBehaviour
{

    private int spawnTimer = 0;
    private int cpt = 0;

    private float ennemySpeed = 1;

    private System.Random random = new System.Random();


    [SerializeField]
    private BoxCollider spawnPlane = null;
    [SerializeField]
    private GameObject ennemy = null;
    [SerializeField]
    private Vector2 timeSpawn = new Vector2();
    [SerializeField]
    private float minMercyDistance = 5f;

    private Vector2 rangeSpawnX = new Vector3();
    private Vector2 rangeSpawnY = new Vector3();


    private GameObject player = null;

    void Start()
    {
        spawnTimer = random.Next((int)(timeSpawn.x/Time.deltaTime), (int)(timeSpawn.y/Time.deltaTime));
        player = GameObject.FindGameObjectWithTag("Player");
        rangeSpawnX = new Vector2(-spawnPlane.transform.localScale.x/2, spawnPlane.transform.localScale.x/2);
        rangeSpawnY = new Vector2(-spawnPlane.transform.localScale.z / 2, spawnPlane.transform.localScale.z/2);

        Debug.Log(spawnTimer+" "+Time.deltaTime);

}

void Update()
    {
        //Debug.Log(cpt+" "+spawnTimer);
        cpt++;
        if(cpt>= spawnTimer)
        {
            cpt = 0;
            spawnTimer = random.Next((int)(timeSpawn.x / Time.deltaTime), (int)(timeSpawn.y / Time.deltaTime));

            Vector3 ennemyPos = new Vector3(random.Next((int)rangeSpawnX.x, (int)rangeSpawnX.y), spawnPlane.transform.position.y + ennemy.transform.localScale.y / 2, random.Next((int)rangeSpawnY.x, (int)rangeSpawnY.y));

            while(Vector3.Distance(ennemyPos, player.transform.position) < minMercyDistance)
            {
                Debug.Log(ennemyPos.ToString() + " " + player.transform.position);
                if (minMercyDistance > rangeSpawnX.y && minMercyDistance > rangeSpawnY.y)
                {
                    break;
                }
                ennemyPos = new Vector3(random.Next((int)rangeSpawnX.x, (int)rangeSpawnX.y), spawnPlane.transform.position.y + ennemy.transform.localScale.y / 2, random.Next((int)rangeSpawnY.x, (int)rangeSpawnY.y));
            }   


            GameObject.Instantiate(ennemy, ennemyPos, Quaternion.identity);
        }
    }
}
