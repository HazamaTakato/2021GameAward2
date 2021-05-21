using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject pauseSelect;
    Button title;
    Button sound;
    Button retry;

    void Start()
    {
        pauseUI.GetComponent<GameObject>();
        pauseSelect.GetComponent<GameObject>();
        title = GameObject.Find("/PauseUI2/Title").GetComponent<Button>();
        sound = GameObject.Find("/PauseUI2/Sound").GetComponent<Button>();
        retry = GameObject.Find("/PauseUI2/Retry").GetComponent<Button>();

        pauseUI.SetActive(false);
        pauseSelect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p")|| Input.GetKeyDown("joystick button 7"))
        {

            pauseUI.SetActive(!pauseUI.activeSelf);

            if (pauseUI.activeSelf)
            {
                retry.Select();
                Time.timeScale = 0f;
            }
            else
            {
                sound.Select();
                Time.timeScale = 1f;
            }
            if (pauseSelect.activeSelf)
                retry.Select();
        }
    }
}
