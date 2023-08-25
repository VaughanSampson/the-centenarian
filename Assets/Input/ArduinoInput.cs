using UnityEngine;
using System;
using UnityEngine.Events;
using System.IO.Ports;

public class ArduinoInput : MonoBehaviour
{
	public static ArduinoInput instance;

	SerialPort serialPort = new SerialPort("COM3", 9600);

	public static event Action<int> GetSingleInput;

	/// <summary>
    /// Intiate connection.
    /// </summary>
	void Start()
	{
		if (instance)
			Destroy(gameObject);

		instance = this;

		DontDestroyOnLoad(gameObject);

		serialPort.Open();
		serialPort.ReadTimeout = 1;
	}

	/// <summary>
    /// Get input.
    /// </summary>
	void Update()
	{
		if (!serialPort.IsOpen)
        	serialPort.Open ();

		try
		{
			int input = int.Parse(serialPort.ReadLine());
			GetSingleInput?.Invoke(input);
		}
		catch 
		{
			
		}
	}

}
