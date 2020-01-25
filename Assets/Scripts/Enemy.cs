using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public GameObject enemy;
//    List<GameObject> list_enemy = new List<GameObject>();
//    GameObject enemy_instance;

    [SerializeField] GameObject SoundManager;
    SoundManager soundscripte;

    float vx, vy, vz;

    // Start is called before the first frame update
    void Start()
    {
        soundscripte = SoundManager.GetComponent<SoundManager>();

        vx = transform.position.x;
        vy = transform.position.y;
        vz = transform.position.z;

        Vector3 initPos = new Vector3(vx, vy, vz);
        transform.position = initPos;
//        transform.position = new Vector3(0, 6);

    }

    // Update is called once per frame
    void Update()
    {
        //        transform.Translate(0, -speed, 0);
        
        
        transform.Translate(0, -speed, 0);

        float y = transform.position.y;
        if (y < -5) { Destroy(gameObject); }


    }

/*    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Shot")
        {
            Debug.Log("ショット");
            Destroy(gameObject);
            // SE_crash再生
            soundscripte.GetComponent<SoundManager>().SE_crash();
        }
        if (col.gameObject.tag == "Beam")
        {
            Debug.Log("ビーム");
            Destroy(gameObject);
            // SE_crash再生
            soundscripte.GetComponent<SoundManager>().SE_crash();
        }
    }
    /*   void enemyPos()
       {
           // 生成したインスタンスをリストに保持
           enemy_instance = Instantiate(enemy,
                            transform.position,
                            Quaternion.identity
                            );

           //生成したインスタンスをリストで持っておく
           list_enemy.Add(enemy_instance);

       }
   */
}

