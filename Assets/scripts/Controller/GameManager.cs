using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject player;

    private UIManager mUIManager;

    private GameObject starCandy;
    
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

        if (SceneManager.GetActiveScene().name == "Stage1")
        {
            starCandy = GameObject.Find("StarCandy");
        }
    }

    private void CheckClear()
    {
        if (SceneManager.GetActiveScene().name == "Stage1")
        {
            if (starCandy == null)
            {
                mUIManager.ActiveClearScreen();
            }
        } 
        else if (SceneManager.GetActiveScene().name == "Stage4")
        {
            if (player.GetComponent<PlayerInStage4>().GetCleared() == true)
            {
                mUIManager.ActiveClearScreen();
            }
        }
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
