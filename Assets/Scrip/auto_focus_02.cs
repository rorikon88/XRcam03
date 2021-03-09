using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class auto_focus_02 : MonoBehaviour
{
    //測距物件
    public GameObject cam;
    public GameObject singer;
    public Vector3 pos1;
    public Vector3 pos2;
    float distance;

    //對焦物件
    public Camera camera;
    public float j,maxDistance = 3.0f;
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
        if (distance < 0) distance = distance * -1;
        if(distance >6&& distance < 70)
        {
            
            distance = distance - distance / distance /10;
        }
        _dof.focusDistance.value = distance;
        //Debug.Log(distance);
        //Mathf.Sin(_dof.focusDistance.value)*1000+800 = Mathf.Cos(distance) * 1000 - 610;
        //_dof.focusDistance.value = (Mathf.Pow(1.3f, distance)-1)*2.3f;
        //(1.3 ^ x - 1) * 2
        //Mathf.Pow(6, 1.8)



    }
    }
