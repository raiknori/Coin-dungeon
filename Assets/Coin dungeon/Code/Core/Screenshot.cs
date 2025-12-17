#if UNITY_EDITOR
using System;
using UnityEngine;


public class Screenshot : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F12))
        {
            ScreenCapture.CaptureScreenshot($"game_screenshot.png",4);
        }
    }
}
#endif