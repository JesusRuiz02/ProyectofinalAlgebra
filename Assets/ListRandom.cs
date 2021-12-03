using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
public class ListRandom : MonoBehaviour
{
    public List<int> Randomlist = new List<int>();
    public List<AudioSource> Randomlista = new List<AudioSource>();
    public List<AudioSource> Comparison = new List<AudioSource>();
    public AudioSource[] clips;
    private Pause _pause;
    public bool flag=true;
    public List<AudioSource> preguntas;
    public int score = 0;
    public int x;

    public int l = 3;
    public int valid = 0;
    // Start is called before the first frame update
    void Start()
    {


        StartCoroutine(Mov_seq());
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
               print(hit.transform.name);
               GameObject a = GameObject.FindGameObjectWithTag(hit.transform.name); 
               Comparison.Add(a.GetComponent<AudioSource>());
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameObject a = GameObject.FindGameObjectWithTag("1");
            Comparison.Add(a.GetComponent<AudioSource>());
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameObject a = GameObject.FindGameObjectWithTag("2");
            Comparison.Add(a.GetComponent<AudioSource>());
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GameObject a = GameObject.FindGameObjectWithTag("3");
            Comparison.Add(a.GetComponent<AudioSource>());
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GameObject a = GameObject.FindGameObjectWithTag("4");
            Comparison.Add(a.GetComponent<AudioSource>());
        }



            

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (Randomlista.Count==Comparison.Count)
            {
                for(int i=0; i<l; i++)
                {
                    if (Randomlista[i].clip!=Comparison[i].clip)
                    {
                        valid++;
                    }
                }
                if (valid>0)
                {
                    print("Diferente");
                    score--;

                }
                else
                {
                    print("Igual");
                    score++;
                }
            }

            

            if (Randomlista.Count != Comparison.Count)
            {
                print("No tienen la misma longitud");
            }

        
            
            Randomlista.Clear(); 
            Comparison.Clear();
            l++;
            StartCoroutine(Mov_seq());
        }

        if (l==5)
        {
            x = Random.Range(0, 1);
            preguntas[x].Play();
            
        }

        if (l==7)
        {
            if (score>=4)
            {
                SceneManager.LoadScene("Ganaste");
            }
            else
            {
                SceneManager.LoadScene("Perdiste");
            }
        }

       
    }


  
        IEnumerator Mov_seq()
        {

            if (l==5)
            {
                yield return new WaitForSeconds(10);
            }
            for (int i = 0; i < l; i++)
            {
                    Randomlista.Add(clips[Random.Range(0,4)]);
            }
        
                foreach (AudioSource n in Randomlista)
                {
                    n.Play();
                    while (n.isPlaying)
                    {
                        yield return null;
                    }
     
                }
            
            
        }

      /*  public void Paus()
        {
            flag = !flag;
            if (flag)
            {
                 foreach (AudioSource a in clips)
                 {
                                a.Pause();
                                print("Pause");
                 }
            }
            else
            {
                 foreach (AudioSource a in clips)
                 {
                                a.Play();
                                print("Play");
                 }
            }
        }*/
    }
  

