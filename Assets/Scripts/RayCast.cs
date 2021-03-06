using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class RayCast : MonoBehaviour
{
    
    [Header("UI")]
    public Text time;
    
    [Header("Timer")]
    public int totalTime = 5; 
    private float nextTime;             
    private float pauseTime;

    [Header("Escena")]
    private int option;   
    private bool isClicked;
    private bool isWorking;
    
    void Start()
    {
        nextTime = 0;     
        pauseTime = 1f;
        isWorking=false;
        isClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (isWorking == true)
        {    
            Timer();
        }
        
        if(Input.GetMouseButtonDown(0) && isClicked == false)
        {
            if(Physics.Raycast(ray, out hit) == true)
            {
                var selection = hit.transform;
                Debug.Log("El rayo toca con: "+ hit.transform.gameObject.tag);
                if(selection.CompareTag("CUBO1") || selection.CompareTag("CUBO2") || selection.CompareTag("ESFERA"))
                {
                    if (selection.CompareTag("CUBO1"))
                    {
                        option=1;
                    }
                    if (selection.CompareTag("ESFERA"))
                    {
                        option=2;
                    }
                    if (selection.CompareTag("CUBO2"))
                    {
                        option=3;
                    }
                    isWorking=true;
                    StartCoroutine(Count());
                }   
            }
        }
    }

    void Timer()
    {
        if (Time.time > nextTime)
            {
                nextTime = Time.time + pauseTime;
                if(totalTime >= 0)
                {
                totalTime--;
                }
            }
            if (totalTime < 0)
            {      
                totalTime = 0;
            }
            time.text=totalTime.ToString();
    }

    IEnumerator Count()
    {
        yield return new WaitForSeconds(5f);
        if (option==1)
        {
            SceneManager.LoadScene("Scene1");
        }
        if (option==2)
        {
            SceneManager.LoadScene("Scene2");
        }
        if (option==3)
        {
            SceneManager.LoadScene("Scene3");
        }
    
    }


}