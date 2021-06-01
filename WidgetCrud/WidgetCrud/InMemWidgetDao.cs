using System;
using System.Collections.Generic;
using System.Linq;

namespace WidgetCrud
{
    public class InMemWidgetDao
    {
        List<Widget> _allWidgets = new List<Widget>()
        {
            new Widget { Id = 1, Name = "bicycle", Category = "transport", Price = 150m },
            new Widget { Id = 2, Name = "concrete", Category = "building supplies", Price = 25m },
            new Widget { Id = 3, Name = "bread", Category = "food", Price = 3m },
            new Widget { Id = 4, Name = "train", Category = "transport", Price = 15000000m },
            new Widget { Id = 5, Name = "eggs", Category = "food", Price = 1.5m },
            new Widget { Id = 6, Name = "lumber", Category = "building supplies", Price = 50m },
            new Widget { Id = 7, Name = "car", Category = "transport", Price = 15000m },
            new Widget { Id = 8, Name = "milk", Category = "food", Price = 4m },
        };

        public InMemWidgetDao()
        {

        }

        public int AddWidget(Widget toAdd)
        {
            _allWidgets.Add(toAdd);

            return toAdd.Id;
        }

        public void RemoveWidgetById(int id)
        {
            Widget toRemove = _allWidgets.Where(w => w.Id == id).Single();

            _allWidgets.Remove(toRemove);
        }

        public void UpdateWidget(Widget updated)
        {
            Widget toUpdate = _allWidgets.Where(n => n.Id == updated.Id).Single();

            toUpdate = updated;
        }

        public Widget GetWidgetById(int id)
        {
            Widget toReturn = _allWidgets.Where(n => n.Id == id).Single();

            return toReturn;
        }

        public IEnumerable<Widget> GetWidgetsByCategory(string category)
        {
            IEnumerable<Widget> toReturn = _allWidgets.Where(w => w.Category == category);

            return toReturn;
        }

        public IEnumerable<Widget> GetAllWidgetsForPage(int pageSize, int pageNumber)
        {
            //assuming each page is pageSize wide, return the pageNumberth page of widgets
            //order by name?

            throw new NotImplementedException();
        }
    }
}
