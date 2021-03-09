using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class zoom2 : MonoBehaviour
{
    public Camera cam;
    public GameObject gobal;
    public float i,j;
    //public PostProcessVolume volume;
    //public DepthOfField _dof;



    void Start () {
       cam = this.GetComponent<Camera>();
        //volume.profile.TryGetSettings(out _dof);

    }
   void Update () {
        i = gobal.GetComponent<get_arduino>().m_FieldOfView;
       // j = gobal.GetComponent<get_arduino>().m_Focus;
        if (i >= cam.fieldOfView + 2 || i <= cam.fieldOfView - 2)
        {
            
            cam.fieldOfView = cam.fieldOfView + (i - cam.fieldOfView) / 10;
            //_dof.focalLength.value = j;
            //Debug.Log(cam.fieldOfView);
        }
       

   }
}
