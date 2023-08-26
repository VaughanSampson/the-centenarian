using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorldChunk : MonoBehaviour
{
    [SerializeField] public GameObject genObject;

    public const int size = 10;

    public float radius = 10;
    public Vector2 regionSize = new Vector2(size, size);
    public int rejectionSamples = 30;

    private void Start()
    {
        Load(4);
    }

    public void Load(int density)
    {
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
