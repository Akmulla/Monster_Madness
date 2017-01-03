using UnityEngine;
using System.Collections;

public class GameOverWindow : MonoBehaviour
{
    public Sprite win;
    public Sprite loss;
	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            MainController.SwitchScene("Game");
        }
#else
        Touch myTouch;
        if (Input.touchCount > 0)
        {
            myTouch = Input.GetTouch(0);
            if (myTouch.phase==TouchPhase.Began)
            {
                MainController.SwitchScene("Game");
            }
        }
#endif
    }


}
