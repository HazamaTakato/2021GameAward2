using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AllTime : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {      
        //Debug.Log(ScoreTimer.GameSceneTimers[3]);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = ScoreTimer.GameSceneTimers[3].ToString("F2");
    }
}
