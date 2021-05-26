using System;
using System.Collections.Generic;

namespace GroupByExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> allPeople = new List<Person>();
            Random rng = new Random();
            for (int i = 0; i < 1000000; i++)
            {
                allPeople.Add(new Person(rng.Next(), (City)rng.Next(81)));
            }

            var groupedPeopleByCity = GroupByCity(allPeople);

            foreach (City homeCity in groupedPeopleByCity.Keys)
            {
                Console.WriteLine(homeCity + " contains " + groupedPeopleByCity[homeCity].Count + " people.");
            }

        }

        private static Dictionary<City, List<Person>> GroupByCity(List<Person> allPeople)
        {
            List<City> cityList = new List<City>();
            List<Person> personList = new List<Person>();

            Dictionary<City, List<Person>> toReturn = new Dictionary<City, List<Person>>();

            foreach (City city in Enum.GetValues(typeof(City)))
            {
                cityList.Add(city);
            }

            for (int i = 0; i < cityList.Count; i++)
            {
                foreach (Person person in allPeople)
                {
                    if (toReturn.ContainsKey(cityList[i]) && cityList[i] == person.HomeCity)
                    {
                        personList.Add(person);
                    }
                }
                toReturn.Add(cityList[i], personList);
            }

            return toReturn;
        }
    }
}
