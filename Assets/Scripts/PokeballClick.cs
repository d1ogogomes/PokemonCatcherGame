using UnityEngine;

public class PokeballClick : MonoBehaviour
{
    public float interactionDistance = 0.5f; 
    public Transform player;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    if (Vector3.Distance(player.position, transform.position) <= interactionDistance)
                    {
                       
                        gameObject.SetActive(false);

                        
                        GameManager.instance.OnPokeballCollected();
                    }
                }
            }
        }
    }
}
