using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityManager
{

    public enum Trigger_Status
    {
        CLEAR,
        CAUTION,
        TRIGGER
    }

    public enum Entity_Status
    {
        ENABLED,
        DISABLED,
        BROKEN
    }

    public Trigger_Status TriggerStatus { get; private set; }
    public Entity_Status EntityStatus { get; private set; }

}
