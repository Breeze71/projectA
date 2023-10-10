using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Interaction : InteractableBase
{
    [SerializeField] private TextAsset inkJson;
    [SerializeField] private Animator emoteAnim;

    public override void Interact()
    {
        // 正在對話時不要重複對話
        if(DialogueManager.Instance.IsDialoguePlaying)  return;

        if(InputManager.Instance.IsInteractKeyDown())
        {
            DialogueManager.Instance.StartDialogue(inkJson, emoteAnim);
        }
    }

    public override void ExitTrigger()
    {
        DialogueManager.Instance.CloseDialogue();   // 跑出範圍
    }
}
