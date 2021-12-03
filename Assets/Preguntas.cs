using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preguntas : MonoBehaviour
{
    public AudioSource pregunta1;
    public AudioSource pregunta2;
    public int x;
    public AudioSource correct;
    public AudioSource error;
    public int score;
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(0, 10);
        if (x>5)
        {
            pregunta1.Play();
        }
        else
        {
            pregunta2.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (x==0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                correct.Play();
                score++;
                cambio();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                error.Play();
                cambio();
            }
        }

        if (x==1)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                error.Play();
                cambio();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                error.Play();
                cambio();

            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                correct.Play();
                score++;
                cambio();
            }

            
         

        }

    }

    IEnumerator cambio()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Introduction");
    }
}
