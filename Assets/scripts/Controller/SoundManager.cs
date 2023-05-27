using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public AudioSource BGM;
    public AudioSource SFX;
    
    public AudioClip bgm;

    public AudioClip success;
    public AudioClip fail;
    public AudioClip walk;
    public AudioClip jump;
    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        
        BGM.volume = 0.33f;
        SFX.volume = 0.33f;

        BGM.loop = true;
        SFX.loop = false;
        SFX.playOnAwake = false;

        SFX.priority = 0;
        BGM.priority = 10;
        
        if (bgm == null) return;
        BGM.clip = bgm;
        BGM.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static SoundManager GetInstance()
    {
        if (instance != null) return instance;
        instance = FindObjectOfType<SoundManager>();

        return instance;
    }

    public void SuccessStage()
    {
        SFX.clip = success;
        SFX.Play();
    }

    public void FailStage()
    {
        SFX.clip = fail;
        SFX.Play();
    }

    public void Walk()
    {
        SFX.loop = true;
        SFX.clip = walk;
        SFX.Play();
    }

    public void StopWalk()
    {
        SFX.loop = false;
        SFX.Stop();
    }

    public void Jump()
    {
        SFX.clip = jump;
        SFX.Play();
    }
}
