using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    Transform bg;
    // Start is called before the first frame update
    void Start()
    {
        bg = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 velocity = new Vector3(0, -0.01f);
        //transform.position += velocity;
        transform.Translate(0, -0.01f, 0);
        float fbg = this.transform.position.y;
        if(fbg < -8)
        {
            Vector3 tmp = new Vector3(0, 5, 0);
            this.transform.position = tmp;
        }
    }
}
