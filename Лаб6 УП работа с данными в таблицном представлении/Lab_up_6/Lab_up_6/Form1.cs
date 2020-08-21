using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_up_6
{
    public partial class dgvFrom : Form
    {
        private readonly string _sConnStr = new SqlConnectionStringBuilder
        {
            DataSource = "LAPTOP-6I6G07J5\\SQLZIM",
            InitialCatalog = "WorldCups",
            IntegratedSecurity = true
        }.ConnectionString;
        public dgvFrom()
        {
            InitializeComponent();
            InitializeDgvCups();
            InitializeDgvTrack();
        }

        private void InitializeDgvCups()
        {
            dgvCups.Rows.Clear();
            dgvCups.Columns.Clear();
            dgvCups.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "idКубка_мира",
                Visible = false
            });
            dgvCups.Columns.Add("Название_кубка", "Название");
            dgvCups.Columns.Add("Период", "Период");
            dgvCups.Columns.Add("Главный_приз", "Главный приз");

            using (var sConn = new SqlConnection(_sConnStr))
            {
                sConn.Open();
                var sCommand = new SqlCommand
                {
                    Connection = sConn,
                    CommandText = @"SELECT idКубка_мира, Название_кубка, Период, Главный_приз                            
                                    FROM Кубок_мира"
                };
                var reader = sCommand.ExecuteReader();
                while (reader.Read())
                {
                    var dataDict = new Dictionary<string, object>();
                    foreach (var columnsName in new[] { "Название_кубка", "Период", "Главный_приз" })
                    {
                        dataDict[columnsName] = reader[columnsName];
                    }
                    var rowIdx = dgvCups.Rows.Add(reader["idКубка_мира"], reader["Название_кубка"], reader["Период"], reader["Главный_приз"]);
                    dgvCups.Rows[rowIdx].Tag = dataDict;
                }
            }
        }

        private void InitializeDgvTrack()
        {
            dgvTrack.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "idТрассы",
                Visible = false
            });
            dgvTrack.Columns.Add("Название_трассы", "Название");
            dgvTrack.Columns.Add("Расположение_трассы", "Расположение трассы");
            dgvTrack.Columns.Add("Длина_трассы", "Длина трассы");
            dgvTrack.Columns.Add(new NumericUpDownColumn()
            {
                Name = "Средний_уклон",
                HeaderText = @"Средний уклон(%)",
            });
            var f = new NumericUpDownColumn();

            using (var sConn = new SqlConnection(_sConnStr))
            {
                sConn.Open();
                var sCommand = new SqlCommand
                {
                    Connection = sConn,
                    CommandText = @"SELECT idТрассы, Название_трассы, Расположение_трассы, Длина_трассы, Средний_уклон                           
                                    FROM Трасса"
                };
                var reader = sCommand.ExecuteReader();
                while (reader.Read())
                {
                    var dataDict = new Dictionary<string, object>();
                    foreach (var columnsName in new[] { "Название_трассы", "Расположение_трассы", "Длина_трассы", "Средний_уклон" })
                    {
                        dataDict[columnsName] = reader[columnsName];
                    }
                    var rowIdx = dgvTrack.Rows.Add(reader["idТрассы"], reader["Название_трассы"], reader["Расположение_трассы"], reader["Длина_трассы"], reader["Средний_уклон"]);
                    dgvTrack.Rows[rowIdx].Tag = dataDict;
                }
            }
        }

        private void dgvCups_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = dgvCups.Rows[e.RowIndex];
            if (dgvCups.IsCurrentRowDirty)
            {
                    var cellsWithPotentialErrors = new[] { row.Cells["Название_кубка"], row.Cells["Период"], row.Cells["Главный_приз"] };
                    foreach (var cell in cellsWithPotentialErrors)
                {
                    if (string.IsNullOrWhiteSpace((string)cell.Value))
                    {
                        row.ErrorText = string.Format("Значение в столбце '{0}' не может быть пустым",
                            cell.OwningColumn.HeaderText);
                        e.Cancel = true;
                    }
                }
                if (!e.Cancel)
                {
                    using (var sConn = new SqlConnection(_sConnStr))
                    {
                        sConn.Open();
                        var sCommand = new SqlCommand
                        {
                            Connection = sConn
                        };
                        sCommand.Parameters.AddWithValue("@CupName", row.Cells["Название_кубка"].Value);
                        sCommand.Parameters.AddWithValue("@CupPeriod", row.Cells["Период"].Value);
                        sCommand.Parameters.AddWithValue("@CupPrize", row.Cells["Главный_приз"].Value);
                        var cupId = (int?)row.Cells["idКубка_мира"].Value;
                        if (cupId.HasValue)
                        {
                            sCommand.CommandText = @"UPDATE Кубок_мира SET Название_кубка = @CupName, Период = @CupPeriod, 
                                                            Главный_приз = @CupPrize
                                                    WHERE idКубка_мира = @CupID";
                            sCommand.Parameters.AddWithValue("@CupID", cupId.Value);
                            sCommand.ExecuteNonQuery();
                        }
                        else
                        {
                            sCommand.CommandText = @"INSERT INTO Кубок_мира(Название_кубка, Период, Главный_приз)
                                                        OUTPUT inserted.idКубка_мира
                                                        VALUES (@CupName, @CupPeriod, @CupPrize)";
                            row.Cells["idКубка_мира"].Value = sCommand.ExecuteScalar();
                        }
                        var dataDict = new Dictionary<string, object>();
                        foreach (var columnsName in new[] { "Название_кубка", "Период", "Главный_приз" })
                        {
                            dataDict[columnsName] = row.Cells[columnsName].Value;
                        }
                        row.Tag = dataDict;
                    }
                    row.ErrorText = "";
                    foreach (var cell in cellsWithPotentialErrors)
                    {
                        cell.ErrorText = "";
                    }
                }
            }
        }

        private void dgvCups_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvCups.Rows[e.RowIndex].IsNewRow)
            {
                dgvCups[e.ColumnIndex, e.RowIndex].ErrorText = "Значение изменено и пока не сохранено.";
                if (dgvCups.Rows[e.RowIndex].Tag != null)
                    dgvCups[e.ColumnIndex, e.RowIndex].ErrorText += "\nПредыдущее значение - " +
                    ((Dictionary<string, object>)dgvCups.Rows[e.RowIndex].Tag)[dgvCups.Columns[e.ColumnIndex].Name];
            }
        }

        private void dgvCups_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var cupID = (int?)e.Row.Cells["idКубка_мира"].Value;
            if (cupID.HasValue)
            {
                using (var sConn = new SqlConnection(_sConnStr))
                {
                    sConn.Open();
                    var sCommand = new SqlCommand
                    {
                        Connection = sConn,
                        CommandText = "DELETE FROM Кубок_мира WHERE idКубка_мира = @CupID"
                    };
                    sCommand.Parameters.AddWithValue("@CupID", cupID.Value);
                    sCommand.ExecuteNonQuery();
                }
            }
        }

        private void dgvTrack_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = dgvTrack.Rows[e.RowIndex];
            if (dgvTrack.IsCurrentRowDirty)
            {
                var cellsWithPotentialErrors = new[] { row.Cells["Название_трассы"], row.Cells["Расположение_трассы"] };
                foreach (var cell in cellsWithPotentialErrors)
                {
                    if (string.IsNullOrWhiteSpace((string)cell.Value))
                    {
                        row.ErrorText = string.Format("Значение в столбце '{0}' не может быть пустым",
                            cell.OwningColumn.HeaderText);
                        e.Cancel = true;
                    }
                }
                double f = 0;
                if (row.Cells["Длина_трассы"].Value == null || !(Double.TryParse((string)(row.Cells["Длина_трассы"].Value), out f)))
                {
                    row.ErrorText = string.Format("Значение в столбце '{0}' должно иметь вещественный тип", "Длина_трассы");
                    e.Cancel = true;
                }
                if (!e.Cancel)
                {
                    using (var sConn = new SqlConnection(_sConnStr))
                    {
                        sConn.Open();
                        var sCommand = new SqlCommand
                        {
                            Connection = sConn
                        };
                        sCommand.Parameters.AddWithValue("@TrackName", row.Cells["Название_трассы"].Value);
                        sCommand.Parameters.AddWithValue("@TrackPlace", row.Cells["Расположение_трассы"].Value);
                        sCommand.Parameters.AddWithValue("@TrackLen", row.Cells["Длина_трассы"].Value);
                        sCommand.Parameters.AddWithValue("@TrackGrade", row.Cells["Средний_уклон"].Value);

                        var trackId = (int?)row.Cells["idТрассы"].Value;
                        if (trackId.HasValue)
                        {
                            sCommand.CommandText = @"UPDATE Трасса SET Название_трассы = @TrackName, Расположение_трассы = @TrackPlace, 
                                                            Длина_трассы = @TrackLen, Средний_уклон = @TrackGrade
                                                    WHERE idТрассы = @TrackId";
                            sCommand.Parameters.AddWithValue("@TrackId", trackId.Value);
                            sCommand.ExecuteNonQuery();
                        }
                        else
                        {
                            sCommand.CommandText = @"INSERT INTO Трасса(Название_трассы, Расположение_трассы, Длина_трассы, Средний_уклон)
                                                        OUTPUT inserted.idТрассы
                                                        VALUES (@TrackName, @TrackPlace, @TrackLen, @TrackGrade)";
                            row.Cells["idТрассы"].Value = sCommand.ExecuteScalar();
                        }
                        var dataDict = new Dictionary<string, object>();
                        foreach (var columnsName in new[] { "Название_трассы", "Расположение_трассы", "Длина_трассы", "Средний_уклон" })
                        {
                            dataDict[columnsName] = row.Cells[columnsName].Value;
                        }
                        row.Tag = dataDict;
                    }
                    row.ErrorText = "";
                    foreach (var cell in cellsWithPotentialErrors)
                    {
                        cell.ErrorText = "";
                    }
                    row.Cells["Средний_уклон"].ErrorText = "";
                    row.Cells["Длина_трассы"].ErrorText = "";
                }
            }
        }

        private void dgvTrack_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvTrack.Rows[e.RowIndex].IsNewRow)
            {
                dgvTrack[e.ColumnIndex, e.RowIndex].ErrorText = "Значение изменено и пока не сохранено.";
                if (dgvTrack.Rows[e.RowIndex].Tag != null)
                    dgvTrack[e.ColumnIndex, e.RowIndex].ErrorText += "\nПредыдущее значение - " +
                    ((Dictionary<string, object>)dgvTrack.Rows[e.RowIndex].Tag)[dgvTrack.Columns[e.ColumnIndex].Name];
            }
        }

        private void dgvTrack_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var trackId = (int?)e.Row.Cells["idТрассы"].Value;
            if (trackId.HasValue)
            {
                using (var sConn = new SqlConnection(_sConnStr))
                {
                    sConn.Open();
                    var sCommand = new SqlCommand
                    {
                        Connection = sConn,
                        CommandText = "DELETE FROM Трасса WHERE idТрассы = @TrackID"
                    };
                    sCommand.Parameters.AddWithValue("@TrackID", trackId.Value);
                    sCommand.ExecuteNonQuery();
                }
            }
        }

        private void dgvCups_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && dgvCups.IsCurrentRowDirty)
            {
                dgvCups.CancelEdit();
                if (dgvCups.CurrentRow.Cells["idКубка_мира"].Value != null)
                {
                    foreach (var kvp in (Dictionary<string, object>)dgvCups.CurrentRow.Tag)
                    {
                        dgvCups.CurrentRow.Cells[kvp.Key].Value = kvp.Value;
                        dgvCups.CurrentRow.Cells[kvp.Key].ErrorText = "";
                    }
                }
                else
                {
                    dgvCups.Rows.Remove(dgvCups.CurrentRow);
                }
            }
        }

        private void dgvTrack_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && dgvTrack.IsCurrentRowDirty)
            {
                dgvTrack.CancelEdit();
                if (dgvTrack.CurrentRow.Cells["idТрассы"].Value != null)
                {
                    foreach (var kvp in (Dictionary<string, object>)dgvTrack.CurrentRow.Tag)
                    {
                        dgvTrack.CurrentRow.Cells[kvp.Key].Value = kvp.Value;
                        dgvTrack.CurrentRow.Cells[kvp.Key].ErrorText = "";
                    }
                }
                else
                {
                    dgvTrack.Rows.Remove(dgvTrack.CurrentRow);
                }
            }
        }
    }
}


