using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 変数、定数
    // プレイヤー
    public GameObject player;
    private Animator anim;
    public float speed;
    private float x = 0, y = 0;
    // タッチ操作用
    private Vector3 touthStartPos;
    private Vector3 touthEndPos;
    // ショット、ビーム
    public GameObject shot;
    public GameObject beam;
    string Direction = null;
    // ビームのパワーと待機時間
    int BeamPower, BeamTime;
    // ショットのゲージと待機時間
    int ShotGauge, ShotTime;
    // ショットとビームの待機時間
    const int MaxShotTime = MAX_SHOT_TIME;
    const int MaxBeamTime = MAX_BEAM_TIME;
    private const int BEAM_MIN_POWER = 60;
    private const int SHOT_MAX_GAUGE = 15;
    private const int MAX_SHOT_TIME = 15;
    private const int MAX_BEAM_TIME = 4;
    // ビームを削除するためのリスト、インスタンス
    List<GameObject> list_beam = new List<GameObject>();
    GameObject beam_instance;
    // Audio scripte
    [SerializeField] GameObject SoundManager;
    SoundManager soundscripte;

    private void Start()
    {
        soundscripte = SoundManager.GetComponent<SoundManager>();
        transform.position = new Vector3(0, -4, 0);
        anim = GetComponent<Animator>();
    }

    //--------------------------------------------------------
    //タッチ処理
    //--------------------------------------------------------
    void Flick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
         //   soundscripte.GetComponent<SoundManager>().SE_shot();
            touthStartPos = new Vector3(Input.mousePosition.x,
                                        Input.mousePosition.y,
                                        Input.mousePosition.z
                                        );
           
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            // touthEndPos = new Vector3(Input.mousePosition.x,
            //                           Input.mousePosition.y,
            //                           Input.mousePosition.z
            //                           );


            // ボタンを離したとき:ビームを消す
            BeamPower = 0;
            for(int i = 0; i < list_beam.Count; i++)
            {
                Destroy(list_beam[i]);
            }
        }
          
        

        if(Input.GetKey(KeyCode.Mouse0)){
            touthEndPos = new Vector3(Input.mousePosition.x,
                                     Input.mousePosition.y,
                                     Input.mousePosition.z
                                     );
            // ビームのパワーとショットのゲージ
            const int BeamMinPower = BEAM_MIN_POWER;
            const int ShotMaxGauge = SHOT_MAX_GAUGE;

           

            // パワーが足りないとき:ショットを発射
            if (BeamPower < BeamMinPower)
            {
                BeamPower++;
                ShotGauge = ShotMaxGauge;

                if (ShotTime == 0)
                {

                    // SE_shotの再生
                    soundscripte.GetComponent<SoundManager>().SE_shot();

                    Instantiate(shot,
                    transform.position,
                    Quaternion.identity
                    );
 //                   Debug.Log("BeamTime : " + BeamTime + "BeamPower : " + BeamPower);
                }
            }// パワーが足りるとき:ビームを発射
            else
            {
                ShotGauge = 0;
                if (BeamTime == 0)
                {
                    // SE_beamの再生
                    soundscripte.GetComponent<SoundManager>().SE_beam();

                    // 生成したインスタンスをリストに保持
                    beam_instance = Instantiate(beam,
                    transform.position,
                    Quaternion.identity
                    );

                    //生成したインスタンスをリストで持っておく
                    list_beam.Add(beam_instance);

                }
                // ビーム発射中はスピードを遅くする
                x *= 0.5f;
                y *= 0.5f;

            }

            GetDirection();
        }
        
        
            // ゲージが残っているとき:ショットを発射
            if (ShotGauge > 0)
            {
                if (ShotTime == 0)
                    Instantiate(shot,
                    transform.position,
                    Quaternion.identity
                    );
                ShotGauge--;
            }

        
        // ショットとビームの待機時間を更新
        ShotTime = (ShotTime + 1) % MaxShotTime;
        BeamTime = (BeamTime + 1) % MaxBeamTime;

    }
    void GetDirection()
    {
        float directionX = touthEndPos.x - touthStartPos.x;
        float directionY = touthEndPos.y - touthStartPos.y;
        

        if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
        {
            if (30 < directionX)
            {
                Direction = "right";

            }else if (-30 > directionX)
            {
                Direction = "left";
            }
        }else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            if (30 < directionY)
            {
                Direction = "up";

            }
            else if (-30 > directionY)
            {
                Direction = "down";
            }
        }else
        {
            Direction = "touth";
        }

        switch (Direction)
        {
            case "up":
//               Debug.Log("up");
                transform.Translate(0, speed, 0);
                break;
            case "down":
//                Debug.Log("down");
                transform.Translate(0, -speed, 0);
                break;
            case "left":
                transform.Translate(-speed, 0, 0);
                anim.SetBool("Left", true);
//                Debug.Log("left");
                break;
            case "right":
                transform.Translate(speed, 0, 0);
                anim.SetBool("Right", true);
//                Debug.Log("right");
                break;
            case "touth":
//                Debug.Log("touth");
                //beam
               
                break;
           
        }
        anim.SetBool("Left", false);
        anim.SetBool("Right", false);                
    }
    //--------------------------------------------------
    //キーボード操作
    //--------------------------------------------------
    void playKey()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if (x < 0)
        {
            anim.SetBool("Left", true);
        }
        else if (x > 0)
        {
            anim.SetBool("Right", true);
        }
        else
        {
            anim.SetBool("Left", false);
            anim.SetBool("Right", false);
        }

        Vector3 velocity = new Vector3(x, y) * speed;
        transform.position += velocity;

        if (Input.GetKey(KeyCode.Space))
        {
            // ビームのパワーとショットのゲージ
            const int BeamMinPower = BEAM_MIN_POWER;
            const int ShotMaxGauge = SHOT_MAX_GAUGE;

           

            // パワーが足りないとき:ショットを発射
            if (BeamPower < BeamMinPower)
            {
                BeamPower++;
                ShotGauge = ShotMaxGauge;
                if (ShotTime == 0)
                    Instantiate(shot,
                    transform.position,
                    Quaternion.identity
                    );
                // SE_shotの再生
                soundscripte.GetComponent<SoundManager>().SE_shot();
            }// パワーが足りるとき:ビームを発射
            else
            {
                ShotGauge = 0;
                if (BeamTime == 0)
                    Instantiate(beam,
                    transform.position,
                    Quaternion.identity
                    );
                // SE_beamの再生
                soundscripte.GetComponent<SoundManager>().SE_beam();
                // ビーム発射中はスピードを遅くする
                x *= 0.5f;
                y *= 0.5f;

            }
        }
        else
        {
            // ボタンを離したとき:ビームを消す DeleteBeam();
            BeamPower = 0;
            // ゲージが残っているとき:ショットを発射
            if (ShotGauge > 0)
            {
                if (ShotTime == 0)
                    Instantiate(shot,
                    transform.position,
                    Quaternion.identity
                    );
                ShotGauge--;
            }

        }
        // ショットとビームの待機時間を更新
        ShotTime = (ShotTime + 1) % MaxShotTime;
        BeamTime = (BeamTime + 1) % MaxBeamTime;
    }

    // Update is called once per frame
    void Update()
    {
        Flick();
        rangePos();
        playKey();
    }

    //----------------------------------------------------------
    //画面から出ないように
    //----------------------------------------------------------
    void rangePos()
    {
        Vector3 tmpPos;
        float dx, dy;
        float playerPosX = transform.position.x;
        float playerPosY = transform.position.y;
        if (playerPosX < -2.3f){
            dx = -2.3f;
            tmpPos = new Vector3(dx, transform.position.y, 0);
            transform.position = tmpPos;
        } if (playerPosX > 2.3) {
            dx = 2.3f;
            tmpPos = new Vector3(dx, transform.position.y, 0);
            transform.position = tmpPos;
        }
        if (playerPosY < -5) {
            dy = -5.0f;
            tmpPos = new Vector3(transform.position.x, dy, 0);
            transform.position = tmpPos;
        } if (playerPosY > 5){
            dy = 5.0f;
            tmpPos = new Vector3(transform.position.x, dy, 0);
            transform.position = tmpPos;
        }
    }
}
