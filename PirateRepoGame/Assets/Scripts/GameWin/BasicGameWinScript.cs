using UnityEngine;

public class BasicGameWinScript : MonoBehaviour
{
    [SerializeField] private FPSControllerScript playerController;

    [SerializeField] private GameObject gameWinUI;

    [SerializeField] private GameObject playerUI;

    [SerializeField] private StopCinemachineTimeline stopCinemachineTimeline;

    public bool finishGame = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has won");
            SoundManager.PlaySound(SoundType.GAMEWIN, 1f);
            playerController.enabled = false;
            playerUI.SetActive(false);
            gameWinUI.SetActive(true);
            finishGame = true;
            Time.timeScale = 0f;
        }
    }
}
