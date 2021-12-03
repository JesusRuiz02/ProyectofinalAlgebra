using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class Pause : MonoBehaviour
{
    private ListRandom _listRandom;
    public bool flag = true;
    public int x;

    public List<AudioSource> preguntas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /*void Update()
    {
        if (_listRandom.score>=3)
        {
            if (flag)
            {
               x =Random.Range(0, 1);
                preguntas[x].Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
        }
    }*/


    
}
