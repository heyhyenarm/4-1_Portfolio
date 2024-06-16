using Oculus.Interaction.UnityCanvas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateDemo : MonoBehaviour
{
    public CanvasRenderTexture canvasRender;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            canvasRender.UpdateCamera();
            Debug.Log("마우스 클릭");
        }
    }
}
