using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
	public void MoveToStoryRoom()
	{
		SceneManager.LoadScene("Story Room");
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
