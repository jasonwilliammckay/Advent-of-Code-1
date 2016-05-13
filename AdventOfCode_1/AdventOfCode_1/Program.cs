using System;
using System.IO;

// Per parts 1 and 2 of http://adventofcode.com/day/1

namespace AdventOfCode_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The target floor is {0}.", determineFloor(Constants.INPUT_FILE));

            if (BasementTracker.basementHasBeenFound())
                Console.WriteLine("The first basement was found on instruction {0}.", BasementTracker.getBasementPosition());
            else
                Console.WriteLine("Santa never finds a basement");

            Console.ReadKey();
        }

        public static int determineFloor(String fileName)
            // walks through each item in an input file to determine if santa should walk up or down a floor
            // eventually returns the sum of all the ups and downs, a negative value reflecting a basement sublevel
        {
            FileStream file = null;
            int direction = 0;
            int floor = 0;
            BasementTracker.reset();

            try
            {
                file = new FileStream(fileName, FileMode.Open);
                direction = file.ReadByte();

                while (direction != Constants.EOF)
                {
                    if (direction == Constants.UP_FLOOR)
                        floor++;

                    else if (direction == Constants.DOWN_FLOOR)
                        floor--;

                    if (BasementTracker.basementHasBeenFound() == false) // part #2 of the advent question
                        checkForBasement(floor);                         // if we haven't found the basement yet, check if we have now

                    direction = file.ReadByte();
                }
            }

            catch (IOException errorMsg)
            {
                Console.WriteLine(errorMsg.Message);
            }

            catch (Exception errorMsg)
            {
                Console.WriteLine(errorMsg.Message);
            }

            finally
            {
                file.Close();
            }

            return floor;
        }

        private static void checkForBasement(int floor)
            // keeps the basement tracker object up-to-date about the floor being inspected and its state
        {
            BasementTracker.incBasementPosition();

            if (floor < 0)
                BasementTracker.foundBasement();
        }
    }
}