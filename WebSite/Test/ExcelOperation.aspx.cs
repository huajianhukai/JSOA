using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;

using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

namespace JSOA.WebSite.Test
{
    public partial class ExcelOperation : System.Web.UI.Page
    {


        XSSFWorkbook hssfworkbook;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void InitializeWorkbook(string path)
        {
            
            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new XSSFWorkbook(file);
             
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string filepath = FileUpload1.PostedFile.FileName;

            InitializeWorkbook(filepath);
            ConvertToDataTable();

        }

        void ConvertToDataTable()
        {
            ISheet sheet = hssfworkbook.GetSheet("CAF-1");
            sheet.ForceFormulaRecalculation = true;
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            DataTable dt = new DataTable();
            for (int j = 0; j < 12; j++)
            {
                dt.Columns.Add(Convert.ToChar(((int)'A') + j).ToString());
            }
            int num = 0;
            while (rows.MoveNext())
            {
              
                    IRow row = (XSSFRow)rows.Current;
                    DataRow dr = dt.NewRow();

                    for (int i = 0; i < row.LastCellNum; i++)
                    {
                        ICell cell = row.GetCell(i);

                      


                        if (cell == null)
                        {
                            dr[i] = null;
                        }
                        else
                        {
                            if ((num == 35 && i == 6) || (num == 49 && i == 6)|| (num == 51 && i == 6)
                               || (num == 54 && i == 6))//(num == 49 && i == 0) || (num == 49 && i == 1)
                            {
                                dr[i] = cell.NumericCellValue.ToString();
                              
                               
                            }
                            else if ((num == 58 && i == 6) || (num == 29 && i == 1) || (num == 29 && i == 2) || (num == 29 && i == 3) || (num == 29 && i == 4) || (num == 29 && i == 5) || (num == 29 && i == 6))
                            {
                                
                                    dr[i] = (Math.Round(cell.NumericCellValue, 4) * 100).ToString() + "%";
                                

                            }
                            else
                            {
                                dr[i] = cell.ToString();
                            }
                        }
                    }
                    dt.Rows.Add(dr);
               
                 num++;
            }

            

            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();

            StringBuilder sb = new StringBuilder();

            sb.Append(AddColon(dt.Rows[5][4].ToString().Trim()) + dt.Rows[5][5].ToString().Trim() + "<br/>");
            sb.Append(AddColon(dt.Rows[6][4].ToString().Trim()) +  dt.Rows[6][5].ToString().Trim() + "<br/>");
            sb.Append(AddColon(dt.Rows[35][0].ToString().Trim())+ dt.Rows[35][6].ToString().Trim() + "<br/>");
            sb.Append(dt.Rows[33][0].ToString() + "&" + AddColon(dt.Rows[34][0].ToString().Trim()) + dt.Rows[33][2].ToString().Trim() + "/" + dt.Rows[34][2].ToString().Trim() + "台<br/>");
            sb.Append("Fitting service charge:" + dt.Rows[49][6].ToString().Trim() + "<br/>");

            sb.Append(AddColon(dt.Rows[51][0].ToString().Trim()) + dt.Rows[51][6].ToString().Trim() + "<br/>");
            sb.Append("Sub-contracting:" + dt.Rows[54][6].ToString().Trim() + "<br/>");
            sb.Append("GP:" + dt.Rows[58][6].ToString().Trim() + "<br/>");
            sb.Append(AddColon(dt.Rows[21][4].ToString().Trim()) + dt.Rows[21][5].ToString().Trim() + "<br/>");
            sb.Append(AddColon(dt.Rows[24][0].ToString().Trim()) + dt.Rows[24][2].ToString().Trim() + "<br/>");
            sb.Append(AddColon(dt.Rows[26][0].ToString().Trim()) + "<br/>");

            sb.Append(AddColon(dt.Rows[27][0].ToString().Trim()) + dt.Rows[27][1].ToString().Trim() +"|"+
                dt.Rows[27][2].ToString().Trim() +
                dt.Rows[27][3].ToString().Trim() +
                dt.Rows[27][4].ToString().Trim() +
                dt.Rows[27][5].ToString().Trim() +
                dt.Rows[27][6].ToString().Trim() + "<br/>");
            sb.Append(AddColon(dt.Rows[28][0].ToString().Trim()) + dt.Rows[28][1].ToString().Trim() + "|" +
                dt.Rows[28][2].ToString().Trim() +
                dt.Rows[28][3].ToString().Trim() +
                dt.Rows[28][4].ToString().Trim() +
                dt.Rows[28][5].ToString().Trim() +
                dt.Rows[28][6].ToString().Trim() + "<br/>");
            sb.Append(AddColon(dt.Rows[29][0].ToString().Trim()) + dt.Rows[29][1].ToString().Trim() + "|" +
                dt.Rows[29][2].ToString().Trim() +
                dt.Rows[29][3].ToString().Trim() +
                dt.Rows[29][4].ToString().Trim() +
                dt.Rows[29][5].ToString().Trim() +
                dt.Rows[29][6].ToString().Trim() + "<br/>");

            Response.Write(sb.ToString());
        }

        public string AddColon(string str)
        {
            if (str.EndsWith(":"))
            {
                return str;

            }
            else
            {
                return str + ":";
            }
        }


    }
}