using System;
using UnityEngine;
using System.Collections;

public class ArduinoInputTestCube : MonoBehaviour
{
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private float y;
    [SerializeField] private int[] inputList;
    [SerializeField] private int inputListIndex;

    private float lastTime, deltaTime;

    // Start is called before the first frame update
    void Start()
    {
        ArduinoInput.GetSingleInput += GetInput;

        inputList = new int[10];
    }


    public void GetInput(int input) {
        
        deltaTime = Time.realtimeSinceStartup - lastTime;
        lastTime = Time.realtimeSinceStartup;

        print(deltaTime);

        input = Mathf.Min(input, 60);
            input -= 15;


        inputListIndex++;
        if (inputListIndex == inputList.Length -1)
            inputListIndex = 0;
        inputList[inputListIndex] = input;

        float y = 0;

        foreach (int i in inputList)
            y += i;
        y /= (float)inputList.Length;

        rigid.AddForce(new Vector3(y*deltaTime*100,0,0));
        print(y);
    }

}
