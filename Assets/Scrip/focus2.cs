using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class focus2 : MonoBehaviour
{
    public Camera cam;
    public GameObject gobal;
    public float j;
    public PostProcessVolume volume;
    public DepthOfField _dof;



    void Start()
    {
        cam = this.GetComponent<Camera>();
        volume.profile.TryGetSettings(out _dof);

    }
    void Update()
    {
        j = gobal.GetComponent<get_arduino>().m_Focus;
           // _dof.focalLength.value = j;
        _dof.focusDistance.value = _dof.focusDistance.value + (j - _dof.focusDistance.value) / 2;
        //_dof.focusDistance.value = distance;


    }
}
