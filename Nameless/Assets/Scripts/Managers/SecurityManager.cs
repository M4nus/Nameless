using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

public class SecurityManager : MonoBehaviour
{                                                  
    public List<SecurityCameraParam> securityCameras = new List<SecurityCameraParam>();     
}
