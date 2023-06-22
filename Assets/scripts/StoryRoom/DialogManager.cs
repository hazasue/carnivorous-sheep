using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public GameObject gPlayerText;
    public GameObject gNPCText;
    public TMP_Text tPlayerDialog;
    public TMP_Text tNPCDialog;
    private TMP_Text tDialog;
    
    public GameObject player;
    public GameObject npc;
    public GameObject playerBlind;
    public GameObject npcBlind;

    public Sprite chicken;
    public Sprite witch;
    public Sprite cow;
    public Sprite shrimp;
    public Sprite olive;
    

    private string[,] dialogDB;
    private int dialogIndex;

    // Start is called before the first frame update
    void Start()
    {
        InitDialog();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitDialog()
    {
        dialogDB = new string[10, 20];
        dialogIndex = 0;
        for (int num1 = 0; num1 < 10; num1++)
        {
            for (int num2 = 0; num2 < 20; num2++)
            {
                dialogDB[num1, num2] = "";
            }
        }

        dialogDB[0, 0] = "dialog test 1";
        dialogDB[0, 1] = "dialog test 2";
        dialogDB[0, 2] = "dialog test 3";
        dialogDB[0, 3] = "dialog test 4";
        dialogDB[0, 4] = "dialog test 5";
        dialogDB[0, 5] = "dialog test 6";

        tDialog = tPlayerDialog;
        playerBlind.SetActive(false);
        npcBlind.SetActive(true);
        tDialog = tPlayerDialog;
        gPlayerText.SetActive(true);
        gNPCText.SetActive(false);

        npc.GetComponent<Image>().sprite = cow;
        npcBlind.GetComponent<Image>().sprite = cow;

        tDialog.text = dialogDB[0, dialogIndex++];
    }

    public void ReadDialog()
    {
        if (dialogDB[0, dialogIndex] == "") { SceneManager.LoadScene("Stage Entrance"); }
        ChangeSpeakingCharacter();
        tDialog.text = dialogDB[0, dialogIndex++];
    }

    private void ChangeSpeakingCharacter()
    {
        if (playerBlind.activeSelf == false)
        {
            playerBlind.SetActive(true);
            npcBlind.SetActive(false);
            tDialog = tNPCDialog;
            gPlayerText.SetActive(false);
            gNPCText.SetActive(true);
        }
        else
        {
            playerBlind.SetActive(false);
            npcBlind.SetActive(true);
            tDialog = tPlayerDialog;
            gPlayerText.SetActive(true);
            gNPCText.SetActive(false);
        }
    }
}
