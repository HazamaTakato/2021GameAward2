using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{
    GameObject Player;

    Sphere playerItem;
    SphereStage2 playerItem2;
    SphereStage3 playerItem3;

    public bool TWO=false;

    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        audioSource = GetComponent<AudioSource>();
        playerItem = Player.GetComponent<Sphere>();
        playerItem2 = Player.GetComponent<SphereStage2>();
        playerItem3 = Player.GetComponent<SphereStage3>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)||
            Input.GetKey("joystick button 0"))
        {
            audioSource.PlayOneShot(sound1);
        }
        else if(Input.GetKey(KeyCode.X) ||
           Input.GetKey("joystick button 1"))
        {
            audioSource.PlayOneShot(sound3);
        }
        if(playerItem.GetItem)
        {
            TWO = true;
        }
        else if(playerItem2.GetItem)
        {
            TWO = true;
        }
        else if(playerItem3.GetItem)
        {
            TWO = true;
        }
        if(TWO)
        { 
            audioSource.PlayOneShot(sound2);
            TWO = false;
        }
    }
}
