num1: int = int(input("Number 1 << "))
num2: int = int(input("Number 2 << "))

operation: str = input("\nChose operation:\n  1. Sum\n  2. Difference\n  3. Multiplication\n  4. Division\n\n> ")

print("\nResult >> ",end='')

if operation == "1":
    print(f"{num1} + {num2} = {num1 + num2}")
elif operation == "2":
    print(f"{num1} - {num2} = {num1 - num2}")
elif operation == "3":
    print(f"{num1} * {num2} = {num1 * num2}")
    
elif operation == "4":
    if num2 == 0:
        print("Error! Division by zero.")
    else:  
        print(f"{num1} / {num2} = {num1 / num2}")
    
else:
    print(f'Unknown operation "{operation}".')
    
input("\nPress ENTER to exit\n")