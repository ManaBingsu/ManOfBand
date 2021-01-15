using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DdongPrefab : MonoBehaviour {

    [SerializeField]
    SystemMain systemMain;

    private void Start()
    {
        transform.position = new Vector3(Random.Range(0f, 1280f / 32f), Random.Range(5.7f, 6.2f), -5.0f);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Map")
        {

          transform.position = new Vector3(Random.Range(0f,1280f/32f),Random.Range(5.7f,6.2f), -5.0f);
       
        }

        if(col.gameObject.tag == "Player")
        {
            systemMain.CollideToEnemy();
            transform.position = new Vector3(Random.Range(0f, 1280f / 32f), Random.Range(5.7f, 6.2f), -5.0f);
        }
    }
}
