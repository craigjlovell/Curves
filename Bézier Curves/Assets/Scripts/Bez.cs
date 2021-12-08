using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bez : MonoBehaviour
{

    public List<Transform> points;

    Vector3 z;

    public Transform p;

    [HideInInspector]
    [Range(0f, 1f)]
    public float t = 0f;

    [Range(3, 25)]
    public int steps = 10;

    // Start is called before the first frame update
    void Start()
    {
        p.position = points[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (p != null)
        {
            Vector3 a;
            Vector3 b;
            Vector3 c;
            Vector3 d;
            Vector3 e;
            Vector3 z;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                t = t + Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                t = t - Time.deltaTime;
            }

            t = Mathf.Clamp(t, 0f, 1f);

            // between physical points we can see
            a = Lerp(points[0].position, points[1].position, t);
            b = Lerp(points[1].position, points[2].position, t);
            c = Lerp(points[2].position, points[3].position, t);

            // between math based points we cant see
            d = Lerp(a, b, t);
            e = Lerp(b, c, t);

            // point we see move
            p.transform.position = Lerp(d, e, t);
        }
    }

    Vector3 Lerp (Vector3 a, Vector3 b, float t)
    {
        return a + (b - a) * t;
    }

    private void OnDrawGizmos()
    {
        float step = 1f / steps;

        for (int i = 0; i < steps; i++)
        {
            // between physical points we can see
            Vector3 a1 = Lerp(points[0].position, points[1].position, step * i);
            Vector3 b1 = Lerp(points[1].position, points[2].position, step * i);
            Vector3 c1 = Lerp(points[2].position, points[3].position, step * i);

            // between math based points we cant see
            Vector3 d1 = Lerp(a1, b1, step * i);
            Vector3 e1 = Lerp(b1, c1, step * i);

            Vector3 start = Lerp(d1, e1, step * i);

            // between physical points we can see
            Vector3 a2 = Lerp(points[0].position, points[1].position, step * (i + 1));
            Vector3 b2 = Lerp(points[1].position, points[2].position, step * (i + 1));
            Vector3 c2 = Lerp(points[2].position, points[3].position, step * (i + 1));

            // between math based points we cant see
            Vector3 d2 = Lerp(a2, b2, step * (i + 1));
            Vector3 e2 = Lerp(b2, c2, step * (i + 1));

            Vector3 end = Lerp(d2, e2, step * (i + 1));

            Gizmos.DrawLine(start, end);
            Gizmos.DrawSphere(start, 0.2f);
        }

        Gizmos.DrawLine(points[0].position, points[1].position);
        Gizmos.DrawLine(points[2].position, points[3].position);
    }
}
