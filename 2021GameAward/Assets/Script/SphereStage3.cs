using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SphereStage3 : MonoBehaviour
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
    //public GameObject fallblock;
    //public GameObject lever;
    //public GameObject leverblock;
    //public GameObject leverblock2;
    public GameObject valve;
    public GameObject valveblock;
    public GameObject valve2;
    public GameObject valveblock2;
    public GameObject valve3;
    public GameObject valveblock3;
    //public GameObject lever2;
    //public GameObject lever2block;
    //public GameObject lever3;
    //public GameObject lever3block;
    public GameObject valve4;
    public GameObject valveblock4;
    public bool getValve;
    public bool getValve2;
    public bool getValve3;
    public bool getValve4;
   //public bool leverON;
   //public bool lever2ON;
    public GameObject button;
    public GameObject buttonblock;
    public bool buttonON;
    public GameObject lever4;
    public GameObject lever4block;

    public Slider changeGauge;
    public float Gauge;
    bool changeBig;
    public GameObject[] block2;
    PlayerItemStage3 playerItem;
    float keyTimelimit;

    public Camera pcamera;
    public static bool IsGoal = false;
    bool buttontouch;
    bool getlever4;

    bool goalF;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        addcutSize = new Vector3(0.01f, 0.01f, 0);
        downaddcutSize = new Vector3(0.1f, 0.1f, 0);
        changeSize = false;
        getValve = false;
        GetItem = false;
        buttonON = false;
        changeGauge.value = 1000;
        changeBig = true;
        block2 = GameObject.FindGameObjectsWithTag("block2");
        playerItem = GetComponent<PlayerItemStage3>();
        keyTimelimit = 0;
        buttontouch = false;
        getlever4 = false;
        PlayerItem.GetItem = false;
        PlayerItem.DropItem = false;
        goalF = false;
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
        }
        if(getValve||getValve2||getValve3||getValve4)
        {
            rb.velocity = new Vector3(0, 0, 0);
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

        //if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown("joystick button 6"))
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}

        //ゲージで大きさの指標をしている処理
        Gauge = normal.transform.localScale.x - 1.0f;
        changeGauge.value = (Gauge * 1000) / 1.6f;

        if (normal.transform.localScale.x == 1.0f)
        {
            changeSize = false;
        }   

        //if(GetItem)
        //{
        //    Item.SetActive(false);
        //}

        //if(Input.GetKeyDown(KeyCode.C)&&GetItem)
        //{
        //    GetItem = false;
        //    Item.SetActive(true);
        //    Item.transform.position = this.transform.position;
        //}
        //if (normal.transform.localScale.x <= 1)
        //{
        //    hitflag = true;
        //}
        //else
        //{
        //    hitflag = false;
        //    GetItem = false;
        //}
        if (getValve)
        {
            this.transform.position = valve.transform.position;
            if (Input.GetKey(KeyCode.D)&& valve.transform.localPosition.y >= 0.7f || Input.GetAxis("Horizontal") > 0 && valve.transform.localPosition.y >= 0.7f)
            {
                valve.transform.Rotate(0, 0, 0.1f);
                valve.transform.localPosition -= new Vector3(0, 0.01f, 0);
                valveblock.transform.localPosition -= new Vector3(0, 0.01f, 0);
            }
            if (Input.GetKey(KeyCode.A)&& valve.transform.localPosition.y <= 10.5f|| Input.GetAxis("Horizontal") < 0 && valve.transform.localPosition.y <= 10.5f)
            {
                valve.transform.Rotate(0, 0, -0.1f);
                valve.transform.localPosition += new Vector3(0, 0.01f, 0);
                valveblock.transform.localPosition += new Vector3(0, 0.01f, 0);
            }
        }
        if (getValve2)
        {
            this.transform.position = valve2.transform.position;
            if (Input.GetKey(KeyCode.D) && valve2.transform.localPosition.y >= 0.7f || Input.GetAxis("Horizontal") > 0 && valve2.transform.localPosition.y >= 0.7f)
            {
                valve2.transform.Rotate(0, 0, 0.1f);
                valve2.transform.localPosition -= new Vector3(0, 0.01f, 0);
                valveblock2.transform.localPosition -= new Vector3(0, 0.01f, 0);
            }
            if (Input.GetKey(KeyCode.A) && valve2.transform.localPosition.y <= 9.6f || Input.GetAxis("Horizontal") < 0 && valve2.transform.localPosition.y <= 9.6f)
            {
                valve2.transform.Rotate(0, 0, -0.1f);
                valve2.transform.localPosition += new Vector3(0, 0.01f, 0);
                valveblock2.transform.localPosition += new Vector3(0, 0.01f, 0);
            }
        }
        if (getValve3)
        {
            this.transform.position = valve3.transform.position;
            //if (leverON)
            //{
                //fallblock.transform.localPosition -= new Vector3(0, 0.002f, 0);
                if (Input.GetKey(KeyCode.D)&& valve3.transform.localPosition.y >= 0.5f || Input.GetAxis("Horizontal") > 0 && valve3.transform.localPosition.y >= 0.5f)
            {
                    valve3.transform.Rotate(0, 0, 0.1f);
                    valve3.transform.localPosition -= new Vector3(0, 0.01f, 0);
                    valveblock3.transform.localPosition -= new Vector3(0, 0.01f, 0);
                }
                if (Input.GetKey(KeyCode.A)&& valve3.transform.localPosition.y <= 9.6f || Input.GetAxis("Horizontal") < 0 && valve3.transform.localPosition.y <= 9.6f)
            {
                    valve3.transform.Rotate(0, 0, -0.1f);
                    valve3.transform.localPosition += new Vector3(0, 0.01f, 0);
                    valveblock3.transform.localPosition += new Vector3(0, 0.01f, 0);
                }
            //}
            //if (lever2ON)
            //{
            //    fallblock.SetActive(false);
            //    if (Input.GetKey(KeyCode.D) && valve3.transform.localPosition.y >= 3.5f)
            //    {
            //        valve3.transform.Rotate(0, 0, 0.1f);
            //        valve3.transform.localPosition -= new Vector3(0, 0.004f, 0);
            //        valveblock3.transform.localPosition -= new Vector3(0, 0.004f, 0);
            //    }
            //    if (Input.GetKey(KeyCode.A) && valve3.transform.localPosition.y <= 8.6f)
            //    {
            //        valve3.transform.Rotate(0, 0, -0.1f);
            //        valve3.transform.localPosition += new Vector3(0, 0.004f, 0);
            //        valveblock3.transform.localPosition += new Vector3(0, 0.004f, 0);
            //    }
            //}
        }
        if (getValve4)
        {
            this.transform.position = valve4.transform.position;
            if (Input.GetKey(KeyCode.D)&& valve4.transform.localPosition.y >= 0.6f || Input.GetAxis("Horizontal") > 0 && valve4.transform.localPosition.y >= 0.6f)
            {
                valve4.transform.Rotate(0, 0, 0.1f);
                valve4.transform.localPosition -= new Vector3(0, 0.01f, 0);
                valveblock4.transform.localPosition -= new Vector3(0, 0.01f, 0);
            }
            if (Input.GetKey(KeyCode.A)&& valve4.transform.localPosition.y <= 5.7f || Input.GetAxis("Horizontal") < 0 && valve4.transform.localPosition.y <= 5.7f)
            {
                valve4.transform.Rotate(0, 0, -0.1f);
                valve4.transform.localPosition += new Vector3(0, 0.01f, 0);
                valveblock4.transform.localPosition += new Vector3(0, 0.01f, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Q)||Input.GetKeyDown("joystick button 3"))
        {
            getValve = false;
            getValve2 = false;
            getValve3 = false;
            getValve4 = false;
        }

        if(getValve||getValve2||getValve3||getValve4)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            pcamera.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, pcamera.transform.localPosition.z); 
            
        }
        if(buttonON)
        {
            buttontouch = true;
            if (buttonblock.transform.localPosition.y >= -6.8)
            {
                buttonblock.transform.localPosition -= new Vector3(0, 0.01f, 0);
            }
        }
        if (!buttonON)
        {
            if (getlever4 && buttontouch)
            {
                if (buttonblock.transform.localPosition.y <= -1.12f)
                {
                    buttonblock.transform.localPosition += new Vector3(0, 0.001f, 0);
                }
            }
            if (PlayerItem.GetItem && buttontouch)
            {
                if (buttonblock.transform.localPosition.y <= 3.776f)
                {
                    buttonblock.transform.localPosition += new Vector3(0, 0.001f, 0);
                }
            }
        }
        if (goalF)
        {
            rb.velocity = new Vector3(0, 0, 0);
            rb.useGravity = false;
            this.transform.localPosition = new Vector3(27.78f, 10.18f, 0);
            this.transform.localScale -= new Vector3(0.015f, 0.015f, 0.015f);
            if (transform.localScale.x <= 0.0f)
            {
                transform.localScale = new Vector3(0, 0, 0);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="button")
        {
            buttonON = false;
            button.transform.localPosition = new Vector3(0, 0, 10);
            //button.transform.localPosition = new Vector3(14, 6.45f, 0);
        }
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
        if(other.tag=="button")
        {
            buttonON = true;
            //button.transform.localPosition = new Vector3(13.76f, 6.45f, 0);
            button.transform.localPosition = new Vector3(-0.6f,0, 10);
        }
        if (other.tag == "Goal" && PlayerItem.GetItem)
        {
            PlayerItem.GetItem = false;
            PlayerItem.DropItem = false;
            IsGoal = true;
            goalF = true;
            //SceneManager.LoadScene("GameScene5");
            FadeManager.Instance.LoadScene("GameScene5", 1.0f);
        }
        //if (other.tag == "lever")
        //{
        //    leverblock.SetActive(false);
        //    leverblock2.SetActive(false);
        //    lever.transform.localRotation = new Quaternion(0, 0, 3.5f, 1);
        //    leverON = true;
        //}

        //if (other.tag == "lever2")
        //{
        //    lever2block.SetActive(false);
        //    lever2.transform.localRotation = new Quaternion(0, 0, 3.5f, 1);
        //    lever2ON = true;
        //}

        //if (other.tag == "lever3")
        //{
        //    lever3block.SetActive(false);
        //    lever3.transform.localRotation = new Quaternion(0, 0, -3.5f, 1);
        //}

        if(other.tag=="lever4")
        {
            lever4block.SetActive(false);
            lever4.transform.localRotation = new Quaternion(0, 0, 3.5f, 1);
            getlever4 = true;
        }

        if (other.tag == "valve")
        {
            getValve = true;
        }
        if (other.tag == "valve2")
        {
            getValve2 = true;
        }
        if (other.tag == "valve3")
        {
            getValve3 = true;
        }
        if (other.tag == "valve4")
        {
            getValve4 = true;
        }
    }
}
