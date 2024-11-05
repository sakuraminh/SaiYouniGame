using TMPro;
using UnityEngine;

public abstract class TextAbstact : MMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textPro;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextPro();
    }

    protected virtual void LoadTextPro()
    {
        if (this.textPro != null) return;
        this.textPro = GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadTextPro", gameObject);
    }
}
