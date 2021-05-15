using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    string[] buttonNumber = new string[] { "Button1", "Button2", "Button3", "Button4", "Button5", "Button6" };
    string[] scenename = new string[] { "", "3", "4", "5", "6", "Title" };
    bool SceneChange = false;
    bool BackTitle = false;
    int number;
    public float time;

    public void Update()
    {
        if (!SceneChange)
            return;
        time += Time.deltaTime;
        if (time > 0.5f)
        {
            if (BackTitle)
                SceneManager.LoadScene("TitleScene");
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
                if (i == 5)
                {
                    BackTitle = true;
                }
                number = i;
                SceneChange = true;
                //SceneManager.LoadScene("GameScene" + scenename[i]);
            }
        }
    }
}
