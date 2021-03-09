using UnityEngine;
using System.Collections;

public class stabalier : MonoBehaviour
{
    private Transform target_P;
    private Transform target_R;
    private Vector3 pos;
    public GameObject colider;
    public GameObject front;

    public float speed = 5;

    // Use this for initialization
    void Start()
    {
        target_P = colider.transform;
        target_R = front.transform;

    }

    // Update is called once per frame
    void Update()
    {
        pos = target_P.position;
        this.transform.position = Vector3.Lerp(this.transform.position, pos, speed * Time.deltaTime);//调整相机与玩家之间的距离
        //Quaternion angel = Quaternion.LookRotation(target_R.position - this.transform.position);//获取旋转角度
        Quaternion angel = Quaternion.LookRotation(this.transform.position-target_R.position);
         this.transform.rotation = Quaternion.Slerp(this.transform.rotation, angel, speed * Time.deltaTime);
        //Debug.Log(target_R.position + offset - this.transform.position);

    }
}
