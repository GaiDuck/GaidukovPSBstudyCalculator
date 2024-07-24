using GaidukovPSBstudyCalculator;

AddictionalFunctions add = new AddictionalFunctions();
Calculating calc = new Calculating();
InputData input = new InputData();

add.Greeting();

input.GetFirstNumber();
input.GetMathOperator();
input.GetSecondNumber();

switch (input.MathOperator)
{
    case '+':
        calc.CalculateAddiction(input.FirstNumber, input.SecondNumber);
        add.WaitForFButtonPush();
        break;

    case '-':
        calc.CalculateSubtraction(input.FirstNumber, input.SecondNumber);
        add.WaitForFButtonPush();
        break;

    case '*':
        calc.CalculateMultiplication(input.FirstNumber, input.SecondNumber);
        add.WaitForFButtonPush();
        break;

    case '/':
        calc.CalculateDivision(input.FirstNumber, input.SecondNumber);
        add.WaitForFButtonPush();
        break;

    case '^':
        calc.CalculatePower(input.FirstNumber, input.SecondNumber);
        add.WaitForFButtonPush();
        break;

    default:
        add.EnterIncorrectData();
        add.WaitForFButtonPush();
        break;
}