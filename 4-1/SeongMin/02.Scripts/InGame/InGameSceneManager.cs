using SeongMin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSceneManager : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.inGameSceneManager = this;
    }

    public void Lose()
    {
        GameDB.Instance.isWin = false;
    }
    public void Win()
    {
        GameDB.Instance.isWin = true;

    }
}
