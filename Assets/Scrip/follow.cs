using UnityEngine;
using System.Collections;

public class follow : MonoBehaviour
{
    private Transform target;
    private Vector3 pos;
    public GameObject singer;

    public float speed = 100.0F;

    // Use this for initialization
    void Start()
    {
        target = singer.transform;

    }

    // Update is called once per frame
    void Update()
    {
        Quaternion angel = Quaternion.LookRotation(target.position - this.transform.position);
        angel.y = angel.y;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, angel, speed * Time.deltaTime);
        //Debug.Log(speed * Time.deltaTime);
    }
}