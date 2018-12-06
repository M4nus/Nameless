using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] SpriteRenderer _observedColor;

    public void Start()
    {
        _observedColor = GetComponent<SpriteRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        _observedColor.color = new Color(255f, 0f, 0f);
        Debug.Log("ObservedColor = " + _observedColor.color.r);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        _observedColor.color = new Color(0f, 0f, 0f);
        Debug.Log("ObservedColor = " + _observedColor.color.r);
    }
}
