using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInStage4 : MonoBehaviour
{
    private int ingrCount;
    private float timer;

    // Start is called before the first frame update
    void Awake()
    {
        ingrCount = 0;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
		if (ingrCount >= 4)
		{
			SceneManager.LoadScene("Stage Entrance");
		}
        timer += Time.deltaTime;
	}

    public void AddIngrCount()
    {
        ingrCount++;
    }

    public float GetTimer()
    {
        return timer;
    }
}
