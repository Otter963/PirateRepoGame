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

    public void Interact()
    {
        Debug.Log("Interacted with " + interactScript.npcName);
    }

    public string GetInteractText()
    {
        return interactScript.talkToText;
    }
}
