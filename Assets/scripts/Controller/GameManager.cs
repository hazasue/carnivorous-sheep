using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject player;

    private UIManager mUIManager;
    private SoundManager mSoundManager;

    private GameObject starCandy;

    private bool isCheckedClear;
    
    // Start is called before the first frame update
    void Awake()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        CheckClear();
    }

    private void Init()
    {
        Time.timeScale = 1f;
        
        player = GameObject.Find("Player");
        mUIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        mSoundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        if (SceneManager.GetActiveScene().name == "Stage1")
        {
            starCandy = GameObject.Find("StarCandy");
        }

        isCheckedClear = false;
    }

    private void CheckClear()
    {
        if (isCheckedClear == true) return;
        
        if (SceneManager.GetActiveScene().name == "Stage1")
        {
            if (starCandy == null)
            {
                isCheckedClear = true;
                mUIManager.ActiveClearScreen();
                mSoundManager.SuccessStage();
                Data.GetInstance().clearStage[0] = true;
            }
        }

        else if (SceneManager.GetActiveScene().name == "Stage4")
        {
            if (player.GetComponent<PlayerInStage4>().GetCleared() == true)
            {
                isCheckedClear = true;
                mUIManager.ActiveClearScreen();
                mSoundManager.SuccessStage();
                Data.GetInstance().clearStage[3] = true;
            }
        }
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
