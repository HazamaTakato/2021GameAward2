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
    AudioSource BGM;
    public AudioSource SizeChangeBig;
    public AudioSource SizeChangeSmall;
    public AudioSource Item;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        audioSource = GetComponent<AudioSource>();
        SizeChangeBig.GetComponent<AudioSource>();
        SizeChangeSmall.GetComponent<AudioSource>();
        Item.GetComponent<AudioSource>();

        playerItem = Player.GetComponent<Sphere>();
        playerItem2 = Player.GetComponent<SphereStage2>();
        playerItem3 = Player.GetComponent<SphereStage3>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0f)
            return;

        if (PlayerItem.GetItem)
        {
            if (!TWO)
                Item.PlayOneShot(sound2);
            TWO = true;
        }

        if (PlayerItem.GetItem)
            return;

        if(Input.GetKeyDown(KeyCode.Z)||
            Input.GetKeyDown("joystick button 0"))
        {
            SizeChangeBig.PlayOneShot(sound1);
        }
        else if(Input.GetKeyDown(KeyCode.X) ||
           Input.GetKeyDown("joystick button 1"))
        {
            SizeChangeSmall.PlayOneShot(sound3);
        }
        if(PlayerItem.DropItem)
        { 
            TWO = false;
        }
    }
}
