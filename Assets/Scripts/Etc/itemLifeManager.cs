using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemLifeManager : MonoBehaviour {

    Rigidbody2D rigid;
    [SerializeField]
    SystemMain systemMain;

	// Use this for initialization
	void Start () {

        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine("jumping");
		
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if(systemMain.Life < 3)
            {
                systemMain.Life++;
            }
            systemMain.hidelifey();
        }
    }

    IEnumerator jumping()
    {
        while(true)
        {
            rigid.velocity = new Vector3(0f, Random.Range(2.5f, 4f), 0f);
            yield return new WaitForSeconds(Random.Range(2.0f, 4.0f));
        }
       
    }
}
