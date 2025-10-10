using UnityEngine;
using TMPro;

/*References:
Title: How to Talk to NPCs! (or Interact with any Object, Open Doors, Push Buttons, Unity Tutorial)
Author: Code Monkey
Date: 2022, October 12
Code version: 6000.0.51f1
Availability: https://www.youtube.com/watch?v=LdoImzaY6M4
*/

public class NPCInteractableScript : MonoBehaviour
{
    [SerializeField] private NPCInteractScript interactScript;

    [SerializeField] private TextMeshProUGUI dialogueTextTMP;

    [SerializeField] private GameObject tutorialCollider;

    [SerializeField] private GameObject tutorialTriggerCollider;

    public void Interact()
    {
        SoundManager.PlaySound(SoundType.TUTORIALCONTINUE, 1f);
        tutorialCollider.SetActive(false);
        tutorialTriggerCollider.SetActive(false);
    }

    public string GetInteractText()
    {
        return interactScript.talkToText;
    }
}
