using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogManager : MonoBehaviour
{
    private static DialogManager instance;
    
    public GameObject screen;

    public GameObject gPlayerText;
    public GameObject gNPCText;
    public Text tPlayerDialog;
    public Text tNPCDialog;
    private Text tDialog;
    
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

    private int dialogCollection;

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
        dialogCollection = 0;
        for (int num1 = 0; num1 < 10; num1++)
        {
            for (int num2 = 0; num2 < 20; num2++)
            {
                dialogDB[num1, num2] = "";
            }
        }

        dialogDB[0, 0] = "달콤한 우유를 주세요.";
        dialogDB[0, 1] = "우리는 고소한 우유밖에 취급 안하는데, 별사탕을 좀 구해올래?";
        dialogDB[0, 2] = "네!!!!!!!!!";

        dialogDB[2, 0] = "튀김 가루를 구하러 왔는데 들어가도 괜찮을까요??";
        dialogDB[2, 1] = "원래는 안되지만 이번만 특별히야.";


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
    
    public static DialogManager GetInstance()
    {
        if (instance != null) return instance;
        instance = FindObjectOfType<DialogManager>();

        return instance;
    }

    public void ReadDialog()
    {
        if (dialogDB[dialogCollection, dialogIndex] == "")
        {
            screen.SetActive(false);
            if (dialogCollection == 0)
            {
                SceneManager.LoadScene("Stage1");
            }
            else if (dialogCollection == 2)
            {
                SceneManager.LoadScene("Stage2");
            }
        }
        ChangeSpeakingCharacter();
        tDialog.text = dialogDB[dialogCollection, dialogIndex++];
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

    public void SetScreenActive(bool _bool, int num)
    {
        screen.SetActive(_bool);
        dialogCollection = num;
        dialogIndex = 0;
        tDialog = tPlayerDialog;
        playerBlind.SetActive(false);
        npcBlind.SetActive(true);
        tDialog = tPlayerDialog;
        gPlayerText.SetActive(true);
        gNPCText.SetActive(false);
        tDialog.text = dialogDB[dialogCollection, dialogIndex++];
    }
}
