using UnityEngine;
using TMPro;

/*References:
Title: How to Talk to NPCs! (or Interact with any Object, Open Doors, Push Buttons, Unity Tutorial)
Author: Code Monkey
Date: 2022, October 12
Code version: 6000.0.51f1
Availability: https://www.youtube.com/watch?v=LdoImzaY6M4
*/

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject playerInteractUIObject;
    [SerializeField] private PlayerInteractScript playerInteractScript;
    [SerializeField] private TextMeshProUGUI interactTextTMP;

    private void Update()
    {
        if (playerInteractScript.GetInteractableObject() != null)
        {
            Show(playerInteractScript.GetInteractableObject());
        }
        else
        {
            Hide();
        }
    }

    private void Show(NPCInteractableScript npcInteractable)
    {
        playerInteractUIObject.SetActive(true);
        interactTextTMP.text = npcInteractable.GetInteractText();
    }

    private void Hide()
    {
        playerInteractUIObject.SetActive(false);
    }
}
