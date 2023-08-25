using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SpeakerUI : MonoBehaviour
{
    public Image Avatar;
    public TMP_Text Name;
    //public TMP_Text dialog;
    public Text dialog;

    // 更新 ui 
    private Character speaker;
    public Character Speaker
    {
        get
        {
            return speaker;
        }
        set
        {
            speaker = value;
            Avatar.sprite = speaker.Avatar;
            Name.text = speaker.name;
        }
    }

    public string Dialog
    {
        get
        {
            return dialog.text;
        }
        set
        {
            // dialog.text = Dialog
            dialog.text = value;
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public bool HasSpeaker()
    {
        return speaker != null;
    }
    
    public bool SpeakerIs(Character character)
    {
        return speaker == character;
    }
}
