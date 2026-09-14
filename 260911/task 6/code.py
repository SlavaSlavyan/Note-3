import sys

a: float = float(input("A << "))
b: float = float(input("B << "))
c: float = float(input("C << "))

if a == 0:
    input("\nError! Not an quadratic function.\n\nPress ENTER to exit...")
    sys.exit()

D: float = b * b - 4 * a * c
print(f"\nDiscriminant >> {round(D,3)}")

if D > 0:
    print("Two roots!")
    
elif D < 0:
    print("Zero roots!")
    
else:
    print("One root!")
    
input("\nPress ENTER to exit...\n")