using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{

    public void OnCollisionEnter(Collision player)
    {
        if(player.gameObject.tag == "Player")
        {
            Invoke("SetInActiveObject", 3f);
        }
    }

    private void SetInActiveObject()
    {
        this.gameObject.SetActive(false);
        Invoke("SetActiveObject", 10f);
    }

    private void SetActiveObject()
    {
        this.gameObject.SetActive(true);
    }
}
