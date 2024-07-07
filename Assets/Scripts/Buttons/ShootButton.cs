using UnityEngine;

public class ShootButton : ButtonBase
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void OnClick()
    {
        Debug.Log("This button is for shooting");
    }
}
