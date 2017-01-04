using UnityEngine;
using System.Collections;

public class HeadAnimation : MonoBehaviour
{
    GameObject helicopter;

    void Start()
    {
        helicopter=HelicopterMove.helicopter.gameObject;
    }

    public void HelicopterEaten()
    {
        Destroy(helicopter);
        MainController.EndGame(true);
    }
}
