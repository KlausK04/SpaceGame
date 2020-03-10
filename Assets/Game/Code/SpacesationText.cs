using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacesationText : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera activeCam;
    public float sizeOfText = 20;

    void Start()
    {
        InvokeRepeating("ScaleText", 1.0f, 3f);
    }

    public void ScaleText()
    {
        Vector3 textScreenSpace = activeCam.WorldToScreenPoint(transform.position);
        Vector3 adjustedScreenSpace = new Vector3(textScreenSpace.x + sizeOfText, textScreenSpace.y, textScreenSpace.z);
        Vector3 adjustedWorldSpace = activeCam.ScreenToWorldPoint(adjustedScreenSpace);
        transform.localScale = Vector3.one * (transform.position - adjustedWorldSpace).magnitude;
        transform.rotation = activeCam.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
           
        
    }


}
