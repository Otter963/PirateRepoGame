using UnityEngine;

public class BasicGameWinScript : MonoBehaviour
{
    [SerializeField] private FPSControllerScript playerController;

    [SerializeField] private GameObject gameWinUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has won");
            playerController.enabled = false;
            gameWinUI.SetActive(true);
        }
    }
}
