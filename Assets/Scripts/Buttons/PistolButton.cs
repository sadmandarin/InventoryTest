using UnityEngine;

public class PistolButton : ButtonBase
{

    protected override void Start()
    {
        base.Start();
    }

    protected override void OnClick()
    {
        Debug.LogFormat("it's pistol button");
    }
}
