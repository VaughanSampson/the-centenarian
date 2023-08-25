using System;
using UnityEngine;

public class ArduinoInputTestCube : MonoBehaviour
{
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private float y;
    [SerializeField] private int[] inputList;
    [SerializeField] private int inputListIndex;

    // Start is called before the first frame update
    void Start()
    {
        ArduinoInput.GetSingleInput += GetInput;

        inputList = new int[10];
    }


    public void GetInput(int input) {
        if (input > 60)
            return;
        input -= 30;


        inputListIndex++;
        if (inputListIndex == inputList.Length -1)
            inputListIndex = 0;
        inputList[inputListIndex] = input;

        float y = 0;

        foreach (int i in inputList)
            y += i;
        y /= (float)inputList.Length;

        rigid.AddForce(new Vector3(0,y/100f,0));
        transform.position = new Vector3(0, Mathf.Clamp(transform.position.y, -5, 5), 0 );

    }

}
