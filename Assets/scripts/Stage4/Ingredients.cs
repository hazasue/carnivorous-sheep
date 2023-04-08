using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredients : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider player)
    {
        if(this.gameObject.tag == "ingredient"
            && player.tag == "Player")
        {
            player.GetComponent<PlayerInStage4>().AddIngrCount();
            Destroy(this.gameObject); 
        }
    }
}
