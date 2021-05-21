using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SphereStage2 : MonoBehaviour
{
    public float speed = 1.0f;
    public Rigidbody rb;
    public GameObject Item;
    public bool GetItem;
    public GameObject over;
    public GameObject normal;
    Vector3 addcutSize;
    Vector3 downaddcutSize;
    public bool hitflag;
    public bool changeSize;
   // public GameObject fallblock;
    public GameObject lever;
    public GameObject leverblock;
    public Slider changeGauge;
    public float Gauge;
    //public GameObject leverblock2;
    //public GameObject valve;
    //public GameObject valveblock;
    //public GameObject valve2;
    //public GameObject valveblock2;
    //public GameObject valve3;
    //public GameObject valveblock3;
    //public GameObject lever2;
    //public GameObject lever2block;
    //public GameObject lever3;
    //public GameObject lever3block;
    //public GameObject valve4;
    //public GameObject valveblock4;
    //public bool getValve;
    //public bool getValve2;
    //public bool getValve3;
    //public bool getValve4;
    public bool leverON;
    //public bool lever2ON;
    bool changeBig;
    public GameObject[] block2;
    PlayerItemStage2 playerItem;
    float keyTimelimit;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        addcutSize = new Vector3(0.01f, 0.01f, 0);
        downaddcutSize = new Vector3(0.1f, 0.1f, 0);
        changeSize = false;
        //getValve = false;
        changeGauge.value = 1000;
        GetItem = false;
        changeBig = true;
        block2 = GameObject.FindGameObjectsWithTag("block2");
        playerItem = GetComponent<PlayerItemStage2>();
        keyTimelimit = 0;
        PlayerItem.GetItem = false;
        PlayerItem.DropItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0f)
            return;

        float x = Input.GetAxis("Horizontal") * speed;
        rb.AddForce(x, 0, 0);
        //this.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetKey(KeyCode.Z) ||
            Input.GetKey("joystick button 0"))
        {
            changeSize = true;
            //if (changeGauge.value > 0)
            //{
            if (PlayerItem.GetItem)
            {
                keyTimelimit += Time.deltaTime;
                if (keyTimelimit > 0.5f)
                {
                    PlayerItem.DropItem = true;
                    keyTimelimit = 0;
                }
            }
            else if (normal.transform.localScale.x <= 2.6f && changeBig)
            {
                normal.transform.localScale = normal.transform.localScale + addcutSize;
                over.transform.localScale = over.transform.localScale + addcutSize;
                //changeGauge.value -= 0.01f;
            }
            //}
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            changeSize = true;
            //if (changeGauge.value > 0)
            //{
            if (normal.transform.localScale.x <= 2.6f)
            {
                normal.transform.localScale = normal.transform.localScale + downaddcutSize;
                over.transform.localScale = over.transform.localScale + downaddcutSize;
                //changeGauge.value -= 0.1f;
            }
            //}
        }
        if (Input.GetKey(KeyCode.X) ||
           Input.GetKey("joystick button 1"))
        {
            //changeSize = false;
            if (PlayerItem.GetItem)
            {
                keyTimelimit += Time.deltaTime;
                if (keyTimelimit > 0.5f)
                {
                    PlayerItem.DropItem = true;
                    keyTimelimit = 0;
                }
            }
            else if (normal.transform.localScale.x >= 1.00f)
            {
                normal.transform.localScale = normal.transform.localScale - addcutSize;
                over.transform.localScale = over.transform.localScale - addcutSize;
                //changeGauge.value += 0.01f;
            }
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            //changeSize = false;
            if (normal.transform.localScale.x >= 1.00f)
            {
                normal.transform.localScale = normal.transform.localScale - downaddcutSize;
                over.transform.localScale = over.transform.localScale - downaddcutSize;
                //changeGauge.value += 0.1f;
            }
        }

        if (Input.GetKeyUp(KeyCode.Z) ||
            Input.GetKeyUp("joystick button 0") ||
            Input.GetKeyUp(KeyCode.X) ||
            Input.GetKeyUp("joystick button 1"))
        {
            keyTimelimit = 0;
        }

        //ゲージで大きさの指標をしている処理
        Gauge = normal.transform.localScale.x - 1.0f;
        changeGauge.value = (Gauge * 1000) / 1.6f;

        //if(changeSize)
        //{
        //    changeGauge.value -= normal.transform.localScale.x + 0.01f;
        //}
        //if (!changeSize)
        //{
        //    changeGauge.value += normal.transform.localScale.x + 0.01f;
        //}

        //if (changeGauge.value == 0)
        //{
        //    normal.transform.localScale = new Vector3(1, 1, 1);
        //    over.transform.localScale = new Vector3(1.1f, 1.1f, 1);
        //    changeSize = false;
        //}

        if (normal.transform.localScale.x == 1.0f)
        {
            changeSize = false;
        }

        //if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown("joystick button 7"))
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Item"&&hitflag)
        //{
        //    GetItem = true;
        //}
        //if(other.tag=="DeadItem"&&!GetItem)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}
        if (other.tag == "Goal" && PlayerItem.GetItem)
        {
            PlayerItem.GetItem = false;
            PlayerItem.DropItem = false;
            //SceneManager.LoadScene("GameScene4");
            FadeManager.Instance.LoadScene("GameScene4", 0.05f);
        }
        if(other.tag=="lever")
        {
            leverblock.SetActive(false);
            //leverblock2.SetActive(false);
            lever.transform.localRotation = new Quaternion(0,0,3.5f,1);
            leverON = true;
        }

        //if(other.tag=="lever2")
        //{
        //    lever2block.SetActive(false);
        //    lever2.transform.localRotation = new Quaternion(0, 0, 3.5f, 1);
        //    lever2ON = true;
        //}

        //if(other.tag=="lever3")
        //{
        //    lever3block.SetActive(false);
        //    lever3.transform.localRotation = new Quaternion(0, 0, -3.5f, 1);
        //}

        //if (other.tag == "valve")
        //{
        //    getValve = true;
        //}
        //if (other.tag == "valve2")
        //{
        //    getValve2 = true;
        //}
        //if (other.tag == "valve3")
        //{
        //    getValve3 = true;
        //}
        //if (other.tag == "valve4")
        //{
        //    getValve4 = true;
        //}
    }
}
