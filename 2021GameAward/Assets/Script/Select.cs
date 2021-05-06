using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    string[] buttonNumber = new string[] { "Button1", "Button2", "Button3", "Button4" };
    string[] scenename = new string[] { "", "3", "4", "5" };
    bool SceneChange = false;
    int number;
    public float time;

    public void Update()
    {
        if (!SceneChange)
            return;
        time += Time.deltaTime;
        if (time > 0.5f)
        {
            SceneManager.LoadScene("GameScene" + scenename[number]);
        }
    }

    public void OnClick()
    {
        //if (SceneChange)
        //    return;
        for (int i = 0; i < buttonNumber.Length; i++)
        {
            if (transform.name == buttonNumber[i])
            {
                number = i;
                SceneChange = true;
                //SceneManager.LoadScene("GameScene" + scenename[i]);
            }
        }
    }
}
