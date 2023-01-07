using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;

    List<Vector2> points;


    public void UpdateLine(Vector2 position)
    {
        if (points == null)
        {
            points = new List<Vector2>();
            SetPoints(position);
            return;
        }
        if (Vector2.Distance(points.Last(), position) > .1f)
        {
            SetPoints(position);
        }

    }



    void SetPoints(Vector2 point)
    {
        points.Add(point);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);
    }



    void Start()
    {
        Destroy(gameObject, 2f);
        StartCoroutine(FadeLine());

    }

    IEnumerator FadeLine()
    {
        Color startColor = lineRenderer.startColor;
        Color endColor = lineRenderer.endColor;
        float time = 0f;
        while (time < 2f)
        {
            time += Time.deltaTime;
            lineRenderer.startColor = Color.Lerp(startColor, Color.clear, time / 2f);
            lineRenderer.endColor = Color.Lerp(endColor, Color.clear, time / 2f);
            yield return null;
        }
    }

}
