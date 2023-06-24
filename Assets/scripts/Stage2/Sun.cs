using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public GameObject Player;
    public GameObject Leap_Spread;
    public GameObject Clear;
    public GameObject Leap_Count;

    private SoundManager mSoundManager;

    private int leap;
    // Start is called before the first frame update
    void Start()
    {
        mSoundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        Leap_Spread.SetActive(false);
        Clear.SetActive(false);
        leap = 0;
    }

    // Update is called once per frame
    void Update()
    {
        leap = Player.GetComponent<Leap_control>().Leap_count;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player") && leap == 6)
        {
            Leap_Spread.SetActive(true);

        }
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.CompareTag("Player") && leap == 6)
        {
            if (Input.GetKey(KeyCode.C))
            {
                Leap_Spread.SetActive(false);
                Clear.SetActive(true);
                mSoundManager.SuccessStage();
                Data.GetInstance().clearStage[1] = true;
                Leap_Count.SetActive(false);
            }
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Player") && leap == 6)
        {
            Leap_Spread.SetActive(false);
        }
    }
}
