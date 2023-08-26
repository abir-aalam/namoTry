using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Timeline;

public class TimeLine : MonoBehaviour
{
    Volume PostVolume;
    public bool PlayPost = false;
    // Start is called before the first frame update
    void Start()
    {
        PostVolume = GetComponent<Volume>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayPost)
        {

        }
    }
    public void PlayPos()
    {
        PlayPost = true;
    }
}
