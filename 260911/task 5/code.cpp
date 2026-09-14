#include <iostream>
#include <conio.h>

int main() {

    int num1, num2, operation;

    std::cout << "Number 1 << ";
    std::cin >> num1;
    std::cout << "Number 2 << ";
    std::cin >> num2;

    std::cout << "\nChose operation:\n  1. Sum\n  2. Difference\n  3. Multiplication\n  4. Division\n\n> ";
    std::cin >> operation;

    std::cout << "\nResult >> ";

    switch (operation) {
    case 1:
        std::cout << num1 << " + " << num2 << " = " << num1 + num2;
        break;

    case 2:
        std::cout << num1 << " - " << num2 << " = " << num1 - num2;
        break;
    
    case 3:
        std::cout << num1 << " * " << num2 << " = " << num1 * num2;
        break;

    case 4:
        if (num2) {
            std::cout << num1 << " / " << num2 << " = " << num1 / (float)num2;
        } else {
            std::cout << "Error! Division by zero.";
        }

        break;
    
    default:
        std::cout << "Unknown operation \"" << operation << '\"';
        break;
    }

    std::cout << "\n\nPress any key to exit...\n";

    _getch();

    return 0;
}