using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredients : MonoBehaviour
{
    private float rotY;
        
    // Start is called before the first frame update
    void Start()
    {
        rotY = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        rotY += Time.deltaTime * 20;
        if (rotY >= 360f) rotY -= 360f;
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, rotY, 0f));
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
