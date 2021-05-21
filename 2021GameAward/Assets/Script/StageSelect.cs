using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    Button button1;
    Button button2;
    Button button3;
    Button button4;

    // Start is called before the first frame update
    void Start()
    {
        button1 = GameObject.Find("/Canvas/Button1").GetComponent<Button>();
        button2 = GameObject.Find("/Canvas/Button2").GetComponent<Button>();
        button3 = GameObject.Find("/Canvas/Button3").GetComponent<Button>();
        button4 = GameObject.Find("/Canvas/Button4").GetComponent<Button>();

        button1.Select();
    }
}
