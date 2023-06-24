using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data instance = null;
    
    public bool[] clearStage = new bool[4];

    void Awake()
    {
        // SoundManager 인스턴스가 이미 있는지 확인, 이 상태로 설정
        if (instance == null)
            instance = this;

        // 인스턴스가 이미 있는 경우 오브젝트 제거
        else if (instance != this)
            Destroy(gameObject);

        // 이렇게 하면 다음 scene으로 넘어가도 오브젝트가 사라지지 않습니다.
        for (int i = 0; i < 4; i++)
        {
            clearStage[i] = false;
        }

        DontDestroyOnLoad(gameObject);
    }

    public static Data GetInstance()
    {
        if (instance != null) return instance;
        instance = FindObjectOfType<Data>();

        return instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
