#include <iostream>
#include <conio.h>
#include <iomanip>

int main() {

    int num1, num2;

    std::cout << "Number 1 << ";
    std::cin >> num1;
    std::cout << "Number 2 << ";
    std::cin >> num2;

    std::cout << '\n' << num1 << " + " << num2 << " = " << num1 + num2
        << '\n' << num1 << " - " << num2 << " = " << num1 - num2
        << '\n' << num1 << " * " << num2 << " = " << num1 * num2
        << '\n' << num1 << " / " << num2 << " = " << std::fixed << std::setprecision(2) << num1 / (float)(num2)
        << "\n\nPress any key to exit...\n";

    _getch();
    
    return 0;
}