const int trigPin1 = 8; // Trigger Pin of Ultrasonic Sensor
const int echoPin1 = 9; // Echo Pin of Ultrasonic Sensor

long duration1;
int distance1;

void setup() {
  // put your setup code here, to run once:
  pinMode(trigPin1, OUTPUT);
  pinMode(echoPin1, INPUT);
  Serial.begin(9600); // Starting Serial Terminal
}

void loop() {
  // put your main code here, to run repeatedly:  
  digitalWrite(trigPin1, LOW);
  delayMicroseconds(5);
  digitalWrite(trigPin1, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin1, LOW);

  duration1 = pulseIn(echoPin1, HIGH);

  distance1 = duration1 * 0.034 / 2;

  Serial.println(distance1);
  
}