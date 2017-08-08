using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ScreenWrap : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Bounds camBounds;
    private float camWidth;
    private float camHeight;

    void Awake ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void UpdateCameraBounds()
    {
        Camera cam = Camera.main;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
        camBounds = new Bounds(cam.transform.position, new Vector2(camWidth, camHeight));
    }

    void LateUpdate()
    {
        UpdateCameraBounds();
        //shorten position and size in shorter variable names
        Vector3 pos = transform.position;
        Vector3 size = spriteRenderer.bounds.size;
        //calculate sprites half witdh and half height
        float halfWidth = size.x / 2;
        float halfHeight = size.y / 2;
        float halfCamWidth = camWidth / 2;
        float halfCamHeight = camHeight / 2;
        // check left
        if(pos.x + halfWidth < camBounds.min.x)
        {
            pos.x = camBounds.max.x + halfWidth;
        }
        //check right
        if (pos.x - halfWidth > camBounds.max.x)
        {
            pos.x = camBounds.min.x - halfWidth;
        }
        //check to
        if (pos.y - halfHeight > camBounds.max.y)
        {
            pos.y = camBounds.min.y - halfHeight;
        }
        //check bot
        if (pos.y + halfHeight < camBounds.min.y)
        {
            pos.y = camBounds.max.y + halfHeight;
        }
        //move enemy back around
        transform.position = pos;
    } 
}
