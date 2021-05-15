using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class title_select : MonoBehaviour
{
    Button button_title;
    Button button_end;

    // Start is called before the first frame update
    void Start()
    {
        button_title = GameObject.Find("/Canvas/Button_start").GetComponent<Button>();
        button_end = GameObject.Find("/Canvas/Button_end").GetComponent<Button>();

        button_title.Select();
    }

    
}
