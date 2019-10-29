using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentScript : MonoBehaviour
{
    Color colorStart;
    Color colorEnd = Color.black;
    float duration = 360f;
    float time = 0;
    public Image gameover;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        colorStart.r = 153f / 255f;
        colorStart.g = 217f / 255f;
        colorStart.b = 234f / 255f;
        colorStart.a = 1;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float lerp = Mathf.PingPong(time, duration) / duration;
        RenderSettings.skybox.SetColor("_Tint", Color.Lerp(colorStart, colorEnd, lerp));

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            #if UNITY_EDITOR
            if (EditorApplication.isPlaying)
            {
                EditorApplication.isPlaying = false;
            }
            #endif
        }
        if (Input.GetKeyDown(KeyCode.Space) && !gameover.enabled)
        {
            Time.timeScale = 1 - Time.timeScale;
        }
    }
}
