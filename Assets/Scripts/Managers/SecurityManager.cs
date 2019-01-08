using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#region States

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

public enum Door_Type
{
    NORMAL,
    ELECTRONICAL,
    METAL
}

public enum Door_State
{
    OPENED,
    CLOSED,
    BLOCKED,
    ENCRYPTED
}

#endregion       


#region Cameras

[System.Serializable]
public class SecurityCameraParam
{
    public int id;
    public GameObject camera;
    public Entity_Status entityStatus;
    public Trigger_Status triggerStatus;

    public SecurityCameraParam(int newID, GameObject currentCamera, Entity_Status entity, Trigger_Status trigger)
    {
        id = newID;
        camera = currentCamera;
        entityStatus = entity;
        triggerStatus = trigger;
    }
}

#endregion   

#region Doors

[System.Serializable]
public class DoorParam
{
    public int id;
    public GameObject door;
    public Door_Type doorType;
    public Door_State doorState;

    public DoorParam(int newID, GameObject doorObj, Door_Type currentDoorType, Door_State currentDoorState)
    {
        id = newID;
        door = doorObj;
        doorType = currentDoorType;
        doorState = currentDoorState;
    }
}

#endregion


public class SecurityManager : MonoBehaviour
{                                                  
    public List<SecurityCameraParam> securityCameras = new List<SecurityCameraParam>();
    public List<DoorParam> doors = new List<DoorParam>();
}
