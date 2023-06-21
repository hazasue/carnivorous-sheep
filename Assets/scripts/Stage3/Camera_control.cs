using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_control : MonoBehaviour
{
    public GameObject Player;
    float pos_x;
    float pos_y;
    float pos_z;
    // Start is called before the first frame update
    void Start()
    {
        pos_y = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        pos_x = Player.transform.position.x;
        pos_z = Player.transform.position.z;

        Vector3 Temp = new Vector3(pos_x, pos_y, pos_z);
        transform.position = Temp;

    }
}
