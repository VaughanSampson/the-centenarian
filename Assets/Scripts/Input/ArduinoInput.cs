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
	public static event Action Pause;
	private int lastPauseValue;


	private static bool isDisabled = false;
	public static bool IsDisabled { get => isDisabled; }

	/// <summary>
    /// Intiate connection.
    /// </summary>
	void Start()
	{
		if (instance != null && instance != this) Destroy(this.gameObject);
		instance = this;

		try
		{
			serialPort = new SerialPort("COM3", 9600);
			serialPort.Open();
			serialPort.ReadTimeout = 1;
			Cursor.visible = false;
		}
		catch
		{
			try
			{
				serialPort = new SerialPort("/dev/cu.usbmodem1101", 9600);
				serialPort.Open();
				serialPort.ReadTimeout = 1;
				Cursor.visible = false;
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
        	serialPort.Open();

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
				case 'P':
						int pValue = int.Parse(serialReading.Substring(1));
						if(lastPauseValue == 1 && pValue == 0)
							Pause?.Invoke();
						lastPauseValue = pValue;
					break;
				}
			}

		}
		catch 
		{
		}
	}
	
}
