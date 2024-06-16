using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandMenu : MonoBehaviour
{
    public Button buttonOpenInventory;
    private void Awake()
    {
        this.buttonOpenInventory = GetComponentInChildren<Button>();
    }

    public void OnEnable()
    {
        
    }
}
