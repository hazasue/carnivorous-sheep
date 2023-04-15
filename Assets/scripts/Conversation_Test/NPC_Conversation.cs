using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Conversation : MonoBehaviour
{
    public bool NPC_check;
    public GameObject NPC_Text;
    public GameObject Player;

    public GameObject Dialogue_1;
    public GameObject Dialogue_2;
    public bool dial_1_check;
    public bool dial_2_check;

    private bool Key_check;// 동시입력 방지

    // Start is called before the first frame update
    void Start()
    {
        NPC_Text.SetActive(false);
        NPC_check = false;

        Dialogue_1.SetActive(false);
        Dialogue_2.SetActive(false);
        dial_1_check = false;
        dial_2_check = false;

        Key_check = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C)) Key_check = true;

        if (dial_1_check == true)
        {
            Player.SetActive(false);
            Dialogue_1.SetActive(true);
            if (Input.GetKeyDown(KeyCode.C) && Key_check == true)
            {
                Key_check = false;
                Dialogue_1.SetActive(false);
                dial_2_check = true;
                dial_1_check = false;
            }
        }

        if (dial_2_check == true)
        {
            Dialogue_2.SetActive(true);
            if (Input.GetKeyDown(KeyCode.C) && Key_check == true)
            {
                Key_check = false;
                Dialogue_2.SetActive(false);
                Player.SetActive(true);
                dial_2_check = false;
            }
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("무야호");
            NPC_check = true;
            NPC_Text.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            if (NPC_check == true && Input.GetKey(KeyCode.C) && Key_check == true)
            {
                Key_check = false;
                NPC_Text.SetActive(false);
                dial_1_check = true;
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("나가버렸다");
            NPC_check = false;
            NPC_Text.SetActive(false);
        }
    }
}
