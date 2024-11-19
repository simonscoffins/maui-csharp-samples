﻿namespace Calculator;


public static class Calculator {

    public static double Calculate(double value1, double value2, string mathOperator) {
        double result = 0;

        switch(mathOperator) {
            case "÷":
                result = value1 / value2;
                break;
            case "×":
                result = value1 * value2;
                break;
            case "+":
                result = value1 + value2;
                break;
            case "-":
                result = value1 - value2;
                break;
            default:
                break;
        }

        return result;
    }
}
