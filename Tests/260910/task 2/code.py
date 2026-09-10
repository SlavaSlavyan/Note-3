num1: int = int(input("Number 1 << "))
num2: int = int(input("Number 2 << "))

print(f'''
{num1} + {num2} = {num1 + num2}
{num1} + {num2} = {num1 - num2}
{num1} * {num2} = {num1 * num2}
{num1} / {num2} = {round(num1 / num2,2)}

Press ENTER to exit...
''')

input()