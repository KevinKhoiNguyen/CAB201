using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_CAB201 {
    /// <summary>
    /// 
    /// Menu driven program which requires user input to 
    /// calcuate and return their waist to height ratio.
    /// 
    /// Furthermore, the degree of lifestyle risk will be
    /// assessed and an appropriate warning given and a choice
    /// to calculate another ratio.
    /// 
    /// Author Kevin Nguyen N9463933 March 2017
    /// </summary>

    class WaistToHeightCalc {

        const double MINIMUM_WAIST = 60;
        const double MINIMUM_HEIGHT = 120;
        const int MALE_CHOICE = 1;
        const int FEMALE_CHOICE = 2;
        const int EXIT_PROGRAM = 0;
        const int RESTART_PROGRAM = 1;
        
        static void Main(string[] args) {

            double userWaistOutput;
            double userHeightOutput;
            int genderOutput;
            int programStatus;
            double calculatedRatio;

            // Start the Program with the title and welcoming statement
            WelcomingStatement();

            // Continue calculation of ratios when the user specifies
            do {
                userWaistOutput = ReadUserWaist();
                userHeightOutput = ReadUserHeight();
                GenderChoiceDisplay();
                genderOutput = ReadUserGender();
                calculatedRatio = CalculateWaistToHeightRatio(userWaistOutput, userHeightOutput);
                DisplayRatio(calculatedRatio, genderOutput);
                programStatus = AdditionalCalculation();
            } while (programStatus != EXIT_PROGRAM);

            Exit();

        }// end Main

        //--------------------------------------------------------------------------------

        /* Welcoming statement to introduce user to the purpose of the program */
        static void WelcomingStatement() {
            Console.WriteLine("\t\tWelcome to the Waist to Height Ratio Calculator\n");
        }// end WelcomingStatement


        /* A graceful way to exit the program which will be executed when the user
        no longer wants additional calculations*/
        static void Exit() {
            Console.Write("\nPress any key to exit...");
            Console.ReadKey();
        }// end Exit


        //--------------------------------------------------------------------------------

        /* Ask the user for the waist measurement, convert it to a double and ensure it is 
        greater than 60cm */
        static double ReadUserWaist() {

            // Declare our parameters
            string waistInput;
            double userWaist;
            bool okayWaist;

            // Ask and Check User input of waist
            do {
                Console.Write("\nWhat is your waist measurement in cm?: ");
                waistInput = Console.ReadLine();
                okayWaist = double.TryParse(waistInput, out userWaist);
                if (!okayWaist || userWaist < MINIMUM_WAIST) {
                    Console.WriteLine("\nPlease enter a valid waist measurement at least 60cm");
                }// end if      
            } while (!okayWaist || userWaist < MINIMUM_WAIST);

            return userWaist;
        } // end ReadUserWaist


        /* Similarly get height, convert to double, confirm greater than 120cm */
        static double ReadUserHeight() {

            string heightInput;
            double userHeight;
            bool okayHeight;

            // Ask and check User input of height
            do {
                Console.Write("\nWhat is your height measurement in cm?: ");
                heightInput = Console.ReadLine();
                okayHeight = double.TryParse(heightInput, out userHeight);
                if (!okayHeight || userHeight < MINIMUM_HEIGHT) {
                    Console.WriteLine("\nPlease enter a valid height measurement at least 120cm");
                }// end if
            } while (!okayHeight || userHeight < MINIMUM_HEIGHT);

            return userHeight;
        }// end ReadUserHeight

        //------------------------------------------------------------------------------------------

        /* Menu option for gender selection which will display a message prompting the user 
           to enter their gender in 1 for male 2 for female */
        static void GenderChoiceDisplay() {
            string display = "\nWhat is your gender?"
                           + "\n\t\t1) Male"
                           + "\n\t\t2) Female"
                           + "\n\t\tEnter your gender <1 or 2>: ";
            Console.Write(display);
        }// end GenderChoiceDisplay 


        /* Get the gender of User*/
        static int ReadUserGender() {

            string genderInput;
            int userGender;
            bool okayGender;

            // Ask and check User choice of gender 1 is male, 2 is female
            do {
                genderInput = Console.ReadLine();
                okayGender = int.TryParse(genderInput, out userGender);
                if (!okayGender || (userGender != MALE_CHOICE && userGender != FEMALE_CHOICE)) {
                    Console.WriteLine("\nPlease try again and enter 1 or 2 for your suited gender");
                    // Bring back choices 
                    GenderChoiceDisplay();
                }// end if   
            } while (!okayGender || (userGender != MALE_CHOICE && userGender != FEMALE_CHOICE));

            return userGender;
        }// end ReadUSerGender

        //------------------------------------------------------------------------------------------

        /*Calculation of the waist to height ratio*/
        static double CalculateWaistToHeightRatio(double userWaist, double userHeight) {

            double waistToHeightRatio;

            waistToHeightRatio = userWaist / userHeight;
            return waistToHeightRatio;

        }// end CalculateWaistToHeightRatio


        /*Display waist to height ratio and write health message*/
        static void DisplayRatio(double waistToHeightRatio, int userGender) {

            const double MALE__RISK_RATIO = 0.536;
            const double FEMALE_RISK_RATIO = 0.492;
            string GOOD_HEALTH = "Congratulations, you are at a low risk of developing "
                         + "obesity related cardiovascular diseases.";
            string BAD_HEALTH = "Unfortunately, you are at a high risk of developing "
                                    + "obesity related cardiovascular diseases.";

            // Write the calculated ratio
            Console.WriteLine("\nYour waist to height ratio is {0:F4}",
                               waistToHeightRatio);

            // Determine the risk of disease related to males
            if (userGender == MALE_CHOICE) {
                if (waistToHeightRatio < MALE__RISK_RATIO) {
                    Console.WriteLine("\n" + GOOD_HEALTH);
                } else {
                    Console.WriteLine("\n" + BAD_HEALTH);
                }// end nested if else
            }// end outer if

            // Determine the risk of disease related to females
            if (userGender == FEMALE_CHOICE) {
                if (waistToHeightRatio < FEMALE_RISK_RATIO) {
                    Console.WriteLine("\n" + GOOD_HEALTH);
                } else {
                    Console.WriteLine("\n" + BAD_HEALTH);
                }// end nested if else
            }//end outer if

        }//end DisplayRatio

        //-----------------------------------------------------------------------------------------

        /*Determines if user wants additional calculation*/
        static int AdditionalCalculation() {

            string choice;
            string calculationEnquiry = "\nWould you like another calculation? "
                                      + "<Enter Y or N>: ";
            string YES1 = "Y";
            string YES2 = "y";

            // Ask user if they want to perform another calculation
            Console.Write(calculationEnquiry);
            choice = Console.ReadLine();
            if (choice == YES1 || choice == YES2) {
                return RESTART_PROGRAM;
            } else {
                return EXIT_PROGRAM;
            }//end if else

        }//end AdditionalCalculation

        //-----------------------------------------------------------------------------------------

    }//end class
}//end namespace

