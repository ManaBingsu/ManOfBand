using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    [SerializeField]
    SystemMain systemMain;

    [SerializeField]
    GasiManager gasiManager;



    public int checkSpd = 0;   //아니네 속도 제어 용이구나

    public int checkDir = 1;



    public void playerMove(float spd)
    {

        if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0)
        {
            if (systemMain.Stun == false)
            {
                checkDir = 1;
                if (checkSpd == 0) { checkSpd = 1; }
                transform.Translate(Vector3.right * spd * Time.deltaTime);

            }
            else
            {
                checkDir = -1;
                if (checkSpd == 1) { checkSpd = 0; }
                transform.Translate(Vector3.left * spd * Time.deltaTime);

            }

        }
        else
        {
            checkDir = -1;
            if (checkSpd == 1) { checkSpd = 0; }
            transform.Translate(Vector3.left * spd * Time.deltaTime);



        }
    } //스페이스바를 통한 이동



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Gasi" && gasiManager.gasiOn == true)
        {
            systemMain.CollideToEnemy();
        }
        
    }


}
