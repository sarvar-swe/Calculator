namespace Calculator
{
    public class Calculator
    {
        // This string field stores the value that's currently displayed by the calculator. 
        // It's constructed as the user clicks numeric keys and the decimal and +/- key.
        private string displayString = "";

        // These Boolean fields control numeric entry. 
        // isNewValue indicates whether the calculator is ready to receive a new numeric value. Once 
        // the user clicks a digit button, isNewValue is set to false. When the user clicks a button 
        // that "enters" the value, such as Add or Equals, isNewValue is set to true so the user can 
        // enter another value.
        // hasDecimal is used to restrict the entry to a single decimal point. It's set to true 
        // whenever newValue is set to true, and it's set to false whenever the user clicks the 
        // decimal point key.
        private bool isNewValue;
        private bool hasDecimal;

        // These private fields are used to do the actual calculation with the values 
        // entered by the user
        private decimal operand1;
        private decimal operand2;
        private Operation op;
        private enum Operation { Add, Subtract, Multiply, Divide, SquareRoot, Reciprocal, None };

        public Calculator() => Clear();

        public void Clear()
        {
            displayString = "";
            hasDecimal = false;
            isNewValue = true;

            operand1 = 0;
            operand2 = 0;
            op = Operation.None;
        }

        public string DisplayString =>
            string.IsNullOrEmpty(displayString) ? "0" : displayString;

        // private helper property. Uses the public property DisplayString rather than the 
        // private field displayString bc the DisplayString property returns "0" if null
        private decimal displayValue => Convert.ToDecimal(DisplayString);

        public void Append(string value)
        {
            if (isNewValue)
            {
                displayString = "";
                hasDecimal = false;
                isNewValue = false;
            }

            // don't append "0" to a display string of "0" - prevents values like "00000"
            displayString += (displayString == "0" && value == "0") ? "" : value;
        }

        public void RemoveLast()
        {
            if (!isNewValue)
            {
                int newLength = displayString.Length - 1;
                displayString = displayString.Substring(0, newLength);

                // set isNewValue to true if display string is now empty
                if (string.IsNullOrEmpty(displayString))
                    isNewValue = true;

                // set hasDecimal to false if display string now has no decimal
                if (!displayString.Contains('.'))
                    hasDecimal = false;
            }
        }

        public void ToggleSign() =>
            displayString = (-displayValue).ToString();


        public void AddDecimalPoint()
        {
            if (!hasDecimal)
            {
                if (isNewValue)
                {
                    displayString = "";
                    hasDecimal = false;
                    isNewValue = false;
                    Append("0.");  // include a leading zero
                }
                else
                {
                    Append(".");
                }
                hasDecimal = true;
            }
        }

        public void Add() => SetValuesForOperation(Operation.Add);

        public void Subtract() => SetValuesForOperation(Operation.Subtract);

        public void Multiply() => SetValuesForOperation(Operation.Multiply);

        public void Divide() => SetValuesForOperation(Operation.Divide);

        public void Equals()
        {
            operand2 = displayValue;

            decimal calculatedValue = op switch
            {
                Operation.Add => operand1 + operand2,
                Operation.Subtract => operand1 - operand2,
                Operation.Multiply => operand1 * operand2,
                Operation.Divide => operand1 / operand2,
                _ => operand2
            };
            displayString = calculatedValue.ToString();

            op = Operation.None;
            hasDecimal = false;
            isNewValue = true;
        }

        public void SquareRoot() => SetValuesForOperation(Operation.SquareRoot);

        public void Reciprocal() => SetValuesForOperation(Operation.Reciprocal);

        // private helper method
        private void SetValuesForOperation(Operation newOp)
        {
            op = newOp;
            operand1 = displayValue;

            decimal calculatedValue = op switch
            {
                Operation.SquareRoot => (decimal)Math.Sqrt(Convert.ToDouble(operand1)),
                Operation.Reciprocal => 1 / operand1,
                _ => operand1
            };
            displayString = calculatedValue.ToString();

            hasDecimal = false;
            isNewValue = true;
        }
    }
}