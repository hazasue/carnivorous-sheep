using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_check : MonoBehaviour
{
    public bool Goal = false;
    public GameObject Text;
    // Start is called before the first frame update
    void Start()
    {
        Text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Goal == true)
        {
            Text.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Goal")
        {
            Debug.Log("¹«¾ßÈ£");
            Goal = true;
        }
    }
}
