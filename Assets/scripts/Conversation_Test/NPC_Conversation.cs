using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Conversation : MonoBehaviour
{
    public bool NPC_check;
    public GameObject NPC_Text;
    // Start is called before the first frame update
    void Start()
    {
        NPC_Text.SetActive(false);
        NPC_check = false;
    }

    // Update is called once per frame
    void Update()
    {

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
            if (NPC_check == true && Input.GetKey(KeyCode.C))
            {
                NPC_Text.SetActive(false);
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
