using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Tristan DeMaria, CSCI-1630, 9/18/21
 * Create an application to calcualte and rate a user's BMI and exercise
 * Percentages using the Karvonen formula. Calcualtions for BMI and 
 * the Karvonen formula can be looked up or found in the prompt on Blackboard.
 * The Application must receive four pieces of data from the user:
 * height in inches, weight in pounds, age, and resting heart rate.
 * Run the height and weight data through a calculation and then determine
 * BMI category using an if loop, then display total BMI and the category.
 * The BMI should appear with two decimal places. Use age and resting heart
 * rate data to calculate heart rates at various intensities, then display them
 * in a list. All numerals in this list will have no decimal values.
*/

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            const double intometers = 0.0254; //use for height conversion
            const double lbtokg = 0.45359237; //use for weight conversion
            string heightString, weightString, ageString, restString, bmiRating;
            double height, weight, age, rest, bmi, intensity;

            WriteLine("Tristan's BMI and Karvonen Calculcator");
            WriteLine("");
            WriteLine("Please enter the following values for the user . . .");
            WriteLine("");

            Write("Height in inches: "); //get height
            heightString = ReadLine();
            height = Convert.ToDouble(heightString);

            Write("Weight in pounds: "); //get weight
            weightString = ReadLine();
            weight = Convert.ToDouble(weightString);

            Write("Age: "); //get age
            ageString = ReadLine();
            age = Convert.ToDouble(ageString);

            Write("Resting heart rate: "); //get resting heart rate
            restString = ReadLine();
            rest = Convert.ToDouble(restString);

            double heightMetersSq = Math.Pow((height * intometers),2); //convert height to meters squared
            double weightKG = weight * lbtokg; //convert weight to kg
            bmi = Math.Round((weightKG / heightMetersSq), 2); //calculate bmi, restrict to two decimal places

            WriteLine("");
            WriteLine("Your results are . . .");
            WriteLine("");
            //determine BMI classification, assign to variable, and display result
            if (bmi <= 18.5) {
                WriteLine($"Your BMI is: {bmi} -- Underweight");
            }
            else if (bmi < 25) {
                WriteLine($"Your BMI is: {bmi} -- Normal Weight");
            }
            else if (bmi < 30) {
                WriteLine($"Your BMI is: {bmi} -- Overweight");
            }
            else {
                WriteLine($"Your BMI is: {bmi} -- Obese");
            }
            
            WriteLine("");
            WriteLine("Exercise Intesnity Heart Rates:");
            WriteLine("Intensity\tMax Heart Rate");
            for (intensity = 50; intensity < 100; intensity = intensity + 5)
            {
                double maxHR = Convert.ToInt16(((((220 - age) - rest) * (intensity / 100)) + rest));
                WriteLine($"{intensity}%\t--\t{maxHR}");
            }
            ReadLine();
        }
    }
}
