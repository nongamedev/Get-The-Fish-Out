using UnityEngine;

public class PressToTriggerDialogue : TriggerDialogue
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    private bool playerInRange = false;
    
    private void Update() 
    {
        if (playerInRange && !DialogueManager.Instance.DialogueIsPlaying) 
        {
            visualCue.SetActive(true);
            if (InputManager.Instance.GetInteractPressed())
            {
                StartDialogue();
            }
        }
        else 
        {
            visualCue.SetActive(false);
        }
    }
    

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.name == PlayerData.name)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) 
    {
        if (collider.name == PlayerData.name)
        {
            playerInRange = false;
        }
    }
}
