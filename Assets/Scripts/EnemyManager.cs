using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] GameObject Enemy_1;
    [SerializeField] GameObject Enemy_2;
    [SerializeField] GameObject Enemy_3;

    List<GameObject> list_enemy = new List<GameObject>();
    GameObject enemy_instance;

    public int Count;
    Vector3 enemyPos_1, enemyPos_2, enemyPos_3, enemyPos_4, enemyPos_5,
            enemyPos_6, enemyPos_7, enemyPos_8, enemyPos_9, enemyPos_0;

    // Start is called before the first frame update
    void Start()
    {
        Count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Count++;
        enemy_1(); enemy_2(); //enemy_3();
       
//        Debug.Log(Count);
    }

    void enemy_1()
    {
        enemyPos_0 = new Vector3(0.0f, 8.0f, 0.0f);
        if (Count % 180 == 0)
        { 
            // 生成したインスタンスをリストに保持
            enemy_instance = Instantiate(Enemy_1,
                             enemyPos_0,
                             Quaternion.identity
                             );
           
            //生成したインスタンスをリストで持っておく
         //   list_enemy.Add(enemy_instance);
        }
    }

    void enemy_2()
    {

        enemyPos_1 = new Vector3(0.0f, 8.0f, 0.0f);
        enemyPos_2 = new Vector3(1.5f, 10.0f, 0.0f);
        enemyPos_3 = new Vector3(-1.5f, 10.0f, 0.0f);
        if (Count % 250 == 0)
        {
            // 生成したインスタンスをリストに保持
            enemy_instance = Instantiate(Enemy_2,
                             enemyPos_1,
                             Quaternion.identity
                             );
            enemy_instance = Instantiate(Enemy_2,
                             enemyPos_2,
                             Quaternion.identity
                             );
            enemy_instance = Instantiate(Enemy_2,
                             enemyPos_3,
                             Quaternion.identity
                             );

            //生成したインスタンスをリストで持っておく
         //   list_enemy.Add(enemy_instance);
        }
    }

    void enemy_3()
    {

        if (Count % 500 == 0)
        {
            // 生成したインスタンスをリストに保持
            enemy_instance = Instantiate(Enemy_3,
                             transform.position,
                             Quaternion.identity
                             );

            //生成したインスタンスをリストで持っておく
         //   list_enemy.Add(enemy_instance);
        }

    }
}
