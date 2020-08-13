using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColor : MonoBehaviour
{
    public Color color;
    MeshRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        Material mat = rend.material;
        mat.color = color;
        rend.material = mat;
    }
}
