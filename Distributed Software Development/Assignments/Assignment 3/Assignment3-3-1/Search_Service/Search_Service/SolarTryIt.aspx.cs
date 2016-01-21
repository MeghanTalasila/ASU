using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Search_Service
{
    public partial class TryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Service1 searchService = new Service1();
            string category = DropDownList1.SelectedItem.ToString();
            List<string> DocInfo = new List<string>();
            DocInfo = searchService.searchCategory(category);
            if (DocInfo != null)
            {

                for (int i = 0; i < DocInfo.Count(); i++)
                {
                    TableRow tRow = new TableRow();
                    Table1.Rows.Add(tRow);
                    string temp = DocInfo[i];
                    string[] tempArray = temp.Split(',');
                    for (int j = 1; j < tempArray.Length; j++)
                    {
                        TableCell tCell = new TableCell();
                        tRow.Cells.Add(tCell);
                        tCell.Text = tempArray[j];
                    }
                }
            }
        }
    }
}