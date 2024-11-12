using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed =0f;
    private GameObject player = null;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 playerPos = new Vector3(player.transform.position.x,this.transform.position.y, player.transform.position.z);

        gameObject.transform.LookAt(playerPos);

        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, playerPos,Time.deltaTime*moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision != null && collision.gameObject == player) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
