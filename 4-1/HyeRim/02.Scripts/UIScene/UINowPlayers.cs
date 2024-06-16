using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UINowPlayers : MonoBehaviour
{
    public Image[] players;

    private void Awake()
    {
        this.players = GetComponentsInChildren<Image>();
    }
}
