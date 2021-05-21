using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class title_select : MonoBehaviour
{
    Button Button_start;
    // Start is called before the first frame update
    void Start()
    {
        Button_start = GameObject.Find("Button_start").GetComponent<Button>();
        Button_start.Select();
    }

    
}
