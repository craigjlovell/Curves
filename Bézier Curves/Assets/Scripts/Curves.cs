using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curves : MonoBehaviour
{
    public List<Bez> curves;
    public Transform p;

    // Start is called before the first frame update
    void Start()
    {
        curves[0].p = p;
        curves[1].points[0].position = curves[0].points[3].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (p.position == curves[0].points[3].position && Input.GetKey(KeyCode.RightArrow))
        {
            curves[0].p = null;
            curves[1].p = p;
        }
        if (p.position == curves[1].points[0].position && Input.GetKey(KeyCode.LeftArrow))
        {
            curves[1].p = null;
            curves[0].p = p;
        }
    }
}
