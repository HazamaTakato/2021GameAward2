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
    Ray ray;
    Ray topray;
    int distance;
    float distanceTopray;
    public GameObject overPlayer;
    public Rigidbody rigid;
    float playerSize;
    Vector3 vec;
    DIRECTION direction;
    // Start is called before the first frame update
    void Start()
    {
        distance = 1;
        distanceTopray = 0.6f;
        overPlayer.GetComponent<GameObject>();
        rigid.GetComponent<Rigidbody>();
        playerSize = overPlayer.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        playerSize = overPlayer.transform.localScale.x;

        if (Input.GetKey(KeyCode.A) && rigid.velocity.x <= 0)
        {
            direction = DIRECTION.LEFT;
        }
        else if (Input.GetKey(KeyCode.D) && rigid.velocity.x >= 0)
        {
            direction = DIRECTION.RIGHT;
        }
        if (direction == DIRECTION.RIGHT)
            //vec = new Vector3(1,0,0);
            ray = new Ray(new Vector3(transform.position.x + ((playerSize - 1) / 2), transform.position.y - 0.0f), new Vector3(1, 0, 0));
        else
            //vec = new Vector3(-1, 0, 0);
            ray = new Ray(new Vector3(transform.position.x - ((playerSize - 1) / 2), transform.position.y - 0.0f), new Vector3(-1, 0, 0));

        topray = new Ray(new Vector3(transform.position.x, transform.position.y + (playerSize - 1) / 2), new Vector3(0, 1, 0));

        RaycastHit hit;
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * distance, Color.yellow);
        Debug.DrawLine(topray.origin, topray.origin + topray.direction * distanceTopray, Color.yellow);

        if (Physics.Raycast(topray, out hit, distanceTopray))
            //
            //bool型でプレイヤーのサイズ変更許可入れる場所
            //
            return;
        if (!Physics.Raycast(ray, out hit, distance))
        {
            if (blocks.Count > 1)
            {
                if (direction == DIRECTION.RIGHT && Input.GetKey(KeyCode.D))
                {
                    if(rigid.velocity.x < 0)
                    //rigid.AddForce(Input.GetAxis("Horizontal") * (4 * overPlayer.transform.localScale.x),
                    //               Input.GetAxis("Horizontal") * (10 * overPlayer.transform.localScale.y), 0);
                    rigid.velocity = new Vector3(1.5f * overPlayer.transform.localScale.x, 1.5f * overPlayer.transform.localScale.x, 0);
                    //Debug.Log("assist");
                }
                else if (direction == DIRECTION.LEFT && Input.GetKey(KeyCode.A))
                {
                    if(rigid.velocity.x > 0)
                    //rigid.AddForce(Input.GetAxis("Horizontal") * (4 * overPlayer.transform.localScale.x), 
                    //               Input.GetAxis("Horizontal") * (-10 * overPlayer.transform.localScale.y), 0);
                    rigid.velocity = new Vector3(-1.5f * overPlayer.transform.localScale.x, 1.5f * overPlayer.transform.localScale.x, 0);
                    //Debug.Log("assist");
                }
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.transform.position.y < transform.position.y)
            blocks.Add(other.gameObject);
    }
    private void OnCollisionExit(Collision other)
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            if (blocks[i].name == other.gameObject.name)
            {
                blocks.Remove(blocks[i]);
            }
        }
    }
}
