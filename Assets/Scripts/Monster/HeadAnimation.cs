using UnityEngine;
using System.Collections;

public class HeadAnimation : MonoBehaviour
{

    public void HelicopterEaten()
    {
        MainController.EndGame(true);
    }
}
