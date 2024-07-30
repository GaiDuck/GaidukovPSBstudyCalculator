using GaidukovPSBstudyCalculator;

AddictionalFunctions add = new AddictionalFunctions();
Calculating calc = new Calculating();
InputData input = new InputData();

add.Greeting();
Console.WriteLine("1 - пошаговый, 2 - строкой");
switch (Convert.ToByte(Console.ReadLine()))
    {
    case 1:
        input.GetDataV1();  //калькулятор с пошаговым рассчестом
        calc.Calculate(input.MathOperator, input.FirstNumber, input.SecondNumber);
    break;

    case 2:
        input.GetDataV2();  //калькулятор, считающий из строки
        for (int i = 0; i < input.MathOperatorCount; i++)
        {
            input.SetNumbersByMathoperator(0); //0 здесь - хардкод, на самом деле это должен быть номер матоператора
            calc.Calculate(input.MathOperator, input.FirstNumber, input.SecondNumber);
            input.UpdateExpression(calc.TempResult, 0); //здесь тоже
        }
    break;

    default:
        Console.WriteLine("Все очень плохо!");
    break;
}


//Приоритеты выполнения операций:
//Возведение в степень -> Умножение и деление -> Сложение и вычитание
