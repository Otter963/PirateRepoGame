using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*References:
Title: How to Talk to NPCs! (or Interact with any Object, Open Doors, Push Buttons, Unity Tutorial)
Author: Code Monkey
Date: 2022, October 12
Code version: 6000.0.51f1
Availability: https://www.youtube.com/watch?v=LdoImzaY6M4
*/

public class PlayerInteractScript : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerControls;

    private InputAction interactAction;

    private void Awake()
    {
        interactAction = playerControls.FindActionMap("Player").FindAction("Interact");
    }

    private void Update()
    {
        if (interactAction.WasPressedThisFrame())
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                //found NPC
                if (collider.TryGetComponent(out NPCInteractableScript npcInteractable))
                {
                    npcInteractable.Interact();
                }
            }
        }
    }

    public NPCInteractableScript GetInteractableObject()
    {
        List<NPCInteractableScript> npcInteractableList = new List<NPCInteractableScript>();
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            //found NPC
            if (collider.TryGetComponent(out NPCInteractableScript npcInteractable))
            {
                npcInteractableList.Add(npcInteractable);
            }
        }

        NPCInteractableScript closestNPCInteractable = null;
        foreach (NPCInteractableScript npcInteractable in npcInteractableList)
        {
            if (closestNPCInteractable == null)
            {
                closestNPCInteractable = npcInteractable;
            }
            else
            {
                if (Vector3.Distance(transform.position, npcInteractable.transform.position) < 
                    Vector3.Distance(transform.position, closestNPCInteractable.transform.position))
                {
                    closestNPCInteractable = npcInteractable;
                }
            }
        }

        return closestNPCInteractable;
    }
}
