using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lengthX, lengthY, startposX, startposY;
    public GameObject cam;
    public float parralaxEffect;

    void Start() {
        startposX = transform.position.x;
        startposY = transform.position.y;
        lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
        lengthY = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void LateUpdate() {
        float tempX = (cam.transform.position.x * (1 - parralaxEffect));
        float tempY = (cam.transform.position.y * (1 - parralaxEffect));

        float distX = (cam.transform.position.x * parralaxEffect);
        float distY = (cam.transform.position.y * parralaxEffect);

        transform.position = new Vector3(startposX + distX, startposY + distY, transform.position.z);
        
        if (tempX > startposX + lengthX) startposX += lengthX;
        else if (tempX < startposX - lengthX) startposX -= lengthX;

        if (tempY > startposY + lengthY) startposY += lengthY;
        else if (tempY < startposY - lengthY) startposY -= lengthY;
    }
}
