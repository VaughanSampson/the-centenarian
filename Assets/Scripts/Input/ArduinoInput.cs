using UnityEngine;
using System;
using UnityEngine.Events;
using System.IO.Ports;

public class ArduinoInput : MonoBehaviour
{
	private static ArduinoInput instance;
	SerialPort serialPort;

	public static event Action<bool> SendTrigger;
	public static event Action<int> SendDial;
	public static event Action<int> SendUltrasound;

	private static bool isDisabled = false;
	public static bool IsDisabled { get => isDisabled; }

	/// <summary>
    /// Intiate connection.
    /// </summary>
	void Start()
	{
		if (instance != null && instance != this) return;
		instance = this;

		try
		{
			serialPort = new SerialPort("COM3", 9600);
			serialPort.Open();
			serialPort.ReadTimeout = 1;
		}
		catch
		{
			try
			{
				serialPort = new SerialPort("/dev/cu.usbmodem1101", 9600);
				serialPort.Open();
				serialPort.ReadTimeout = 1;
			}
			catch
			{
				print("failed");
				isDisabled = true;
			}
		}
	}

	/// <summary>
    /// Get input.
    /// </summary>
	void Update()
	{
		if (isDisabled) return;

		if (!serialPort.IsOpen)
        	serialPort.Open ();

		try
		{
			while(true){
			string serialReading = serialPort.ReadLine(); 
			
			switch (serialReading[0]){
				case 'D':
					SendUltrasound?.Invoke(int.Parse(serialReading.Substring(1)));
					break;
				case 'B':
					SendTrigger?.Invoke(!Convert.ToBoolean(int.Parse(serialReading.Substring(1))));
					break;
				case 'G':
					SendDial?.Invoke(int.Parse(serialReading.Substring(1)));
					break;
			}
			}

			//SendUltrasound?.Invoke(int.Parse(inputs[0]));
			//SendTrigger?.Invoke(!Convert.ToBoolean(int.Parse(inputs[1])));
			//SendDial?.Invoke(int.Parse(inputs[2]));
		}
		catch 
		{
		}
	}
	
}
