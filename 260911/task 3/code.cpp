#include <iostream>
#include <conio.h>
#include <iomanip>

int main() {

    float c;

    std::cout << "Temperature in Celsius << ";
    std::cin >> c;

    std::cout << "\nFahrenheit >> " << std::fixed << std::setprecision(2) << c * 9 / 5 + 32
        << "\nKelvin >> " << std::fixed << std::setprecision(2) << c + 273.15
        << "\n\nPress any key to exit...\n";

    _getch();

    return 0;
}