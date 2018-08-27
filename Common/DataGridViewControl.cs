using System;
using System.Data;
using System.Windows.Forms;

namespace Common
{
    /// <summary>
    /// 
    /// </summary>
    public class DataGridViewControl
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="dataGridView"></param>
        /// <param name="cellPos"></param>
        public static void ChangeCheckState(Object sender,DataGridView dataGridView, int cellPos = 0)
        {
            Button btn = (Button)sender;
            bool checkState = false;
            bool parseRet = false;
            int btnTag = 0;

            try
            {
                parseRet = int.TryParse(btn.Tag.ToString(), out btnTag);

                if (parseRet)
                {
                    if(btnTag == 1)
                    {
                        checkState = true;
                    }
                    else
                    {
                        checkState = false;
                    }
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="cellPos"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="cellPos"></param>
        /// <returns></returns>
        public static string[] GetCheckboxSelectValue(DataGridView dataGridView, int cellPos = 0)
        {
            String[] strId = null;
            int intCnt = 0;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="firstCellTarget"></param>
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="filterQuery"></param>
        public static void FilterViewChange(DataGridView dataGridView, String filterQuery)
        {
            BindingSource objBind;
            DataTable objData;

            try
            {
                objData = (DataTable)dataGridView.DataSource;

                if(objData != null)
                {
                    objBind = new BindingSource
                    {
                        DataSource = objData,
                        Filter = filterQuery   
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objBind = null;
                objData = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objDataTable"></param>
        /// <param name="objDataGridView"></param>
        /// <param name="vblnCheckFlg"></param>
        /// <param name="checkFlgOrdinal"></param>
        /// <returns></returns>
        public static bool CreateDataGridView(DataTable objDataTable, DataGridView objDataGridView , bool vblnCheckFlg = false, int checkFlgOrdinal = 0)
        {
            DataGridViewCheckBoxColumn objColumn = null;
            try
            {
                if (objDataTable.Rows.Count > 0)
                {
                    objDataGridView.DataSource = null;

                    if(vblnCheckFlg == true)
                    {
                        objColumn = (DataGridViewCheckBoxColumn)objDataGridView.Columns[checkFlgOrdinal]; 
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objColumn = null;
            }
        }
    }
}
