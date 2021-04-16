using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreTimer : MonoBehaviour
{
    public float timer;
    bool OnTimer = false;
    string target = "GameScene";
    string currentSceneName;

    public static float[] GameSceneTimers = new float[4] { 0.0f,0.0f,0.0f,0.0f};
    public static int currentSceneNumber;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName.Contains("4"))
        {
            OnTimer = true;
            currentSceneNumber++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OnTimer)
        {
            timer += Time.deltaTime;
            if (SphereStage3.IsGoal)
            {
                GameSceneTimers[3] = timer;
                OnTimer = false;
            }
        }
    }
}
