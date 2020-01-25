using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    // GameObject
    [SerializeField] private GameObject soundManager;

    // AudioClip
     public AudioClip SE_SHOT;
     public AudioClip SE_BEAM;
     public AudioClip SE_CRASH;
    [SerializeField] private AudioClip Title;
    [SerializeField] private AudioClip Game;
    [SerializeField] private AudioClip RaedyGame;

    // AudioSource
     public AudioSource[] audios;
    private AudioSource AUDIOSOURCE_BGM;
    private AudioSource AUDIOSOURCE_SE;
    // 変数、定数

    public bool isBGM = false;
    public string Scenename;

    // Start is called before the first frame update
    void Awake()
    {
        //audios = GetComponents<AudioSource>();
        AUDIOSOURCE_BGM = audios[0];
        AUDIOSOURCE_SE = audios[1];
        //  int soundPlay = FindObjectOfType<SoundManager>().Length;

        DontDestroyOnLoad(soundManager);
       
        //if(soundPlay > 1)
        //{
            isBGM = false;
           // Destroy(soundManager);
        //}
        Scenename = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
       
     //   BGM();
        
    }


    // BGM
    void BGM()
    {
        if (!isBGM)
        {
            if (Scenename == "Game")
            {
//                Debug.Log("Sceneame:" + Scenename);
                AUDIOSOURCE_BGM.clip = Game;
                AUDIOSOURCE_BGM.Play();
                isBGM = true;
            }
            if (Scenename == "Title")
            {
                AUDIOSOURCE_BGM.clip = Title;
                AUDIOSOURCE_BGM.Play();
                isBGM = true;
            }
            if (Scenename == "RaedyGame")
            {
                AUDIOSOURCE_BGM.clip = RaedyGame;
                AUDIOSOURCE_BGM.Play();
                isBGM = true;
            }
        }
    }

    // SE
    public void SE_shot()
    {
        Debug.Log(AUDIOSOURCE_SE);
        AUDIOSOURCE_SE.PlayOneShot(SE_SHOT);
        Debug.Log("SE : " + SE_SHOT);
    }

    public void SE_beam()
    {
        AUDIOSOURCE_SE.PlayOneShot(SE_BEAM);
        Debug.Log("SE : " + SE_BEAM);
    }

    public void SE_crash()
    {
        AUDIOSOURCE_SE.PlayOneShot(SE_CRASH);
        Debug.Log("SE : " + SE_CRASH);
    }
}