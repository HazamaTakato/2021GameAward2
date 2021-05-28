using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum DIRECTION
{
    RIGHT,
    LEFT,
}
public class PlayerClimb : MonoBehaviour
{
    List<GameObject> blocks = new List<GameObject>();
    Ray frontRay;
    Ray underRay;
    Ray topray;
    float distance;
    float num;
    float underDistance;
    float distanceTopray;
    public GameObject overPlayer;
    public Rigidbody rigid;
    float playerSize;
    Vector3 vec;
    DIRECTION direction;
    bool onAssist;
    bool sizecheck;

    public static bool playerChangebig;

    // Start is called before the first frame update
    void Start()
    {
        distance = 0.5f;
        underDistance = 0.35f;
        num = underDistance;
        distanceTopray = 0.6f;
        overPlayer.GetComponent<GameObject>();
        rigid.GetComponent<Rigidbody>();
        playerSize = overPlayer.transform.localScale.x;
        playerChangebig = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerSize = overPlayer.transform.localScale.x;

        if (Input.GetAxis("Horizontal") < 0 && rigid.velocity.x < 0)
        {
            direction = DIRECTION.LEFT;
        }
        else if (Input.GetAxis("Horizontal") > 0 && rigid.velocity.x > 0)
        {
            direction = DIRECTION.RIGHT;
        }
        if (direction == DIRECTION.RIGHT)
        {

            //vec = new Vector3(1,0,0);
            frontRay = new Ray(new Vector3(transform.position.x + ((playerSize) / 2), transform.position.y), new Vector3(1, 0, 0));
            underRay = new Ray(new Vector3(transform.position.x + ((playerSize) / 2), transform.position.y), new Vector3(0, -1, 0));
        }
        else
        {
            //vec = new Vector3(-1, 0, 0);
            frontRay = new Ray(new Vector3(transform.position.x - ((playerSize) / 2), transform.position.y), new Vector3(-1, 0, 0));
            underRay = new Ray(new Vector3(transform.position.x - ((playerSize) / 2), transform.position.y), new Vector3(0, -1, 0));

        }
        underDistance = num + ((playerSize - 1) / 3);

        topray = new Ray(new Vector3(transform.position.x, transform.position.y + (playerSize - 1) / 2), new Vector3(0, 1, 0));

        RaycastHit hit;
        Debug.DrawLine(frontRay.origin, frontRay.origin + frontRay.direction * distance, Color.yellow);
        Debug.DrawLine(topray.origin, topray.origin + topray.direction * distanceTopray, Color.yellow);
        Debug.DrawLine(underRay.origin, underRay.origin + underRay.direction * underDistance, Color.yellow);

        if (Physics.Raycast(topray, out hit, distanceTopray))
            //bool型でプレイヤーのサイズ変更許可入れる場所
            playerChangebig = false;
        else
            playerChangebig = true;

        if (Physics.Raycast(underRay, out hit, underDistance))
        {
            if (hit.collider.tag == "Item")
            {
                Debug.Log("a");
            }
            if (sizecheck)
            {
                onAssist = true;
                if (Input.GetAxis("Horizontal") != 0)
                    rigid.velocity = new Vector3(Input.GetAxis("Horizontal"), Mathf.Abs(Input.GetAxis("Horizontal")), 0); //overPlayer.transform.localScale.x, 0);
            }
        }

        sizecheck = false;
        if (!Physics.Raycast(frontRay, out hit, distance))
        {
            sizecheck = true;
        }
    }
}
