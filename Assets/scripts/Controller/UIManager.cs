using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject clearScreen;
    public GameObject failedScreen;

    public GameObject missionScreen;
    public GameObject settingScreen;
    
    private GameManager mGameManager;
    
    // Start is called before the first frame update
    void Awake()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Init()
    {
        mGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void ActiveClearScreen()
    {
        if (clearScreen.activeSelf == true) return;
        mGameManager.GetPlayer().GetComponent<Player>().SetGameOver(true);
        clearScreen.SetActive(true);
    }

    public void ActiveFailedScreen()
    {
        if (failedScreen.activeSelf == true) return;
        mGameManager.GetPlayer().GetComponent<Player>().SetGameOver(true);
        failedScreen.SetActive(true);
    }

    public void MoveToStageEntrance()
    {
        SceneManager.LoadScene("Stage Entrance");
    }

    public void ActiveSetting()
    {
        settingScreen.SetActive(true);
    }
    
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void continueGame()
    {
        settingScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
