c: float = float(input("Temperature in Celsius << "))

print(f"\nFahrenheit >> {round(c * 9 / 5 + 32)}" +
      f"\nKelvin >> {round(c + 273.15)}\n\nPress ENTER to exit...\n")

input()