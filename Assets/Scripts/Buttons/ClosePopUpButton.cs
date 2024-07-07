using UnityEngine;

public class ClosePopUpButton : ButtonBase
{
    private SetPopUpWindow _window;

    protected override void Start()
    {
        base.Start();

        _window = GetComponentInParent<SetPopUpWindow>();
    }

    protected override void OnClick()
    {
        Destroy(_window.gameObject);
    }
}
