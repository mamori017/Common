using System;
using System.Data;
using System.Windows.Forms;

namespace Common
{
    public class DataGridViewControl
    {
        public static void ChangeCheckState(Object sender,DataGridView dataGridView, int cellPos = 0)
        {
            var btn = (Button)sender;
            bool checkState;

            try
            {
                bool parseRet = int.TryParse(btn.Tag.ToString(), out int btnTag);

                if (parseRet)
                {
                    checkState = btnTag == 1 ? true : false;
                }
                else
                {
                    checkState = false;
                }

                if (dataGridView.RowCount > 0)
                {
                    for (int i = 0; i == dataGridView.RowCount - 1; i++)
                    {
                        dataGridView.Rows[i].Cells[cellPos].Value = checkState;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool CheckboxSelectState(DataGridView dataGridView, int cellPos = 0)
        {
            try
            {
                if (dataGridView.RowCount > 0)
                {
                    for (int i = 0; i < dataGridView.RowCount - 1; i++)
                    {
                        if (dataGridView.Rows[i].Cells[cellPos].Value != null)
                        {
                            if ((bool)dataGridView.Rows[i].Cells[cellPos].Value == true)
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string[] GetCheckboxSelectValue(DataGridView dataGridView, int cellPos = 0)
        {
            string[] strId = null;
            var intCnt = 0;

            try
            {
                if(dataGridView.RowCount > 0){
                    for(int i = 0; i < dataGridView.RowCount - 1; i++)
                    {
                        if((bool)dataGridView.Rows[i].Cells[0].Value == true)
                        {
                            Array.Resize(ref strId, i);
                            strId[i] = (String)dataGridView.Rows[i].Cells[cellPos].Value;
                            intCnt ++;
                        }
                    }
                }
                return strId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ChangeReadOnlyCell(DataGridView dataGridView, bool firstCellTarget = false)
        {
            try
            {
                if (dataGridView.RowCount > 0)
                {
                    for(int i =0; i < dataGridView.ColumnCount - 1; i++)
                    {
                        if(firstCellTarget == false && i != 0)
                        {
                            dataGridView.Columns[i].ReadOnly = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void FilterViewChange(DataGridView dataGridView, String filterQuery)
        {
            try
            {
                DataTable objData = (DataTable)dataGridView.DataSource;

                if(objData != null)
                {
                    var objBind = new BindingSource
                    {
                        DataSource = objData,
                        Filter = filterQuery   
                    };
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool CreateDataGridView(DataTable objDataTable, DataGridView objDataGridView , bool vblnCheckFlg = false, int checkFlgOrdinal = 0)
        {
            try
            {
                if (objDataTable.Rows.Count > 0)
                {
                    objDataGridView.DataSource = null;

                    if(vblnCheckFlg == true)
                    {
                        var objColumn = (DataGridViewCheckBoxColumn)objDataGridView.Columns[checkFlgOrdinal]; 
                    }
                    objDataGridView.DataSource = objDataTable;
                    ChangeReadOnlyCell(objDataGridView);
                }
                else
                {
                    objDataGridView.DataSource = null;
                }

                objDataGridView.Refresh();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
