using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public AudioClip[] Intrucciones;
    public AudioSource audiosource;
    public AudioSource audioManager;
    public bool flag=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            flag = true;
            audioManager.volume = 0;

        }

        if (flag==true)
        {
          audiosource.PlayOneShot(RandomClip());
          flag = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SampleScene");
        }
        
        
    }

    AudioClip RandomClip()
    {
        return Intrucciones[0];



}
}
