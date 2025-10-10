using System.Collections;
using UnityEngine;

public class NPCTalkCheck : MonoBehaviour
{
    [SerializeField] private float talkTimer = 10f;

    [SerializeField] private GameObject triggerCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LetSoundPlay());
        }
    }

    IEnumerator LetSoundPlay()
    {
        triggerCollider.SetActive(false);
        SoundManager.PlaySound(SoundType.TUTORIALSKIP, 1f);
        yield return new WaitForSeconds(talkTimer);
    }
}
