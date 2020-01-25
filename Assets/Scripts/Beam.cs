using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{

    public float beam_Speed;
    

    // Start is called before the first frame update
    private void Update()
    {
        transform.Translate(0, beam_Speed, 0);
        float shotY = transform.position.y;
        if (shotY > 5)
            Destroy(gameObject);
    }

 /*   void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("beamあたりテキ");
            //    soundscripte.GetComponent<SoundManager>().SE_crash();
            Destroy(gameObject);
        }

    }*/
}
