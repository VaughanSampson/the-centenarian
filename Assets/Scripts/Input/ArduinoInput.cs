using UnityEngine;
using System;
using UnityEngine.Events;
using System.IO.Ports;

public class ArduinoInput : MonoBehaviour
{
	SerialPort serialPort = new SerialPort("COM3", 9600);

	public static event Action<bool> SendTrigger;
	public static event Action<int> SendDial;
	public static event Action<int> SendUltrasound;

	public bool disabled;

	/// <summary>
    /// Intiate connection.
    /// </summary>
	void Start()
	{

		try
		{
			serialPort.Open();
			serialPort.ReadTimeout = 1;
		}
		catch
		{
			disabled = true;
		}
	}

	/// <summary>
    /// Get input.
    /// </summary>
	void Update()
	{
		if (disabled) return;

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
