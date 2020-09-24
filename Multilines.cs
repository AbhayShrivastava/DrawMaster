using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Multilines : MonoBehaviour {

    private LineRenderer Line;
    private Vector3 mousePos;
    public Material material;
    private int currLines = 0;




    private void Start()
    {
        
    }
    private void Update()
    {
        

        if(Input.GetMouseButtonDown(0))
        {
            if(Line==null)
            {


                CreateLine();
            }

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Line.SetPosition(0, mousePos);
            Line.SetPosition(1, mousePos);
        }
        else if (Input.GetMouseButtonUp(0)&&Line)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Line.SetPosition(1, mousePos);
            Line = null;
            currLines++;


        }
        else if (Input.GetMouseButton(0)&&Line)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Line.SetPosition(1, mousePos);
        }

    }
    void CreateLine()
    {

        Line = new GameObject("Line" + currLines).AddComponent<LineRenderer>();
        Line.material = material;
        Line.positionCount = 2;
        Line.startWidth = 0.15f;
        Line.endWidth = 0.15f;
        Line.useWorldSpace = false;
        Line.numCapVertices = 50;



    }











}
