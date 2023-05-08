using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInStage4 : MonoBehaviour
{
    private int ingrCount;
    private float timer;

    private bool collectAllIngr;

    // Start is called before the first frame update
    void Awake()
    {
        ingrCount = 0;
        timer = 0f;
        collectAllIngr = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (ingrCount >= 4 && collectAllIngr == false)
        {
            collectAllIngr = true;
        }
        
        if (collectAllIngr == false) timer += Time.deltaTime;
	}

    public void AddIngrCount()
    {
        ingrCount++;
    }

    public float GetTimer()
    {
        return timer;
    }

    public bool GetCleared()
    {
        return collectAllIngr;
    }
}
