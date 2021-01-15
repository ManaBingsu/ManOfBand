using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : MonoBehaviour {

    [SerializeField]
    private Camera cam;
    [SerializeField]
    private GameObject player;

    private float camSize;
    private Vector3 playerLoc = new Vector3(0f, 0f, 0f);

    

    /*private void Start()
    {
        camSize = 320f / (((320f / 180f) * 2f) * 32f);
        cam.orthographicSize = camSize;
        transform.position = new Vector3(5f, camSize, -10f);
    } //지울것*/

    public void CameraSize()
    {
        camSize = 320f / (((320f / 180f) * 2f) * 32f);
        cam.orthographicSize = camSize;
        //transform.position = new Vector3(5f, camSize, -10f); <- (0,0)
        //transform.position = new Vector3(15f, camSize, -10f); <- (1280, 0)
    } // 카메라 해상도 조절용

    public void FollowPlayer()
    {
        Vector3 playerPos = new Vector3(player.transform.position.x, camSize, -10);

        if (player.transform.position.x <= 5f)
        {
            playerLoc = new Vector3(5f, camSize, -10f);
            transform.position = Vector3.Lerp(transform.position, playerLoc, Time.deltaTime * 4f);
        }
        else if (player.transform.position.x >= 35f)
        {
            playerLoc = new Vector3(35f, camSize, -10f);
            transform.position = Vector3.Lerp(transform.position, playerLoc, Time.deltaTime * 4f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, playerPos, Time.deltaTime * 4f);
        }


    } // 플레이어 추적 카메라

  

}
