#include <iostream>
#include <conio.h>
#include <iomanip>

int main() {

    int a, b, c;
    float D;

    std::cout << "A << ";
    std::cin >> a;
    std::cout << "B << ";
    std::cin >> b;
    std::cout << "C << ";
    std::cin >> c;
    
    if (!a) {
        std::cout << "Error! Not an quadratic function.\n\nPress any key to exit...\n";
        _getch();
        return 0;
    }

    D = b * b - 4.0 * a * c;
    std::cout << "\nDiscriminant >> " << std::fixed << std::setprecision(3) << D;

    if (D > 0) {
        std::cout << "\nTwo roots!";
    }
    else if (D < 0) {
        std::cout << "\nZero roots!";
    }
    else {
        std::cout << "\nOne root!";
    }

    std::cout << "\n\nPress any key to exit...\n";

    _getch();

    return 0;
}