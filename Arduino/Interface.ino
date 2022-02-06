String ReadFromPC()
{
    String read;
    while(Serial.available() > 0)
    {
      delay(5);
      if(Serial.available() > 0)
      {
          char c = Serial.read();
          if(isControl(c))
            break;
          read += c;
      }

    }
    return read;
}
void WriteToPC(String s)
{
    Serial.println(s);
}
