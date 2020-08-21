using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text;

namespace Lab7_UP
{
    public partial class GridTimeControl : DataGridViewColumn
    {
        public GridTimeControl() : base()
        {
            base.CellTemplate = new CalendarCell1();
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (!((value == null)) && !(value.GetType().IsAssignableFrom(typeof(CalendarCell1))))
                {
                    throw new InvalidCastException("Must be a CalendarCell");
                }
                base.CellTemplate = value;
            }
        }
    }
    public class CalendarCell1 : DataGridViewTextBoxCell
    {

        public CalendarCell1()
        {
            this.Style.Format = "hh:mm tt";
        }
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {

            // Set the value of the editing control to the current cell value. 
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            CalendarEditingControl1 ctl = (CalendarEditingControl1)DataGridView.EditingControl;
            if (this.RowIndex >= 0)
            {
                if ((!object.ReferenceEquals(this.Value, DBNull.Value)))
                {
                    if (this.Value != null)
                    {
                        if (this.Value != string.Empty)
                        {
                            try
                            {
                                ctl.Value = Convert.ToDateTime(DateTime.Parse(this.Value.ToString()).ToLongTimeString());
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                }
            }
        }

        public override System.Type EditType
        {
            get
            {
                return typeof(CalendarEditingControl1);
            }
        }
        public override System.Type ValueType
        {
            get
            {
                return typeof(DateTime);
            }
        }
        public override object DefaultNewRowValue
        {
            get
            {
                return DateTime.Now.ToLongTimeString();
            }
        }
    }

    class CalendarEditingControl1 : DateTimePicker, IDataGridViewEditingControl
    {
        private DataGridView _dataGridViewControl;
        private bool _valueIsChanged = false;
        private int _rowIndexNum;

        public CalendarEditingControl1()
        {
            this.Format = DateTimePickerFormat.Time;
        }

        public object EditingControlFormattedValue
        {
            get
            {
                return this.Value.ToLongTimeString();
            }
            set
            {  //----------Change By Ankur-----------------
                //if (value is string)
                //{
                this.Value = Convert.ToDateTime(((DateTime)(value)).ToLongTimeString());
                //}
            }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return this.Value.ToLongTimeString();
        }

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ShowUpDown = true;
            this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
            this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

        public int EditingControlRowIndex
        {
            get
            {
                return _rowIndexNum;
            }
            set
            {
                _rowIndexNum = value;
            }
        }
        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        {
            if (Keys.KeyCode == Keys.Left || Keys.KeyCode == Keys.Up || Keys.KeyCode == Keys.Down || Keys.KeyCode == Keys.Right || Keys.KeyCode == Keys.Home || Keys.KeyCode == Keys.End || Keys.KeyCode == Keys.PageDown || Keys.KeyCode == Keys.PageUp)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void PrepareEditingControlForEdit(bool selectAll)
        {
        }
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return _dataGridViewControl;
            }
            set
            {
                _dataGridViewControl = value;
            }
        }
        public bool EditingControlValueChanged
        {
            get
            {
                return _valueIsChanged;
            }
            set
            {
                _valueIsChanged = value;
            }
        }
        public Cursor EditingControlCursor
        {
            get
            {
                return base.Cursor;
            }
        }
        protected override void OnValueChanged(System.EventArgs eventargs)
        {
            _valueIsChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
            this.Value = Convert.ToDateTime(Value.ToLongTimeString());
        }
        #region IDataGridViewEditingControl Members
        Cursor IDataGridViewEditingControl.EditingPanelCursor
        {
            get { return base.Cursor; }//throw new Exception("The method or operation is not implemented."); }
        }
        #endregion
    }
}