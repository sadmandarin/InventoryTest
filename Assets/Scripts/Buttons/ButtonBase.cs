using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class ButtonBase : MonoBehaviour
{
    private Button _button;

    protected virtual void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    protected abstract void OnClick();
}
