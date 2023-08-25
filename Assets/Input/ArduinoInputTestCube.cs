
using System;
using UnityEngine;

public class ArduinoInputTestCube : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private float y;
    [SerializeField] private int[] inputList;
    [SerializeField] private int inputListIndex;

    // Start is called before the first frame update
    void Start()
    {
        ArduinoInput.GetSingleInput += GetInput;

        inputList = new int[] {0,0,0,0,0,0,0,0,0,0,0,0};
    }


    public void GetInput(int input) {
        if (input > 60)
            return;

        inputList[inputListIndex] = input;
        inputListIndex++;
        if (inputListIndex == inputList.Length -1)
            inputListIndex = 0;

        float y = 0;

        foreach (int i in inputList)
            y += i;
        y /= (float)inputList.Length;

        transform.position = new Vector3(0, y/10f, 0);
    }

}
