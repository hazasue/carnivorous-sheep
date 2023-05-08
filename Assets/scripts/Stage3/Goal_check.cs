using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_check : MonoBehaviour
{
    public GameObject ClearScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Goal")
        {
            Destroy(col.gameObject);
            ClearScreen.SetActive(true);
        }
    }
}
