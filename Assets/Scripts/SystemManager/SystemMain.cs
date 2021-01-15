using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemMain : MonoBehaviour {

    [SerializeField]
    CameraMain cameraMain;
    [SerializeField]
    PlayerBehavior playerBehavior;
    [SerializeField]
    BandManager bandManager;
    [SerializeField]
    StaminaGazeManager sgm;
    [SerializeField]
    itemLifeManager iLM;


    [SerializeField]
    PlayerAnim headAnim;
    [SerializeField]
    PlayerAnim bodyAnim;
    [SerializeField]
    PlayerAnim legAnim;

    [SerializeField]
    GameObject band;

    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject stunMessage;
    [SerializeField]
    GameObject invin; // 무적나타내는 이상한 떨림
    [SerializeField]
    GameObject itemlifey; // 하트이름은 라이피~

    [SerializeField]
    GameObject head;
    [SerializeField]
    GameObject body;
    [SerializeField]
    GameObject leg;


    [SerializeField]
    GameObject life1;
    [SerializeField]
    GameObject life2;
    [SerializeField]
    GameObject life3;

    

    [SerializeField]
    SpriteRenderer PlayerStunSpr; //플레이어가 질린 얼굴을 한닷!

    //게임 핵심 변수 목록

    public float Stamina;
    public int Life;
    public int Score = 0;
    public bool Stun;
    public bool noDamage;

    private bool NoDamageBool;
    private bool STUNBool;
    //핵심변수 목록 끄읏

 
    private float playerSpd; // 플레이어의 속도

    public bool itemLife = true; //아이템 라이프가 존재하는지

    [SerializeField]
    Text scoreText;

   
    // Use this for initialization
    void Awake()
    {
        Screen.SetResolution(1280, 720, true);  //해상도설정
        Application.targetFrameRate = 60;       //안드로이드 환경에서 60프레임 고정 vsync 퀄러티는 아직 신경 안씀
    }

    void Start () {

        cameraMain.CameraSize();                        //카메라 픽셀보간용

        headAnim = head.GetComponent<PlayerAnim>();
        bodyAnim = body.GetComponent<PlayerAnim>();
        legAnim = leg.GetComponent<PlayerAnim>();

        PlayerStunSpr = player.GetComponent<SpriteRenderer>();

        Stun = false;
        STUNBool = false;
        noDamage = false;
        NoDamageBool = false;
        Stamina = 100f;
        Life = 3;

        StartCoroutine("createLife");
        StartCoroutine("SCORE");
	}
	
	// Update is called once per frame
	void Update () {

        scoreText.text = Score.ToString();


        checkSpd(playerBehavior.checkSpd);      //거리에 비례하여 플레이어 속도를 할당해줌
       
        cameraMain.FollowPlayer();              //플레이어 추적 카메라

        playerBehavior.playerMove(playerSpd);       //플레이어 속도 제어

        bandManager.resizeBand();                   //밴드 크기 조절
        sgm.resizeGaze();                           //스태미나바 크기조절

        headAnim.animate();
        bodyAnim.animate();
        legAnim.animate();

        checkLife();

        StaminaManager();
        StaminaLock();
    
        
    }

    void checkSpd(int dir)
    {
        if (dir == 0)
        {
            playerSpd = (player.transform.position.x - 24f / 32f) / (600f / 32f) * 15.0f;
        }
        else
        {
            if(player.transform.position.x < 1120f/32f)
            {
                playerSpd = 6.0f;
            }
            else
            {
                playerSpd = (600f / 32f) / (player.transform.position.x - 24f / 32f) * 2.0f;
            }
            
        }
    }   //속도 제어

    void checkLife()
    {
        if(Life ==  3)
        {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
        }
        else if(Life == 2)
        {
            life1.SetActive(false);
            life2.SetActive(true);
            life3.SetActive(true);
        }
        else if(Life == 1)
        {
            life1.SetActive(false);
            life2.SetActive(false);
            life3.SetActive(true);
        }
        else
        {
            life1.SetActive(false);
            life2.SetActive(false);
            life3.SetActive(false);
        }
    }   //라이프 존재하는지 체크

    IEnumerator createLife()
    {
        while(true)
        {
            if(itemLife == false)
            {
                itemlifey.SetActive(true);
                itemLife = true;
                iLM.StartCoroutine("jumping");
                itemlifey.transform.position = new Vector3(Random.Range(35.5f, 38.5f), 8f, 0f);
                
            }
           
            yield return new WaitForSeconds(Random.Range(9.0f, 12.0f));
        }
    }   //라이프 생성기

    public void hidelifey()
    {
        itemlifey.SetActive(false);
        itemLife = false;
    }       //라이프 비활성화

    public void CollideToEnemy()
    {

        if (noDamage == false)

        {
            if (STUNBool == true)
            {
                StopCoroutine("STUN");
                StartCoroutine("STUN");
            }
            else
            {
                StartCoroutine("STUN");
            }
        }
       
        

        if (noDamage == false)
        {
            if (Life > 0)
            {
                Life--;
            }

            if (NoDamageBool == true)
            {
                StopCoroutine("NoDamage");
                StartCoroutine("NoDamage");
            }
            else
            {
                StartCoroutine("NoDamage");
            }
           

        }
    }   //주인공 피격판정

    IEnumerator NoDamage()
    {
        NoDamageBool = true; //버프 갱신용으로 현재 코루틴이 실행되는지 체크
        invin.SetActive(true);

        noDamage = true;
        yield return new WaitForSeconds(1.0f);
        
        noDamage = false;
        NoDamageBool = false;
        StopCoroutine("NoDamage");
        invin.SetActive(false);
        yield return null;
    }//피격 후 약간의 무적

    IEnumerator STUN()
    {
        STUNBool = true; //버프 갱신용으로 현재 코루틴이 실행되는지 체크
        PlayerStunSpr.enabled = true;
        stunMessage.SetActive(true);

        
        Stun = true;
        
        yield return new WaitForSeconds((100f/Stamina)/2f * 0.5f + 0.3f);
        
        Stun = false;
        STUNBool = false;
        PlayerStunSpr.enabled = false;
        stunMessage.SetActive(false);
        StopCoroutine("STUN");
        yield return null;
    }   //스턴상태

    private void StaminaManager()
    {
        

        
            if (playerBehavior.checkDir == 1)
            {
                Stamina = Stamina - 12f * (player.transform.position.x / (800f / 32f)) * Time.deltaTime;
            }
            else
            {
                Stamina = Stamina + 24f * Time.deltaTime;
            }
        
      

    }       //스태미나 관리

    private void StaminaLock()
    {
        if (Stamina <= 0f)
        {
            Stamina = 0f;
            if (STUNBool == true)
            {
                StopCoroutine("STUN");
                StartCoroutine("STUN");
            }
            else
            {
                StartCoroutine("STUN");
            }
        }

        else if (Stamina >= 100f)
        {
            Stamina = 100f;
        }

    }       //스태미나 초과 방지

    IEnumerator SCORE()
    {
        while(true)
        {
            
            Score++;
            yield return new WaitForSeconds(1.0f/player.transform.position.x * 9.5f);
        }

    }
}
