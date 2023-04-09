using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leap_count : MonoBehaviour
{
    public Text Leap_Count;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Leap_Count.text = Player.GetComponent<Leap_control>().Leap_count.ToString();
    }
}
