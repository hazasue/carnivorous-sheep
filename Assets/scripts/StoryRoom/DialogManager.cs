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
        
        dialogDB[0, 0] = "치킨 재료를 어디서 구해오면 될까요?";
        dialogDB[0, 1] = "내 주위에 동물들에게 말을 걸어서 구해보렴.";
        dialogDB[0, 2] = "구해야 하는 재료는 어떤 것들이 있나요?";
        dialogDB[0, 3] = "달콤한 우유, 튀김 가루, 올리브유와 신비한 재료들이란다. ";
        dialogDB[0, 4] = "나머지는 알겠는데 신비한 재료들은 어떻게 구하죠?";
        dialogDB[0, 5] = "신비의 숲으로 가서 직접 구해야 한단다.";
        dialogDB[0, 6] = "그렇군요. 감사합니다!";
        
        dialogDB[1, 0] = "안녕하세요! 달콤한 우유를 구할 수 있을까요?";
        dialogDB[1, 1] = "우리는 고소한 우유밖에 취급 안하는데, 별사탕을 좀 구해     올래?";
        dialogDB[1, 2] = "네!";

        dialogDB[2, 0] = "안녕하세요! 튀김 가루를 구하러 왔는데 들어가도 괜찮을까요??";
        dialogDB[2, 1] = "원래는 안 되지만 이번만 특별히야.";

        dialogDB[3, 0] = "올리브 요정! 올리브 나무가 있는 곳으로 안내해줄 수 있겠니?";
        dialogDB[3, 1] = "그럼요! 그런데 가는 길이 돌로 막혀있어서 길을 다시 찾아야 해요... 대충 방향은 아는데 그걸로 충분할까요?";
        dialogDB[3, 2] = "그래!";

        dialogDB[4, 0] = "여기가 신비의 숲 입구인가?";
        dialogDB[4, 1] = "빨리 구해와야지, 곧 해가 저물 것 같아.";

        dialogDB[5, 0] = "재료 다 구해왔어요!";
        dialogDB[5, 1] = "좋아, 조금만 기다려. 맛있는 치킨을 만들어줄게.";



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
            if (dialogCollection == 1)
            {
                SceneManager.LoadScene("Stage1");
            }
            else if (dialogCollection == 2)
            {
                SceneManager.LoadScene("Stage2");
            }
            else if (dialogCollection == 3)
            {
                SceneManager.LoadScene("Stage3");
            }
            else if (dialogCollection == 4)
            {
                npc.SetActive(true);
                npcBlind.SetActive(true);
                SceneManager.LoadScene("Stage4");
            }
            else if (dialogCollection == 5)
            {
                SceneManager.LoadScene("Ending");
            }
        }
        if (dialogCollection != 4)
        {
            ChangeSpeakingCharacter();
        }
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
        switch (num)
        {
            case 0:
                npc.GetComponent<Image>().sprite = chicken;
                npcBlind.GetComponent<Image>().sprite = chicken;
                break;
            case 1:
                npc.GetComponent<Image>().sprite = cow;
                npcBlind.GetComponent<Image>().sprite = cow;
                break;
            case 2:
                npc.GetComponent<Image>().sprite = shrimp;
                npcBlind.GetComponent<Image>().sprite = shrimp;
                break;
            case 3:
                npc.GetComponent<Image>().sprite = olive;
                npcBlind.GetComponent<Image>().sprite = olive;
                break;
            case 4:
                npc.SetActive(false);
                npcBlind.SetActive(false);
                break;
            case 5:
                npc.GetComponent<Image>().sprite = chicken;
                npcBlind.GetComponent<Image>().sprite = chicken;
                break;
            default:
                break;
        }
    }
}
