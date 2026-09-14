#include <iostream>
#include <conio.h>

int main() {

    int num1, num2, num3;
    float result;

    std::cout << "Number 1 << "; 
    std::cin >> num1;
    std::cout << "Number 2 << "; 
    std::cin >> num2;
    std::cout << "Number 3 << "; 
    std::cin >> num3;

    result = (num1 + num2 + num3) / 3.0;

    std::cout << "\n\n Arithmetic mean " << (int)result << " [" << result << "]\n\nPress any key to exit...\n";

    _getch();

    return 0;
}