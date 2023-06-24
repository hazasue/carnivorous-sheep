using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_check : MonoBehaviour
{
    public GameObject ClearScreen;
    private SoundManager mSoundManager;
    // Start is called before the first frame update
    void Start()
    {
        mSoundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Goal")
        {
            mSoundManager.SuccessStage();
            Destroy(col.gameObject);
            ClearScreen.SetActive(true);
            Data.GetInstance().clearStage[2] = true;
        }
    }
}
