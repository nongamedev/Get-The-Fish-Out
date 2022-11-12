using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] protected TextAsset inkJSON;

    protected virtual void StartDialogue()
    {
        DialogueManager.Instance.EnterDialogueMode(inkJSON);
    }
}
