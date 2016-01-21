using System;
using System.Collections.Generic;
using System.Data;

namespace Search_Service
{
    public class Service1 : solarIService1
    {
        List<string> DocInfo = new List<string>();
        DataTable table = new DataTable();

        public List<string> searchCategory(string category)
        {
            table.Columns.Add("Category", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Experience", typeof(int));

            table.Rows.Add("Cardiology", "Rajesh", 5);
            table.Rows.Add("Cardiology", "Nikhil", 7);
            table.Rows.Add("Cardiology", "Akhil", 10);
            table.Rows.Add("Neurology", "Sreedhar", 12);
            table.Rows.Add("Neurology", "Ashok", 6);
            table.Rows.Add("Neurology", "Srinivas", 10);
            table.Rows.Add("Gynocology", "Asha", 5);
            table.Rows.Add("Gynocology", "Lakshmi", 9);
            table.Rows.Add("Gynocology", "Yamini", 12);

            string temp;
            string rowData;
            foreach (DataRow row in table.Rows)
            {
                temp = "";
                rowData = row["Category"].ToString();
                if (rowData.Equals(category))
                {
                    foreach (var item in row.ItemArray)
                    {
                        if (temp.Equals(""))
                            temp = item.ToString();
                        else
                            temp = temp + "," + item.ToString();
                    }
                    DocInfo.Add(temp);
                }
            }
            return DocInfo;
        }
    }
}
