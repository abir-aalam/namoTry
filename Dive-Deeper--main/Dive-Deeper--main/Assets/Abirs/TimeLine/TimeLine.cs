using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;

public class TimeLine : MonoBehaviour
{
    Volume PostVolume;
    Bloom b;
    public bool PlayPost = false;
    public int sceneIndex;
    public AudioSource DumpSound;
    // Start is called before the first frame update
    void Start()
    {
        PostVolume = GetComponent<Volume>();
        PostVolume.profile.TryGet(out b);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayPost)
        {
            b.intensity.value += 1000f * Time.deltaTime;
        }
    }
    public void PlayPos()
    {
        PlayPost = true;
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void PlayWaterDumpMusic()
    {
        DumpSound.Play();
    }
}
