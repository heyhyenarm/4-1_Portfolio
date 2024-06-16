using NHR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XGameSettingButton : MonoBehaviour
{
    public Button gameSettingButton;
    public UISettings uiSettings;
    private void Awake()
    {
        this.gameSettingButton = this.GetComponent<Button>();
    }
    private void Start()
    {
        this.gameSettingButton.onClick.AddListener(() =>
        {
            this.uiSettings.gameObject.SetActive(true);
            Debug.Log("UISettings");
        });
    }
}
