using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TextureCoder : MonoBehaviour
{
    public Texture2D texture;

    [System.Serializable]
    public struct ColorValues
    {
        public Color color;
        public int value;
    }

    public List<ColorValues> colors;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [ContextMenu("Create array")]
    public void CreateArray()
    {
        int[] arr = new int[texture.height * texture.width];
        Debug.Log("Texture width " + texture.width + " height " + texture.height);
        for(int x = 0; x < texture.height; x++)
        {
            for (int y = 0; y < texture.width; y++)
            {
                var c = texture.GetPixel(y, x);
                int k = -1;
                for (int j = 0; j < colors.Count; j++)
                {
                    if(NearlyEqual(c, colors[j].color))
                    {
                        k = colors[j].value;
                        break;
                    }
                }
                //if (c.r > 0.5f)
                //    k = 0;
                //else if (c.g > 0.5f)
                //    k = 1;
                //else
                //    k = 2;
                if (k == -1)
                    Debug.Log("COlor " + c.ToString());
                arr[y + x * texture.width] = k;
                
            }
        }
        
        StreamWriter sr = File.CreateText("lul.txt");
        //for(int i = arr.Length - 1; i >= 0; i--)
        //{
        //    sr.Write(arr[i].ToString() + ",");
        //}
        for (int i = 0; i <arr.Length; i++)
        {
            var a = "";
            //if (arr[i] == -1)
            //    a = "NULL";
            //else
                a = arr[i].ToString();
            sr.Write(a + ",");
        }
        sr.Close();
    }
    public float treshold = 0.1f;
    private bool NearlyEqual(Color a, Color b)
    {
        if (InRange(a.r, b.r - treshold, b.r + treshold) && InRange(a.g, b.g - treshold, b.g + treshold) && InRange(a.b, b.b - treshold, b.b + treshold))
            return true;

        return false;
    }

    private bool InRange(float a, float min, float max)
    {
        return a >= min && a <= max;
    }
}
