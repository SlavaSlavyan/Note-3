name = input("Name << ")
old = input("Years << ")

try:
    old = int(old)
    print(f"Hello, {name}! Your age is {old}.")
except:
    print("Invalid syntaxis!")

input("\nPress ENTER to exit.")