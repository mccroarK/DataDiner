using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUsable
{
    public bool OnUse(scr_Player user);    // Run on use by player
}