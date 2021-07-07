using System;
using System.Collections.Generic;
using System.IO;

namespace Problem79
{
    class Program
    {

        //A common security method used for online banking is to ask the user for three random characters from a passcode.For example,
        //if the passcode was 531278, they may ask for the 2nd, 3rd, and 5th characters; the expected reply would be: 317.

        //The text file, keylog.txt, contains fifty successful login attempts.

        //Given that the three characters are always asked for in order, analyse the file so as to determine the shortest possible
        //secret passcode of unknown length.
        static void Main(string[] args)
        {

            List<string> digits = new List<string>();

            string line = "";

            List<string> loginAttempts = new List<string>();

            using(StreamReader reader = new StreamReader("../../../keylog.txt"))
            {
                while((line = reader.ReadLine()) != null)
                {
                    if(!loginAttempts.Contains(line))
                        loginAttempts.Add(line);
                }
            }

            foreach(string i in loginAttempts)
            {
                for(int j = 0; j < i.Length; j++)
                {
                    string num = i.Substring(j, 1);
                    if (!digits.Contains(num))
                        digits.Add(num);
                }
            }

            digits.Sort();

            
            

        }

        // 36792180
        // 36721980
        // 36712980
        // 36791280
        // 36719280
        // 36729180
        
        public static string LastBefore0(List<string> list)
        {
            foreach(string line in list)
            {
                if(line.Contains("0"))
                {
                    string potential = line.Substring(1, 1);
                    foreach(string check in list)
                    {
                        if(check.Contains(potential))
                        {
                            if (check.Substring(2) != "0")
                            {
                                if (check.Substring(1, 1) != potential)
                                    break;
                            }
                        }
                    }

                    return potential;

                }
            }

            return null;
        }

        public static string FirstAfter7(List<string> list)
        {
            //the idea is to find the numbers that occur after 7 which is the first one
            //then see if theres any numbers that appear before this number
            //if no numbers appear before this number except 7 then its after 7
            foreach (string line in list)
            {
                if (line.Contains("7"))
                {
                    string potential = line.Substring(1, 1);
                    foreach (string linecheck in list)
                    {
                        if (linecheck.Contains(potential))
                        {
                            if (linecheck.Substring(0, 1) != "7")
                            {
                                if (linecheck.Substring(0, 1) != potential)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    return potential;
                }
            }
            return "nada";

        }

        public static string FindFirst(List<string> list)
        {
            string potential = list[0].Substring(0, 1);
            bool isFirst = false;
            while (!isFirst)
            {
                isFirst = true;
                foreach (string line in list)
                {
                    if (!(potential == line.Substring(0, 1)) && line.Contains(potential))
                    {
                        isFirst = false;
                        potential = line.Substring(0, 1);
                        break;
                    }
                }
            }
            return potential;
        }

        static string FindLast(List<string> list)
        {
            string toReturn = list[0].Substring(2);
            bool isLast = false;

            while(!isLast)
            {
                isLast = true;
                foreach (string line in list)
                {
                    if(!(toReturn == line.Substring(2)) && line.Contains(toReturn))
                    {
                        isLast = false;
                        toReturn = line.Substring(2);
                        break;
                    }
                }
            }
            return toReturn;
        }

    }
}
