using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System;

public class DialogDisplayController : MonoBehaviour
{
    public Conversation conversation;
    private int LineIndex = 0;
    public bool canTalk = false;

    [Header("Speaker")]
    public GameObject LeftSpeaker;
    public GameObject RightSpeaker;
    private SpeakerUI speakerUILeft;
    private SpeakerUI speakerUIRight;

    [Header("Sound")]
    [SerializeField] private AudioClip sound;

    public void StartTalk() 
    {
        if(canTalk)
        {
            ConversationContinue(conversation);
            UpdateAvatar();
        }    
    }

    public void UpdateAvatar()
    {
        speakerUILeft = LeftSpeaker.GetComponent<SpeakerUI>();  
        speakerUIRight = RightSpeaker.GetComponent<SpeakerUI>();

        speakerUILeft.Speaker = conversation.speakerLeft;
        speakerUIRight.Speaker = conversation.speakerRight;
    }

    public void ConversationContinue(Conversation conversation)
    {
        if(LineIndex < conversation.lines.Length)
        {
            DisplayLine(conversation);
            LineIndex += 1;
        }
        else
        {
            CloseDialogue();
        }
    }

    public void CloseDialogue()
    {
        speakerUILeft.Hide();
        speakerUIRight.Hide();
        LineIndex = 0;

        StopAllCoroutines();
    }

    private void DisplayLine(Conversation conversation)
    {
        Line line = conversation.lines[LineIndex];
        Character NowCharacter = line.character;

        if(speakerUILeft.SpeakerIs(NowCharacter))
        {
            SetDialog(speakerUILeft, speakerUIRight, line.text);
        }
        else
        {
            SetDialog(speakerUIRight, speakerUILeft, line.text);
        }
    }

    private void SetDialog(SpeakerUI activeSpUi, SpeakerUI inactiveSpUi, string text)
    {
        activeSpUi.Show();
        inactiveSpUi.Hide();

        activeSpUi.Dialog = ""; // 清空
        StopCoroutine(TypeWritter(text, activeSpUi));
        StartCoroutine(TypeWritter(text, activeSpUi));
    }

    // TypeWritter Effect
    private IEnumerator TypeWritter(string text, SpeakerUI speakerUI)
    {
        foreach(char word in text.ToCharArray())
        {
            speakerUI.Dialog += word;
            //SoundManager.Instance.PlaySound(sound, transform.position);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
