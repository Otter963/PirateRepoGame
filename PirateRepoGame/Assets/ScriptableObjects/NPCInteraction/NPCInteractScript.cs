using UnityEngine;

/*References:
Title: How to Talk to NPCs! (or Interact with any Object, Open Doors, Push Buttons, Unity Tutorial)
Author: Code Monkey
Date: 2022, October 12
Code version: 6000.0.51f1
Availability: https://www.youtube.com/watch?v=LdoImzaY6M4
*/

[CreateAssetMenu(fileName = "NPCDialogueManager", menuName = "ScriptableObjects/NPCDialogue")]
public class NPCInteractScript : ScriptableObject
{
    public string npcName;
    public string talkToText;
    public string dialogueText;
}
