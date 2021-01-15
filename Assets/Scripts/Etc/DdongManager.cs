using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DdongManager : MonoBehaviour {

    [SerializeField]
    GameObject[] ddong = new GameObject[15]; //원본 똥 오브젝트

    

    private int n = 0; //똥 배열수

	IEnumerator ddongTimer()
    {
        if(n<20)
        {
            n++;
        }
        else
        {
            n = 0;
        }
        ddongCreator();
        yield return new WaitForSeconds(Random.Range(0.3f, 0.9f));
    }

    void ddongCreator()
    {
        ddong[n].transform.position = new Vector3(Random.Range(0.0f, 640f/32f),180f/32f, -5f);
    }
}
