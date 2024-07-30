using GaidukovPSBstudyCalculator;

AddictionalFunctions add = new AddictionalFunctions();
Calculating calc = new Calculating();
InputData input = new InputData();

//калькулятор с пошаговым рассчестом
add.Greeting();
input.GetDataV1();
calc.Calculate(input.MathOperator, input.FirstNumber, input.SecondNumber);

//Приоритеты выполнения операций:
//Возведение в степень -> Умножение и деление -> Сложение и вычитание
