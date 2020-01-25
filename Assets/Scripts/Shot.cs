using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float shot_Speed;
   [SerializeField] GameObject SoundManager;
    SoundManager soundscripte;

    private void Start()
    {
        soundscripte = SoundManager.GetComponent<SoundManager>();
    }

    private void Update()
    {
        transform.Translate(0, shot_Speed, 0);
        float shotY = transform.position.y;
        if(shotY > 8)
        Destroy(gameObject);
    }

/*    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("shotあたりテキ");
            Destroy(gameObject);
 //           soundscripte.GetComponent<SoundManager>().SE_crash();
        }
        
    }*/
}
