#include <iostream>
#include <string>
#include <conio.h>

int main() 
{
    std::string name;
    unsigned char age;

    std::cout << "Name << ";
    std::cin >> name;

    std::cout << "Age << ";
    std::cin >> age;

    std::cout << "Hello, " << name << "! Your age is " << age << ".\n\n Press any key to exit.\n";

    _getch();

    return 0;
}