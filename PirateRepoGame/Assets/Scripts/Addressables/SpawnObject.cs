using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private Transform prefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Instantiate(prefab);
        }
    }
}
