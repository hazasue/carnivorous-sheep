using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leap_Script : MonoBehaviour
{
    public GameObject Leap;
    public GameObject Leap_Text;
    public GameObject Player;
    public bool Leap_check;

    // Start is called before the first frame update
    void Start()
    {
        Leap_Text.SetActive(false);
        Leap_check = false;

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Leap")
        {
            Debug.Log("무야호");
            Leap_check = true;
            Leap_Text.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Leap")
        {
            if (Leap_check == true && Input.GetKey(KeyCode.C))
            {
                Leap_Text.SetActive(false);
                Player.GetComponent<Leap_control>().Leap_count += 1;
                Destroy(Leap);
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Leap")
        {
            Debug.Log("나가버렸다");
            Leap_check = false;
            Leap_Text.SetActive(false);
        }
    }
}