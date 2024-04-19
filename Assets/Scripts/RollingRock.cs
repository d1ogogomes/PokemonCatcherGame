using UnityEngine;

public class MoveRock : MonoBehaviour
{
    public float speed = 1.0f; 
    public float movementRadius = 2.0f; 

    private Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        //posicao baseada num movimento circular
        float time = Time.time;
        float xOffset = Mathf.Sin(time * speed) * movementRadius;
        float zOffset = Mathf.Cos(time * speed) * movementRadius;

      
        Vector3 newPosition = startingPosition + new Vector3(xOffset, 0f, zOffset);
        newPosition.y = Terrain.activeTerrain.SampleHeight(newPosition) + 0.1f; // Adjust 0.1f to position slightly above terrain

        transform.position = newPosition;
    }

      private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.GameOver("Player collided with the rolling rock!");
        }
    }

}