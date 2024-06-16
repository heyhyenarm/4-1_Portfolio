using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonToggleManager : MonoBehaviour
{
    GameObject UI;

    bool isOn;

    private void Start()
    {
        UI = this.transform.parent.parent.GetChild(0).gameObject;
        isOn = false;
    }

    public void BtnToggle()
    {
        isOn = !isOn;

        UI.SetActive(isOn);
    }
}
