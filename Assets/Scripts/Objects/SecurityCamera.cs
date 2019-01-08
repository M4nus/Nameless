using System.Collections;
using System.Collections.Generic;
using UnityEngine;
          
public class SecurityCamera : MonoBehaviour
{
    GameObject securityManager;
    SpriteRenderer _observedColor;
    SecurityManager _sm;

    int index;
                        
    public void Awake()
    {                                                      
        securityManager = GameObject.Find("[SECURITY]");
        _sm = securityManager.GetComponent<SecurityManager>();                    
        _observedColor = this.GetComponent<SpriteRenderer>();            
        _sm.securityCameras.Add(new SecurityCameraParam(index = _sm.securityCameras.Count, this.gameObject, Entity_Status.ENABLED, Trigger_Status.CLEAR));
    }
        

    public void Update()
    {                                                        
        if(_sm.securityCameras[index].triggerStatus == Trigger_Status.CLEAR)
        {
            _observedColor.color = new Color(0f, 0f, 0f, 0.5f);
        }
        else if(_sm.securityCameras[index].triggerStatus == Trigger_Status.CAUTION)
        {
            _observedColor.color = new Color(1f, 1f, 0f, 0.5f);
        }
        else if(_sm.securityCameras[index].triggerStatus == Trigger_Status.TRIGGER)
        {
            _observedColor.color = new Color(1f, 0f, 0f, 0.5f);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            _sm.securityCameras[index].triggerStatus = Trigger_Status.CAUTION;
            StartCoroutine(BeingDetected(3f));
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            _sm.securityCameras[index].triggerStatus = Trigger_Status.CLEAR;
            StopAllCoroutines();
        }
    }

    public IEnumerator BeingDetected(float detectTime)
    {
        while(detectTime > 0)
        {
            detectTime -= Time.deltaTime;
            yield return null;
        }
        _sm.securityCameras[index].triggerStatus = Trigger_Status.TRIGGER;
    }
}
