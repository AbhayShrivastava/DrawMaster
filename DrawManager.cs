using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    public bool isMousePressed;
  
    private Vector3 mousePos;

    public GameObject Line;
    public static DrawManager instance;




   
  
   


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        #region mouseInput

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Line, transform);
            isMousePressed = true;
          
           
        }
        if (Input.GetMouseButtonUp(0))
        {
             
          
            isMousePressed = false;
          
        }
    }
    #endregion


   
}


