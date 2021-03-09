using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class auto_focus_01 : MonoBehaviour
{
    //測距物件
    public GameObject cam;
    public GameObject singer;
    public Vector2 pos1;
    public Vector2 pos2;
    float distance;

    //對焦物件
    public Camera camera;
    public float j;
    public PostProcessVolume volume;
    public DepthOfField _dof;

    // Start is called before the first frame update
    void Start()
    {
        //對焦物件設定
        camera = this.GetComponent<Camera>();
        volume.profile.TryGetSettings(out _dof);
    }

    // Update is called once per frame
    void Update()
    {
        pos1 = cam.transform.position;
        pos2 = singer.transform.position;
        distance = Vector3.Distance(pos1, pos2);
       // Debug.Log(distance);
        //_dof.focalLength.value = distance * 3.5f;
       // _dof.focusDistance.value = (distance * 3.2f)-1.5f;
        _dof.focusDistance.value = distance;
    }
}
