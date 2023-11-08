using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Interaction : InteractableBase
{
    [SerializeField] private TextAsset inkJson;
    [SerializeField] private GameObject icon;
    
    protected override void Interact()
    {
        if(DialogueManager.Instance.IsDialoguePlaying)  return;

        DialogueManager.Instance.StartDialogue(inkJson);
    }

    protected override void EnterTrigger()
    {
        base.EnterTrigger();

        icon.SetActive(true);
    }
    protected override void ExitTrigger()
    {
        base.ExitTrigger();

        icon.SetActive(false);
        DialogueManager.Instance.CloseDialogue();   // 跑出範圍
    }

}
