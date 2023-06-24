using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
	public void MoveToStoryRoom()
	{
		SceneManager.LoadScene("Stage Entrance");
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
