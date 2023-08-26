using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorldChunk : MonoBehaviour
{
    [SerializeField] public GameObject genObject;

    public void InitLoad(float size, float radius, int rejectionSamples , float density)
    {
        Vector2 regionSize = new Vector2(size, size);
        radius /= density;
        List<Vector2> points = PoissonDiscSampling.GeneratePoints(radius, regionSize, rejectionSamples);
        points = PerlinNoiseFiltering.FilterPoints(points, transform.position, size, size / 10, 10);

        if (points != null)
        {
            foreach (Vector2 point in points)
            {
                GameObject o = Instantiate(genObject, transform);
                o.transform.position = (Vector3)point + transform.position;
            }
        }
    }
}
