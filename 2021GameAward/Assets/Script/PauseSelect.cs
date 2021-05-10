using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseSelect : MonoBehaviour
{
    public GameObject pauseUI;


    // Start is called before the first frame update
    void Start()
    {
        pauseUI.GetComponent<GameObject>();
    }

    void Update()
    {
        if (Input.GetKeyDown("p") || Input.GetKeyDown("joystick button 7"))
        {
            gameObject.SetActive(false);
        }
    }
}
