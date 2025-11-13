using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class StopCinemachineTimeline : MonoBehaviour
{
    [SerializeField] private float dollyTime = 8f;
    [SerializeField] private float playerViewTime = 3f;
    [SerializeField] private float switchPlayerControlTime = 3f;

    [SerializeField] private PauseMenuScript pauseMenuScript;
    [SerializeField] private GameObject playerControlsTutorial;

    [SerializeField] private FPSControllerScript playerControls;
    [SerializeField] private GameManager shootScript;

    [SerializeField] private GameObject dollyCamera;
    [SerializeField] private GameObject dollySpline;
    [SerializeField] private GameObject playerViewCam;
    [SerializeField] private GameObject mainTimeline;

    [SerializeField] private BasicGameWinScript gameWinScript;

    private void Awake()
    {
        playerControls.enabled = false;
        shootScript.enabled = false;
    }

    private void Update()
    {
        if (!pauseMenuScript.isPaused)
        {
            StartCoroutine(FinishCinemachineTimeline());
        }
        else if (gameWinScript.finishGame == true)
        {
            StopCoroutine(FinishCinemachineTimeline());
        }
    }

    public IEnumerator FinishCinemachineTimeline()
    {

            yield return new WaitForSeconds(dollyTime);
            dollyCamera.SetActive(false);
            dollySpline.SetActive(false);
            yield return new WaitForSeconds(playerViewTime);
            playerViewCam.SetActive(false);
            yield return new WaitForSeconds(switchPlayerControlTime);
            mainTimeline.SetActive(false);
            playerControls.enabled = true;
            shootScript.enabled = true;

    }
}
