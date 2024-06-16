using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class VRInputData : MonoBehaviour
{
    public InputActionAsset inputActionAsset;

    public TMP_Text[] textUIs;

    public float userHeight;
    IEnumerator Start()
    {
        float t = 0f;
        yield return new WaitForSeconds(1f);

        while (t < 3f)
        {
            // text의 현재 위치 값
            Vector3 hmdpostion = inputActionAsset.actionMaps[0].actions[0].ReadValue<Vector3>();
            userHeight = hmdpostion.y;

            yield return new WaitForSeconds(1f);
            t++;
        }
        userHeight *= 100f;
        userHeight /= 2f;
        textUIs[1].text = "User height : " + userHeight;
    
    }
    void Update()
    {
        // Input Action Manager Asset에서 actionMaps[0] -> XRI Head에 접근  actions[0] -> position에 접근
        Vector3 hmdpostion = inputActionAsset.actionMaps[0].actions[0].ReadValue<Vector3>();
        float hmdHeight = hmdpostion.y;

        textUIs[0].text = hmdHeight.ToString();

        Quaternion rightHandControllerRoatation = inputActionAsset.actionMaps[4].actions[1].ReadValue<Quaternion>();
        textUIs[2].text = rightHandControllerRoatation.eulerAngles.ToString();

        var rightHandControllerTrigger = inputActionAsset.actionMaps[5].actions[2].IsPressed();
        textUIs[3].text = " pressed ? :" + rightHandControllerTrigger;

        var leftHandControllerVelocity = inputActionAsset.actionMaps[1].actions[11].ReadValue<Vector3>();
        textUIs[4].text = "" + leftHandControllerVelocity;
    }
}
