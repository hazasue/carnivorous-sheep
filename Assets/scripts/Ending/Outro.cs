using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Outro : MonoBehaviour

{
    public VideoPlayer vid;
    // Start is called before the first frame update
    void Start()
    {
        vid.loopPointReached += CheckOver;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Lobby");
    }
}
