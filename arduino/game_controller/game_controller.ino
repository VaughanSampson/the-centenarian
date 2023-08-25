const int trigPin1 = 8; // Trigger Pin of Ultrasonic Sensor
const int echoPin1 = 9; // Echo Pin of Ultrasonic Sensor

//const int trigPin2 = 10; // Trigger Pin of Ultrasonic Sensor
//const int echoPin2 = 11; // Echo Pin of Ultrasonic Sensor

long duration1, duration2;
int distance1, distance2;

void setup() {
  // put your setup code here, to run once:
  pinMode(trigPin1, OUTPUT);
  pinMode(echoPin1, INPUT);
  //pinMode(trigPin2, OUTPUT);
  //pinMode(echoPin2, INPUT);
  Serial.begin(9600); // Starting Serial Terminal
}

void loop() {
  // put your main code here, to run repeatedly:  
  digitalWrite(trigPin1, LOW);
  //digitalWrite(trigPin2, LOW);
  delayMicroseconds(5);
  digitalWrite(trigPin1, HIGH);
  //digitalWrite(trigPin2, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin1, LOW);
  //digitalWrite(trigPin2, LOW);

  duration1 = pulseIn(echoPin1, HIGH);
  //duration2 = pulseIn(echoPin2, HIGH);

  distance1 = duration1 * 0.034 / 2;
  //distance2 = duration2 * 0.034 / 2;

  //Serial.print("distance1: ");
  Serial.println(distance1);
  //Serial.print("distance2: ");
  //Serial.println(distance2);
  
}