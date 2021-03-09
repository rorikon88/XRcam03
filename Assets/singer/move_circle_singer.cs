using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_circle_singer : MonoBehaviour
{
    public float timeConter = 0;
    public float speed, width, height;
    public GameObject singer;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.8f;
        width = 10;
        height = 20;
        target = singer.transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeConter += Time.deltaTime * speed;
        //人物方位
        float x = (Mathf.Sin(timeConter) * width) + target.position.x;
        float y = target.position.y;
        float z = (Mathf.Cos(timeConter) * height) + target.position.z;
        
        transform.position = new Vector3(x, y, z);
        //transform.RotateAround(Vector3.zero, Vector3.up, 30 * Time.deltaTime);
    }
}
