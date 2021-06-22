using System;
using System.Linq;
using CourseManager.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CourseManager.Repos
{
    public class DBCourseRepo : DbRepo, ICourseRepo
    {
        public Course ConvertTableRow(DataRow row)
        {
            Course toReturn = new Course();

            var setId = row.Field<int>("Id");
            var setName = row.Field<string>("Name");

            toReturn.Name = setName;
            toReturn.Id = setId;

            return toReturn;

        }

        public Course GetById(int id)
        {
            Course toReturn = null;
            DataSet set = ExecuteQuery("SELECT Id, Name FROM Courses WHERE Id =" + id);
            var table = set.Tables[0];
            if (table.Rows.Count == 1)
            {
                toReturn = new Course();
                var setId = int.Parse(table.Rows[0]["Id"].ToString());
                var name = table.Rows[0].Field<string>("Name");
                toReturn.Id = setId;
                toReturn.Name = name;
                // TODO need list of courses
            }

            return toReturn;
        }

        public int AddCourse(Course toAdd)
        {
            DataSet set = new DataSet();

            if (toAdd == null)
                throw new NoNullAllowedException("Course can not be null");
            else
            {
                set = ExecuteQuery($"INSERT INTO Courses (Name) OUTPUT INSERTED.Id VALUES ({toAdd.Name})");
            }

            return int.Parse(set.Tables[0].Rows[0]["Id"].ToString());
        }

        public void Edit(Course updated)
        {
            DataSet set = new DataSet();

            if (updated == null)
                throw new NoNullAllowedException("Course can not be null");
            else
            {
                set = ExecuteQuery($"UPDATE Courses SET Name = {updated.Name} WHERE Id = {updated.Id}");
            }
        }

        public void Delete(int id)
        {
            DataSet set = ExecuteQuery($"DELETE FROM StudentsCourses WHERE CourseId = {id}");
            set = ExecuteQuery($"DELETE FROM Courses WHERE Id = {id}");
        }

        public List<Course> GetAll()
        {
            List<Course> courses = new List<Course>();

            DataSet set = ExecuteQuery("SELECT Id, Name FROM Courses");

            foreach(DataRow row in set.Tables[0].Rows)
            {
                courses.Add(ConvertTableRow(row));
            }

            return courses;
        }
    }
}
