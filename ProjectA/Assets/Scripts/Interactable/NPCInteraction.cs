using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : InteractableBase
{    
    [SerializeField] private Conversation conversation;
    [SerializeField] private GameObject Dialogue;

    private bool IsOpenDialogueUI = false;

    private DialogDisplayController dialogDisplayController;

    public override void Start() 
    {
        base.Start();

        dialogDisplayController = Dialogue.GetComponent<DialogDisplayController>();
    }
    public override void Interact()
    {
        if(!IsOpenDialogueUI)
        {
            dialogDisplayController.canTalk = true;
            dialogDisplayController.conversation = conversation;
            dialogDisplayController.UpdateAvatar();
            dialogDisplayController.StartTalk();
            
            IsOpenDialogueUI = true;
        }
        else
        {
            dialogDisplayController.StartTalk();
        }
    }
}
