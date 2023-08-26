using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorldChunk : MonoBehaviour
{
    [SerializeField] public ChunkGenObject[] genObjects;

    public void InitLoad(float size, float radius, int rejectionSamples , float density)
    {
        int overallWieght = 0;
        foreach (ChunkGenObject g in genObjects)
            overallWieght += g.weight;

        Vector2 regionSize = new Vector2(size, size);
        radius /= density;
        List<Vector2> points = PoissonDiscSampling.GeneratePoints(radius, regionSize, rejectionSamples);
        points = PerlinNoiseFiltering.FilterPoints(points, transform.position, size, size / 10, 10);

        if (points != null)
        {
            foreach (Vector2 point in points)
            {
                int objectId = Random.Range(0, overallWieght);
                GameObject genObject = genObjects[genObjects.Length-1].genObject;

                foreach (ChunkGenObject g in genObjects)
                {
                    overallWieght -= g.weight;
                    if (overallWieght <= 0)
                    {
                        genObject = g.genObject;
                        break;
                    }
                }

                GameObject o = Instantiate(genObject, transform);
                o.transform.position = (Vector3)point + transform.position;
            }
        }
    }
}


[System.Serializable]
public class ChunkGenObject{
    [SerializeField] public int weight;
    [SerializeField] public GameObject genObject;
}