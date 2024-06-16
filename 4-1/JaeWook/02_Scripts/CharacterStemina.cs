using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterStemina : MonoBehaviour
{
    public UnityEngine.UI.Image steminaImage;
    public float maxSp = 100f;
    public float currentSp = 100f;

    /// <summary>
    /// Stemina UI¿¡ Àû¿ë
    /// </summary>
    /// <param name="destemina"></param>
    public void OnRunning(float deSp)
    {
        currentSp -= deSp;

        steminaImage.fillAmount = currentSp / maxSp;
    }
}
