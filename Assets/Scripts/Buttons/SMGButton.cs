using UnityEngine;

public class SMGButton : ButtonBase
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void OnClick()
    {
        Debug.Log("This button is SMG");
    }
}
