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
			case "chicken":
				if (Data.GetInstance().clearStage[0] == false)  DialogManager.GetInstance().SetScreenActive(true, 0);

				if (Data.GetInstance().clearStage[3] == true) DialogManager.GetInstance().SetScreenActive(true, 5);
				break;

			
			case "portal1":
				if (Data.GetInstance().clearStage[0] == false)	DialogManager.GetInstance().SetScreenActive(true, 1);
				break;

			case "portal2":
				if (Data.GetInstance().clearStage[0] == true && Data.GetInstance().clearStage[1] == false)
				{
					DialogManager.GetInstance().SetScreenActive(true, 2);
				}
				break;

			case "portal3":
				if (Data.GetInstance().clearStage[1] == true && Data.GetInstance().clearStage[2] == false) DialogManager.GetInstance().SetScreenActive(true, 3);
                break;

			case "portal4":
				if (Data.GetInstance().clearStage[2] == true && Data.GetInstance().clearStage[3] == false) DialogManager.GetInstance().SetScreenActive(true, 4);
                //SceneManager.LoadScene("Stage4");
                break;

			default:
				break;
		}
	}
}
