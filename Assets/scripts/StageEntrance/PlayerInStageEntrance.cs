using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInStageEntrance : MonoBehaviour
{
	public void OnTriggerEnter(Collider obj)
	{
		switch (obj.tag)
		{
			case "portal1":
				SceneManager.LoadScene("Stage1");
				break;
			case "portal2":
				SceneManager.LoadScene("Stage2");
				break;
			case "portal3":
				SceneManager.LoadScene("Stage3");
				break;
			case "portal4":
				SceneManager.LoadScene("Stage4");
				break;
			default:
				break;
		}
	}
}
