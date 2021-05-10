using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScene : MonoBehaviour
{
    public GameObject pauseSelect;

    // Start is called before the first frame update
    void Start()
    {
        pauseSelect.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void OnClickSound()
    {
        pauseSelect.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void OnClickRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
