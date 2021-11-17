using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ListRandom : MonoBehaviour
{
    public List<int> Randomlist = new List<int>();
    public List<int> Comparison = new List<int>();

    public int l = 3;
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
               Comparison.Add(int.Parse(hit.transform.name));
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            bool isEqual = Enumerable.SequenceEqual(Randomlist.OrderBy(e => e), Comparison.OrderBy(e => e));
            if (isEqual)
            {
             print("es igual");
            }
            else
            {
                print("No es igual");
            }
            Randomlist.Clear();
            Comparison.Clear();
            l++;
            StartCoroutine(Mov_seq());
        }

       
    }


  
        IEnumerator Mov_seq()
        {
            for (int i = 0; i < l; i++)
            {
                Randomlist.Add(Random.Range(1,5));
            }
        
            foreach (int n in Randomlist)
            {
                GameObject objeto_e = GameObject.FindGameObjectWithTag(n.ToString());
                objeto_e.transform.position += new Vector3(0, 1, 0);
                yield return new WaitForSeconds(1);
                objeto_e.transform.position -= new Vector3(0, 1, 0);
            }
        }   
    }
  

