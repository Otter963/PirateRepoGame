using UnityEngine;

[RequireComponent(typeof(Terrain))]
public class TerrainHeightMapGenerator : MonoBehaviour
{
    public int seed = 42;
    public float noiseScale = 20f;
    public int octaves = 4;
    public float persistence = 0.5f;
    public float lacunarity = 2f;
    public float heightMultiplier = 20f;

    public Vector2 offset;

    Terrain terrain;
    TerrainData tData;

    private void Start()
    {
        terrain = GetComponent<Terrain>();
        tData = terrain.terrainData;
        Generate();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Generate();
        }
    }

    public void Generate()
    {
        Random.InitState(seed);
        int w = tData.heightmapResolution;
        int h = tData.heightmapResolution;
        float[,] heights = new float[w, h];

        for (int y = 0; y < h; y++)
        {
            for (int x = 0; x < w; x++)
            {
                float nx = (float)x / (w - 1);
                float ny = (float)y / (h - 1);

                float amplitude = 1f;
                float frequency = 1f;
                float noiseHeight = 0f;

                for (int i = 0; i < octaves; i++) 
                {
                    float sampleX = (nx * noiseScale * frequency) + offset.x;
                    float sampleY = (ny * noiseScale * frequency) + offset.y;
                    float perlin = Mathf.PerlinNoise(sampleX, sampleY) * 2f - 1f;
                    noiseHeight += perlin * amplitude;

                    amplitude *= persistence;
                    frequency *= lacunarity;
                }

                heights[y, x] = Mathf.Clamp01((noiseHeight * 0.5f + 0.5f) * (heightMultiplier / 100f));
            }
            tData.SetHeights(0, 0, heights);
        }
    }
}
