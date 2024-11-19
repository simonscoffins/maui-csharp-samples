namespace Calculator;

public static class DoubleExtensions {

    public static string ToTrimmedString(this double target, string decimalFormat) {
        string strValue = target.ToString(decimalFormat); //Get the stock string

        //If there is a decimal point present
        if(strValue.Contains(".")) {
            //Remove all trailing zeros
            strValue = strValue.TrimEnd('0');

            //If all we are left with is a decimal point
            if(strValue.EndsWith(".")) //then remove it
                strValue = strValue.TrimEnd('.');
        }

        return strValue;
    }
}
