using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class EndTimeLine : MonoBehaviour
{
    public GameObject timelineCam;
    public Light Plight;
    bool PlayPost = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayPost)
        {
            Plight.intensity += 1000f * Time.deltaTime;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (collision.transform.CompareTag("Player"))
            {
                StartCoroutine(ChangeScene());
            }
        }
    }
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene(3);
    }
    public void LightUp()
    {
        PlayPost = true;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
