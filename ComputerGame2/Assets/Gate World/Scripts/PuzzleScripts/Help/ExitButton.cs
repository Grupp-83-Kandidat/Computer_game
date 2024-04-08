using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : Buttons
{
    public override void DoSomething()
    {
        Destroy(transform.parent.gameObject);
    }
}
