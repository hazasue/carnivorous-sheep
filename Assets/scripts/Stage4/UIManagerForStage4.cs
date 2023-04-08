using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManagerForStage4 : MonoBehaviour
{
    public GameObject restartButton;
	public TMP_Text timer;


	private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerInStage4>().GetTimer() >= 20f
            && restartButton.activeSelf == false)
        {
            player.GetComponent<Player>().SetGameOver(true);
            restartButton.SetActive(true);
        }
        if (player.GetComponent<PlayerInStage4>().GetTimer() >= 20f) { timer.text = "0.00"; }
        else { timer.text = string.Format("{0:f2}", 20f - player.GetComponent<PlayerInStage4>().GetTimer()); }
	}

    public void RestartGame()
    {
        SceneManager.LoadScene("Stage4");
    }
}
