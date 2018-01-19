using UnityEngine;
using System.Collections;

public class Fps : MonoBehaviour
{

    string label = "";
    string label1 = "";
    float count;

    IEnumerator Start()
    {
        GUI.depth = 2;
        while (true)
        {
            if (Time.timeScale == 1)
            {
                yield return new WaitForSeconds(0.1f);
                count = (1 / Time.deltaTime);
                label = "FPS :" + (Mathf.Round(count));
                label1 = "Frame :" + Time.frameCount;
            }
            else
            {
                label = "Pause";
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(5, 40, 100, 25), label);
        GUI.Label(new Rect(5, 65, 100, 25), label1);
    }
}