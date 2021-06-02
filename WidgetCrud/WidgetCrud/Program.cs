using System;
using System.Collections.Generic;

namespace WidgetCrud
{
    class Program
    {
        static InMemWidgetDao dao = new InMemWidgetDao();

        static void Main(string[] args)
        {

            bool done = false;

            while( !done)
            {
                int choice = PrintMainMenu();
                switch (choice)
                {
                    case 1:
                        AddWidget(new Widget {Id = 9, Name = "goat cheese", Category = "food", Price = 5m });
                        break;
                    case 2:
                        RemoveWidgetById(3);
                        break;
                    case 3:
                        EditWidget(new Widget { Id = 9, Name = "edited goat cheese", Category = "food", Price = 5m });
                        break;
                    case 4:
                        GetWidgetById(5);
                        break;
                    case 5:
                        GetWidgetsByCat("food");
                        break;
                    case 6:
                        GetWidgetsByPage(2, 3);
                        break;
                    case 7:
                        done = true;
                        break;

                }
            }
        }

        private static void RemoveWidgetById(int id)
        {
            dao.RemoveWidgetById(id);
        }

        private static IEnumerable<Widget> GetWidgetsByCat(string category)
        {
            return dao.GetWidgetsByCategory(category);
        }

        private static void AddWidget(Widget toAdd)
        {
            dao.AddWidget(toAdd);
        }

        private static void EditWidget(Widget updated)
        {
            dao.UpdateWidget(updated);
        }

        private static int PrintMainMenu()
        {
            throw new NotImplementedException();
        }

        private static Widget GetWidgetById(int id)
        {
            return dao.GetWidgetById(id);
        }

        private static IEnumerable<Widget> GetWidgetsByPage(int pageSize, int pageNumber)
        {
            return dao.GetAllWidgetsForPage(pageSize, pageNumber);
        }

    }
}
