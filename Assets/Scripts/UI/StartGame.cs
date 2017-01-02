using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public void BeginGame()
    {
        MainController.SwitchScene("Game");
    }
}
