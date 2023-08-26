const int trigPin1 = 8; // Trigger Pin of Ultrasonic Sensor
const int echoPin1 = 9; // Echo Pin of Ultrasonic Sensor
const int buttonPin = 10;  // Push button pin number
//const int ledPin = LED_BUILTIN;    // the number of the LED pin for testing purpose
const int potPin = A0; //Potentiometer pin number

long duration1;
int distance1;

int buttonState = 0;  // variable for reading the pushbutton status

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600); // Starting Serial Terminal
  pinMode(trigPin1, OUTPUT);
  pinMode(echoPin1, INPUT);
  pinMode(buttonPin, INPUT_PULLUP);
}

void loop() {
  // put your main code here, to run repeatedly: 

  // read the state of the pushbutton and potentiometer value:
  buttonState = digitalRead(buttonPin);
  int val = analogRead(potPin);

  digitalWrite(trigPin1, LOW);
  delayMicroseconds(5);
  digitalWrite(trigPin1, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin1, LOW);

  duration1 = pulseIn(echoPin1, HIGH);

  distance1 = duration1 * 0.034 / 2;

  //Serial.print(distance1);
  //Serial.print(",");
  //Serial.print(buttonState);
  //Serial.print(",");
  //Serial.println(val);

  Serial.println("");
  Serial.write(distance1);
  Serial.print(",");
  Serial.write(buttonState);
  Serial.print(",");
  Serial.write(val);
  //Serial.print("Distance: ");
  //Serial.println(distance1);
  //Serial.print("Button Status: ");
  //Serial.println(buttonState);
  //Serial.print("Potentiometer value: ");
  //Serial.println(val);
  //Serial.write(1);
}