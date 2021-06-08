using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfDataTimeLab
{
    class CardsTable
    {
        private List<Card> table = new List<Card>();

        public DataTable ToTable()
        {
            var t = new DataTable();
            DataColumn column;
            t.TableName = "Data";
            for (int j = 0; j < 7; j++)
            {
                column = new DataColumn();
                column.DataType = Type.GetType("System.String");
                switch (j)
                {
                    case 0:
                        column.ColumnName = "ID";
                        break;
                    case 1:
                        column.ColumnName = "Name";
                        break;
                    case 2:
                        column.ColumnName = "DateBirth";
                        break;
                    case 3:
                        column.ColumnName = "Gender";
                        break;
                    case 4:
                        column.ColumnName = "DateBegin";
                        break;
                    case 5:
                        column.ColumnName = "Post";
                        break;
                    case 6:
                        column.ColumnName = "Monie";
                        break;
                }

                t.Columns.Add(column);
            }

            

            for (int i = 0; i < table.Count; i++)
            {
                var newRow = t.NewRow();
                newRow[0] = Convert.ToString(table[i].ID);
                newRow[1] = Convert.ToString(table[i].Name);
                newRow[2] = Convert.ToString(table[i].DateBirth).Split(' ')[0] + " (" + Convert.ToString(table[i].YearsOld) + " лет)";
                newRow[3] = Convert.ToString(table[i].Gender);
                newRow[4] = Convert.ToString(table[i].DateBegin).Split(' ')[0] + " (прошло " + Convert.ToString(table[i].TimeWork) + " дней)"; 
                newRow[5] = Convert.ToString(table[i].Post);
                newRow[6] = Convert.ToString(table[i].Monie);
                t.Rows.Add(newRow);
            }
            return t;
        }

        public DataTable ToTablePers()
        {
            var t = new DataTable();
            DataColumn column;
            t.TableName = "Data";
            for (int j = 0; j < 7; j++)
            {
                column = new DataColumn();
                column.DataType = Type.GetType("System.String");
                switch (j)
                {
                    case 0:
                        column.ColumnName = "ID";
                        break;
                    case 1:
                        column.ColumnName = "Name";
                        break;
                    case 2:
                        column.ColumnName = "DateBirth";
                        break;
                    case 3:
                        column.ColumnName = "Gender";
                        break;
                    case 4:
                        column.ColumnName = "DateBegin";
                        break;
                    case 5:
                        column.ColumnName = "Post";
                        break;
                    case 6:
                        column.ColumnName = "Monie";
                        break;
                }

                t.Columns.Add(column);
            }



            for (int i = 0; i < table.Count; i++)
            {
                bool isTrueMale = (table[i].Gender == 'М') && (table[i].YearsOld <= 60);
                bool isTrueFemale = (table[i].Gender == 'Ж') && (table[i].YearsOld <= 55);
                int f = table[i].TimeWork / 365;
                if ((isTrueFemale || isTrueMale) && (table[i].TimeWork/365 > 30))
                {
                    var newRow = t.NewRow();
                    newRow[0] = Convert.ToString(table[i].ID);
                    newRow[1] = Convert.ToString(table[i].Name);
                    newRow[2] = Convert.ToString(table[i].DateBirth).Split(' ')[0] + " (" + Convert.ToString(table[i].YearsOld) + " лет)";
                    newRow[3] = Convert.ToString(table[i].Gender);
                    newRow[4] = Convert.ToString(table[i].DateBegin).Split(' ')[0] + " (прошло " + Convert.ToString(table[i].TimeWork) + " дней)";
                    newRow[5] = Convert.ToString(table[i].Post);
                    newRow[6] = Convert.ToString(table[i].Monie);
                    t.Rows.Add(newRow);
                }
            }
            return t;
        }

        public Card GetRow(int i) 
        {
            return table[i];
        }

        public void Add(Card row)
        {
            table.Add(row);
        }

        public void Delete (int id)
        {
            for (int i = 0; i < table.Count; i++)
            {
                if (table[i].ID == id)
                {
                    table.RemoveAt(i);
                    return;
                }
            }
            MessageBox.Show($"Не найдена запись с табельным номером {id}!");
            return;
        }


        public int Count
        {
            get
            {
                return table.Count;
            }
        }
    }
}
