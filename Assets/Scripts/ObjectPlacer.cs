using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    public GameObject pokeballPrefab;
    public Terrain terrain;
    public float bufferDistance = 1f;

    public void Start()
    {
        PlaceObjectsOnTerrain();
    }

    public void PlaceObjectsOnTerrain()
    {
        float terrainWidth = terrain.terrainData.size.x;
        float terrainLength = terrain.terrainData.size.z;
        int numPokeballs = GameManager.instance.currentLevel; 

        for (int i = 0; i < numPokeballs; i++)
        {
            float randomX = Random.Range(bufferDistance, terrainWidth - bufferDistance);
            float randomZ = Random.Range(bufferDistance, terrainLength - bufferDistance);
            Vector3 position = new Vector3(randomX, 0, randomZ);

            float terrainHeight = terrain.SampleHeight(position);
            position.y = terrainHeight;

            Instantiate(pokeballPrefab, position, Quaternion.identity);
        }
    }
}
