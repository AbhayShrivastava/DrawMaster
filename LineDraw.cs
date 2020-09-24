using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour
{

    [SerializeField]

    private RectTransform m_bannerAdBlock;

    private LineRenderer m_currentStroke;

    private List<LineRenderer> m_lineList = new List<LineRenderer>();

    private List<LineRenderer> m_duplicatedLineList = new List<LineRenderer>();

    private bool m_enabled;

    private bool m_isButtonDown;

    private string m_output;

    [System.Serializable]

    public class ImageDataStroke
    {
        public List<int> x = new List<int>();
        public List<int> y = new List<int>();


    }




    public void Update()
    {



        if (Input.GetMouseButtonDown(0))
        {

            Vector2 posVec = new Vector2(Input.mousePosition.x, Input.mousePosition.y);








        }




    }
    private bool IsPositionInRect(Vector2 posVec)
    {
        RectTransform rect = base.transform as RectTransform;
        return RectTransformUtility.RectangleContainsScreenPoint(rect, posVec, Camera.main);
    }

    private bool IsPositionInRect(Vector2 posVec, RectTransform rect)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rect, posVec, Camera.main);
    }

    public static Rect RectTransformToScreenSpace(RectTransform transform)
    {
        Vector2 vector = Vector2.Scale(transform.rect.size, transform.lossyScale);
        Rect result = new Rect(transform.position.x, (float)Screen.height - transform.position.y, vector.x, vector.y);
        result.x -= transform.pivot.x * vector.x;
        result.y -= (1f - transform.pivot.y) * vector.y;

        return result;
    }

    public string GetStringOutPut()
    {
        return this.m_output;
    }
    

    public void OnProcessDrawing()
    {

        foreach(LineRenderer original in this.m_lineList)
        {
            LineRenderer item = Object.Instantiate<LineRenderer>(original);
            this.m_duplicatedLineList.Add(item);
        }

        float num = float.MaxValue;
        float num2 = float.MaxValue;
        float num3 = float.MinValue;
        float num4 = float.MinValue;

        foreach(LineRenderer lineRenderer in this.m_duplicatedLineList)
        {
            Vector3[] array = new Vector3[lineRenderer.positionCount];
            lineRenderer.GetPositions(array);
            foreach(Vector3 vector in array)
            {
                if(vector.x<num)
                {
                    num = vector.x;
                }
                if(vector.y<num2)
                {
                    num2 = vector.y;
                }
                if(vector.x>num3)
                {
                    num3 = vector.x;

                }
                if(vector.y>num4)
                {
                    num4 = vector.y;
                }
            }
        }
        int num5 = 2;
        if(this.m_duplicatedLineList.Count>15)
        {
            num5 = 6;
        }
        else if(this.m_duplicatedLineList.Count>10)
        {
            num5 = 5;
        }
        else if(this.m_duplicatedLineList.Count>5)
        {
            num5 = 4;
        }
        float a = 255f / (num3 - num);
        float b = 255f / (num4 - num2);

        float num6 = Mathf.Min(a, b);


        List<double> list = new List<double>();
        int num7 = 0;
        int num8 = 0;
        foreach(LineRenderer line in this.m_duplicatedLineList)
        {
            Vector3[] array2 = new Vector3[line.positionCount];



        }

    }

      
    
}


