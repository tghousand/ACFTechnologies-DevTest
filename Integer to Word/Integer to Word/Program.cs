/***
 * Tyler Housand
 * Programmed for ACF Technologies .NET Developer test. 
 * The method ConvertToWords is used to convert integers between -9999 and 9999 into their
 * word forms. For example: 12 into "Twelve", 45 into "Forty Five", 634 into "Six Hundred and Thirty Four",
 * and -1987 into "Minus One Thousand, Nine Hundred and Eighty Seven"
 ***/

namespace Integer_to_Word
{
	class Program
	{

		//Here is a quick main method that I used in testing the ConvertToWords method.
		public static void Main(string[] args)
		{
			int value;

			Console.WriteLine("Please input a number between -9999 and 9999");

			while (!int.TryParse(Console.ReadLine(), out value) || (value < -10000) || (value > 10000))
			{
				Console.WriteLine("Invalid input.");
				Console.WriteLine("Please input a number between -9999 and 9999");
			}

			Console.WriteLine(ConvertToWords(value));

		}


		//This method takes an integer and converts it to words. 
		public static String ConvertToWords(int number)
		{
			//If the number is 0, we can return just 'Zero'.
			if(number == 0)
			{
				return "Zero";
			}
			
			//Here, we check if the number is a negative value. If so, we need to call the method again to handle the absolute value of our number.
			//Adding "Minus " to the convertedWords string below will cause issue with checking if the string is empty. 
			if(number < 0)
			{
				return "Minus " + ConvertToWords(Math.Abs(number));
			}

			//This string will contain our number converted into words
			string convertedWords = "";

			//These two arrays are responsible for holding string values that correspond to their position in the array ([0] = "Zero", [13] = "Thirteen")
			//This will allow for the number we are converting to be used to reference the string that it needs to be converted to.
			String[] digits = {"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
			"Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
			String[] tensDigits = { "", "", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

			//Since the parameters are from -9999 to 9999, we have to check if the value is divisible by 1000. If so, we convert it to a word and take the remainder and continue.
			if((number / 1000) > 0)
			{
				convertedWords += digits[number / 1000] + " Thousand";
				number = number % 1000;
			}

			//Checking if the number is divisible by 100. If so, we check if the string is empty. If it isn't, we add the comma and space. Then we convert it to the word, get the remainder, and continue down.
			if((number / 100) > 0)
			{
				if(convertedWords != "") { convertedWords += ", "; }
				convertedWords += digits[number / 100] + " Hundred";
				number = number % 100;
			}

			//First we need to check if the number is over 0. This is because we don't say 'Five hundred and zero,' just 'Five hundred.'
			if(number > 0)
			{
				//Checking again if the string is empty, and if it isn't, we add appropriate spacing and the word 'and' to our string.
				if(convertedWords != "")
				{
					convertedWords += " and ";
				}
				//If the number is less than 20, we can use a value from the digits array. If not, we need to use the tensDigits array first and use the digits array with any remainders.
				if(number < 20)
				{
					convertedWords += digits[number];
				} else
				{
					convertedWords += tensDigits[number / 10];
					if((number % 10) > 0) 
					{
						convertedWords += " " + digits[number % 10]; 
					}
				}
			}

			return convertedWords;
		}

	}
}