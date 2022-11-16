﻿int result = Fibonacci(5);
Console.WriteLine(result);

static int Fibonacci(int number){
    int n1 = 0;
    int n2 = 1;
    int sum;

    for(int i = 2; i <= number; i++){
        sum = n1 + n2;
        n1 = n2;
        n2 = sum;
    }
    return number == 0 ? n1 : n2;
}