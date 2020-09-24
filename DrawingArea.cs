// DecompilerFi decompiler from Assembly-CSharp.dll class: DrawingArea
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class DrawingArea : MonoBehaviour
{
    [Serializable]
    public class ImageDataStroke
    {
        public List<int> x = new List<int>();

        public List<int> y = new List<int>();
    }

    [SerializeField]
    //private RectTransform m_bannerAdBlock;

    private LineRenderer m_currentStroke;



    private List<LineRenderer> m_duplicatedLineList = new List<LineRenderer>();
    private List<LineRenderer> m_lineList = new List<LineRenderer>();



    private bool m_enabled;

    private bool m_isButtonDown;

    private string m_opuput;

    public bool Enabled
    {
        set
        {
            m_enabled = value;
        }
    }
    public GameObject GO;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            float x = mousePosition.x;
            Vector3 mousePosition2 = Input.mousePosition;
            Vector2 posVec = new Vector2(x, mousePosition2.y);

            if (IsPositionInRect(posVec))
            {
                GameObject gameObject = Instantiate(GO);
                m_currentStroke = gameObject.GetComponent<LineRenderer>();
                m_currentStroke.startColor = Color.black;
                m_currentStroke.endColor = Color.black;


                Camera main = Camera.main;
                Vector3 mousePosition3 = Input.mousePosition;
                float x2 = mousePosition3.x;
                Vector3 mousePosition4 = Input.mousePosition;
                Vector3 vector = main.ScreenToWorldPoint(new Vector3(x2, mousePosition4.y, 0f));
                vector.z = 0f;
                m_currentStroke.positionCount = 1;
                m_currentStroke.SetPositions(new Vector3[1]
                {
                vector
                });


                // GameEvents.SendStartedStrokeEvent();
                m_isButtonDown = true;
            }
        }
        else if (Input.GetMouseButton(0) && m_isButtonDown)
        {
            Vector3 mousePosition5 = Input.mousePosition;
            float x3 = mousePosition5.x;
            Vector3 mousePosition6 = Input.mousePosition;
            Vector2 posVec2 = new Vector2(x3, mousePosition6.y);
            if (IsPositionInRect(posVec2))
            {
                Camera main2 = Camera.main;
                Vector3 mousePosition7 = Input.mousePosition;
                float x4 = mousePosition7.x;
                Vector3 mousePosition8 = Input.mousePosition;
                Vector3 vector2 = main2.ScreenToWorldPoint(new Vector3(x4, mousePosition8.y, 0f));
                vector2.z = 0f;
                float sqrMagnitude = (vector2 - m_currentStroke.GetPosition(m_currentStroke.positionCount - 1)).sqrMagnitude;
                if (sqrMagnitude > 0.0009f)
                {
                    m_currentStroke.positionCount += 1;
                    m_currentStroke.SetPosition(m_currentStroke.positionCount - 1, vector2);
                }
            }
        }
        else
        {
            if (!Input.GetMouseButtonUp(0) || !m_isButtonDown)
            {
                return;
            }
            if (m_currentStroke != null)
            {
                if (m_currentStroke.positionCount == 1)
                {
                    Vector3 position = m_currentStroke.GetPosition(0);
                    Vector3 vector3 = position + new Vector3(0.05f, 0f, 0f);
                    m_currentStroke.positionCount = 2;
                    m_currentStroke.SetPositions(new Vector3[2]
                    {
                        position,
                        vector3
                    });
                }
                m_lineList.Add(m_currentStroke);
                //  GameEvents.SendFinishedStrokeEvent();
            }
            m_currentStroke = null;
            m_isButtonDown = false;
           OnProcessDrawing();
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
        Vector3 position = transform.position;
        float x = position.x;
        float num = Screen.height;
        Vector3 position2 = transform.position;
        Rect result = new Rect(x, num - position2.y, vector.x, vector.y);
        float x2 = result.x;
        Vector2 pivot = transform.pivot;
        result.x = x2 - pivot.x * vector.x;
        float y = result.y;
        Vector2 pivot2 = transform.pivot;
        result.y = y - (1f - pivot2.y) * vector.y;
        return result;
    }

    public void ClearDrawing()
    {
        foreach (LineRenderer line in m_lineList)
        {
           Destroy(line.gameObject);
        }
        m_lineList.Clear();
        if (m_currentStroke != null)
        {
            UnityEngine.Object.Destroy(m_currentStroke.gameObject);
            m_currentStroke = null;
        }
        	
    }

    public void HidePencil()
    {
        //if (m_drawingPencil != null)
        {
            //m_drawingPencil.CorrectGuessHidePencil();
        }
    }

    public string GetStringOutPut()
    {
        return m_opuput;

    }

    public void OnProcessDrawing()
    {
        foreach (LineRenderer line in m_lineList)
        {
            LineRenderer item = Instantiate(line);
            m_duplicatedLineList.Add(item);
        }
        float num = float.MaxValue;
        float num2 = float.MaxValue;
        float num3 = float.MinValue;
        float num4 = float.MinValue;
        foreach (LineRenderer duplicatedLine in m_duplicatedLineList)
        {
            Vector3[] array = new Vector3[duplicatedLine.positionCount];
            duplicatedLine.GetPositions(array);
            for (int i = 0; i < array.Length; i++)
            {
                Vector3 vector = array[i];
                if (vector.x < num)
                {
                    num = vector.x;
                }
                if (vector.y < num2)
                {
                    num2 = vector.y;
                }
                if (vector.x > num3)
                {
                    num3 = vector.x;
                }
                if (vector.y > num4)
                {
                    num4 = vector.y;
                }
            }
        }
        int num5 = 2;
        if (m_duplicatedLineList.Count > 15)
        {
            num5 = 6;
        }
        else if (m_duplicatedLineList.Count > 10)
        {
            num5 = 5;
        }
        else if (m_duplicatedLineList.Count > 5)
        {
            num5 = 4;
        }
        float a = 255f / (num3 - num);
        float b = 255f / (num4 - num2);
        float num6 = Mathf.Min(a, b);
        List<double> list = new List<double>();
        int num7 = 0;
        int num8 = 0;
        foreach (LineRenderer duplicatedLine2 in m_duplicatedLineList)
        {
            Vector3[] array2 = new Vector3[duplicatedLine2.positionCount];
            duplicatedLine2.GetPositions(array2);
            for (int j = 0; j < array2.Length; j++)
            {
                Vector3 vector2 = array2[j];
                vector2.x -= num;
                vector2.x *= num6;
                vector2.x = Mathf.Floor(vector2.x);
                vector2.y -= num2;
                vector2.y *= num6;
                vector2.y = Mathf.Floor(vector2.y);
                int num9 = 127 - (int)vector2.y;
                vector2.y += 2 * num9;
                array2[j] = vector2;
            }
            List<Vector2> list2 = new List<Vector2>();
            for (int k = 0; k < array2.Length; k++)
            {
                list2.Add(array2[k]);
            }
            IList<Vector2> list3 = DouglasPeucker.DouglasPeuckerReduction(list2, num5);
            List<Vector3> list4 = new List<Vector3>();
            foreach (Vector2 item2 in list3)
            {
                Vector2 current4 = item2;
                list4.Add(new Vector3(current4.x, current4.y, 0f));
                list.Add((double)current4.x / 255.0);
                list.Add((double)current4.y / 255.0);
                list.Add(0.0);
                num7 += 3;
                num8++;
            }
            list[num7 - 1] = 1.0;
            duplicatedLine2.positionCount = list4.Count;
            duplicatedLine2.SetPositions(list4.ToArray());
        }
        for (int l = 0; l < num8 - 1; l++)
        {
            list[l * 3] = list[(l + 1) * 3] - list[l * 3];
            list[l * 3 + 1] = list[(l + 1) * 3 + 1] - list[l * 3 + 1];
            list[l * 3 + 2] = list[(l + 1) * 3 + 2];
        }
        double[] inferData = list.ToArray();
        string str = "[";
        bool flag = false;
        foreach (LineRenderer duplicatedLine3 in m_duplicatedLineList)
        {
            ImageDataStroke imageDataStroke = new ImageDataStroke();
            Vector3[] array3 = new Vector3[duplicatedLine3.positionCount];
            duplicatedLine3.GetPositions(array3);
            if (flag)
            {
                str += ",";
            }
            flag = true;
            str += "[";
            for (int m = 0; m < array3.Length; m++)
            {
                Vector3 vector3 = array3[m];
                imageDataStroke.x.Add((int)vector3.x);
                imageDataStroke.y.Add((int)vector3.y);
            }
            string input = JsonUtility.ToJson(imageDataStroke);
            string str2 = Regex.Replace(input, "[{}a-zA-Z:?\"]", string.Empty);
            str += str2;
            str += "]";
           
        }
        str = (m_opuput = str + "]");
        Debug.Log(str);
        //TensorModel.Infer(inferData, 5);
       /* string sttr = "";
        foreach(double d in inferData)
        {
            sttr += d.ToString() +"|";
        }
        Debug.Log(sttr);*/

       
        foreach (LineRenderer duplicatedLine4 in m_duplicatedLineList)
        {
            Destroy(duplicatedLine4.gameObject);
        }
        m_duplicatedLineList.Clear();
    }
}
