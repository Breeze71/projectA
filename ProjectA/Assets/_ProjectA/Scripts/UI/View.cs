
using UnityEngine;

public abstract class View : MonoBehaviour
{
    public abstract void Initialize();
    public virtual void Hide()
    {
        this.gameObject.SetActive(false);
    }
    public virtual void Show()
    {
        this.gameObject.SetActive(true);
    }
}
