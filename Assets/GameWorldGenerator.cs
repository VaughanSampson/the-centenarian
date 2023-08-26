using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameWorldGenerator : MonoBehaviour
{
    private ShipController playerShip;
    private float loopDelay = 10f;

    public void Init(ShipController playerShip)
    {
        StartCoroutine("GenerationLoop");
        this.playerShip = playerShip;
    }

    IEnumerator GenerationLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(loopDelay);
            Vector2 center = playerShip.transform.position;

        }
    }

    public void UnloadOld(Vector2 center)
    {
        
    }


    public void LoadNew(Vector2 center)
    {

    }

}

public static class PerlinNoiseFiltering{

	public static List<Vector2> FilterPoints(List<Vector2> points, Vector2 basePosition, float areaSize, float edgeFilterWidth, float spread)
    {
		Vector2[] pointsArray = points.ToArray();
		return pointsArray.Where(point => {

			float noisePoint = GetNoisePoint(basePosition + point, spread);
			if (point.x < edgeFilterWidth)
				noisePoint -= 0.1f;
			else
			if (point.x > areaSize - edgeFilterWidth)
				noisePoint -= 0.1f;


			if (point.y < edgeFilterWidth)
				noisePoint -= 0.1f;
			else
			if (point.y > areaSize - edgeFilterWidth)
				noisePoint -= 0.1f;


			if (noisePoint < 0.3f) return false;
			if (noisePoint < + Random.Range(0,0.6f)) return false;
			return true;

		}).ToList();
    }

	private static float GetNoisePoint(Vector2 point, float spread)
    {
		return Mathf.PerlinNoise(point.x / spread, point.y / spread);
    }

}

public static class PoissonDiscSampling
{

	public static List<Vector2> GeneratePoints(float radius, Vector2 sampleRegionSize, int numSamplesBeforeRejection = 30)
	{
		float cellSize = radius / Mathf.Sqrt(2);

		int[,] grid = new int[Mathf.CeilToInt(sampleRegionSize.x / cellSize), Mathf.CeilToInt(sampleRegionSize.y / cellSize)];
		List<Vector2> points = new List<Vector2>();
		List<Vector2> spawnPoints = new List<Vector2>();

		spawnPoints.Add(sampleRegionSize / 2);
		while (spawnPoints.Count > 0)
		{
			int spawnIndex = Random.Range(0, spawnPoints.Count);
			Vector2 spawnCentre = spawnPoints[spawnIndex];
			bool candidateAccepted = false;

			for (int i = 0; i < numSamplesBeforeRejection; i++)
			{
				float angle = Random.value * Mathf.PI * 2;
				Vector2 dir = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
				Vector2 candidate = spawnCentre + dir * Random.Range(radius, 2 * radius);
				if (IsValid(candidate, sampleRegionSize, cellSize, radius, points, grid))
				{
					points.Add(candidate);
					spawnPoints.Add(candidate);
					grid[(int)(candidate.x / cellSize), (int)(candidate.y / cellSize)] = points.Count;
					candidateAccepted = true;
					break;
				}
			}
			if (!candidateAccepted)
			{
				spawnPoints.RemoveAt(spawnIndex);
			}

		}

		return points;
	}

	static bool IsValid(Vector2 candidate, Vector2 sampleRegionSize, float cellSize, float radius, List<Vector2> points, int[,] grid)
	{
		if (candidate.x >= 0 && candidate.x < sampleRegionSize.x && candidate.y >= 0 && candidate.y < sampleRegionSize.y)
		{
			int cellX = (int)(candidate.x / cellSize);
			int cellY = (int)(candidate.y / cellSize);
			int searchStartX = Mathf.Max(0, cellX - 2);
			int searchEndX = Mathf.Min(cellX + 2, grid.GetLength(0) - 1);
			int searchStartY = Mathf.Max(0, cellY - 2);
			int searchEndY = Mathf.Min(cellY + 2, grid.GetLength(1) - 1);

			for (int x = searchStartX; x <= searchEndX; x++)
			{
				for (int y = searchStartY; y <= searchEndY; y++)
				{
					int pointIndex = grid[x, y] - 1;
					if (pointIndex != -1)
					{
						float sqrDst = (candidate - points[pointIndex]).sqrMagnitude;
						if (sqrDst < radius * radius)
						{
							return false;
						}
					}
				}
			}
			return true;
		}
		return false;
	}
}
