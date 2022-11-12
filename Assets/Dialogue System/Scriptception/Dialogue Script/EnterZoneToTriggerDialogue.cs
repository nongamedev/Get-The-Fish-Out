using UnityEngine;

public class EnterZoneToTriggerDialogue : TriggerDialogue
{
    private bool dialogueTriggered;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == PlayerData.name && !dialogueTriggered)
        {
            StartDialogue();
            dialogueTriggered = true;
        }
    }

    
}
