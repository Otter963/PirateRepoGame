using UnityEngine;

[CreateAssetMenu(fileName = "NPCDialogueManager", menuName = "ScriptableObjects/NPCDialogue")]
public class NPCInteractScript : ScriptableObject
{
    public string npcName;
    public string dialogueText;
}
