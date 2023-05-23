using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private Animator animator;
    
    private AudioSource audioSound;
    public AudioClip bgm;
    
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        this.audioSound = this.gameObject.AddComponent<AudioSource>();
        this.audioSound.loop = true;
        
        if (bgm == null) return;
        audioSound.clip = bgm;
        audioSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
