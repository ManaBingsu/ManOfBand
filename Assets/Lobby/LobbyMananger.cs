using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyMananger : MonoBehaviour {


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Screen.SetResolution(1280, 720, true);  //해상도설정
        Application.targetFrameRate = 60;       //안드로이드 환경에서 60프레임 고정 vsync 퀄러티는 아직 신경 안씀
    }
    // Use this for initialization
    void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
