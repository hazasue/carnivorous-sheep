using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
	public void MoveToIntro()
	{
		SceneManager.LoadScene("Intro");
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
