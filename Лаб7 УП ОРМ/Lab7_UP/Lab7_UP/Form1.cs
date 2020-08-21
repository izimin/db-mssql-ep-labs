using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataGridViewIUD;


namespace Lab7_UP
{

    public partial class MainForm : Form
    {

        Dictionary<int, string> a;
        public MainForm()
        {
            InitializeComponent();
            InitializeDgvStage();
            InitializeDgvRace();

        }

        private void InitializeDgvStage()
        {
            dgvStage.Rows.Clear();
            dgvStage.Columns.Clear();
            dgvStage.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "idЭтапа",
                Visible = false
            });
            dgvStage.Columns.Add("Название_этапа", "Название этапа");
            dgvStage.Columns.Add("Место_провеления", "Место проведения");
            dgvStage.Columns.Add(new CalendarColumn
            {
                Name = "Дата_начала",
                HeaderText = @"Дата начала"
            });
            var f = new CalendarColumn();
            dgvStage.Columns.Add(new CalendarColumn
            {
                Name = "Дата_конца",
                HeaderText = @"Дата конца"
            });
            var cups = new DataGridViewComboBoxColumn
            {
                HeaderText = @"Кубок мира",
                Name = "Кубок"
            };
            dgvStage.Columns.Add(cups);
            
            using (var ctx = new WorldCupsContext())
            {
                var listCups = ctx.Кубок_мира.ToDictionary(item => item.idКубка_мира, item => "(" + item.idКубка_мира + ") " + item.Название_кубка);
                cups.DataSource = listCups.Values.ToList();

                foreach (var race in ctx.Этап_кубка_мира)
                {
                    var rowIdx = dgvStage.Rows.Add(race.idЭтапа_кубка_мира, race.Название_этапа, race.Место_провеления,
                        race.Дата_начала, race.Дата_конца, listCups[race.idКубка_мира]);
                    dgvStage.Rows[rowIdx].Tag = race;
                }
            }
        }

        private void InitializeDgvRace()
        {
            dgvRace.Rows.Clear();
            dgvRace.Columns.Clear();
            dgvRace.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "idГонки",
                Visible = false
            });
            dgvRace.Columns.Add("Тип_гонки", "Тип гонки");
            dgvRace.Columns.Add(new CalendarColumn
            {
                Name = "Дата_начала",
                HeaderText = @"Дата начала",
                    
            });
            dgvRace.Columns.Add(new GridTimeControl
            {
                Name = "Время_начала",
                HeaderText = @"Время начала"
            });

            dgvRace.Columns.Add(new CalendarColumn
            {
                Name = "Дата_окончания",
                HeaderText = @"Дата окончания"
            });
            dgvRace.Columns.Add(new GridTimeControl
            {
                Name = "Время_окончания",
                HeaderText = @"Время окончания"
            });

            var stages = new DataGridViewComboBoxColumn
            {
                HeaderText = @"Этап",
                Name = "Этап"
            };
            dgvRace.Columns.Add(stages);

            var tracks = new DataGridViewComboBoxColumn
            {
                HeaderText = @"Трасса",
                Name = "Трасса"
            };
            dgvRace.Columns.Add(tracks);

            using (var ctx = new WorldCupsContext())
            {
                var listStages = ctx.Этап_кубка_мира.ToDictionary(item => item.idЭтапа_кубка_мира, item => "(" + item.idЭтапа_кубка_мира + ") " + item.Название_этапа);
                stages.DataSource = listStages.Values.ToList();

                var listTracks = ctx.Трасса.ToDictionary(item => item.idТрассы, item => "(" + item.idТрассы + ") " + item.Название_трассы);
                tracks.DataSource = listTracks.Values.ToList();

                foreach (var race in ctx.Гонка)
                {
                    var rowIdx = dgvRace.Rows.Add(race.idГонки, race.Тип_гонки, race.Дата_начала, race.Время_начала.ToString(),
                        race.Дата_окончания, race.Время_окончания.ToString(), listStages[race.idЭтапа_кубка_мира], listTracks[race.idТрассы]);
                    dgvRace.Rows[rowIdx].Tag = race;
                }
            }
        }

        private void dgvRace_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = dgvRace.Rows[e.RowIndex];
            if (!dgvRace.IsCurrentRowDirty) return;
            var cellsWithPotentialErrors = new[] { row.Cells["Тип_гонки"], row.Cells["Этап"], row.Cells["Трасса"] };
            foreach (var cell in cellsWithPotentialErrors)
                if (string.IsNullOrWhiteSpace((string) cell.Value))
                {
                    row.ErrorText = $"Значение в столбце '{cell.OwningColumn.HeaderText}' не может быть пустым";
                    e.Cancel = true;
                }
            if (!e.Cancel)
            {
                var typeTrack = (string) row.Cells["Тип_гонки"].Value;
                var dateEnd = ((DateTime)row.Cells["Дата_окончания"].Value).Date;
                var dateBegin = ((DateTime)row.Cells["Дата_начала"].Value).Date;
                var idStage = int.Parse(((string) row.Cells["Этап"].Value).Substring(1,
                    ((string) row.Cells["Этап"].Value).IndexOf(')') - 1));
                var idTrack = int.Parse(((string) row.Cells["Трасса"].Value).Substring(1,
                    ((string) row.Cells["Трасса"].Value).IndexOf(')') - 1));
                var beginTime = row.Cells["Время_начала"].Value.ToString();
                TimeSpan bTime, eTime;
                var endTime = row.Cells["Время_окончания"].Value.ToString();
                if (!TimeSpan.TryParse(beginTime, out bTime))
                {
                    bTime = TimeSpan.Parse(beginTime.Split(' ')[1]);
                }
                if (!TimeSpan.TryParse(endTime, out eTime))
                {
                    eTime = TimeSpan.Parse(endTime.Split(' ')[1]);
                }
                var r = (Гонка)row.Tag;
                      
                using (var ctx = new WorldCupsContext())
                {
                    var cupId = (int?)row.Cells["idГонки"].Value;
                    if (cupId.HasValue)
                    {
                        ctx.Гонка.Attach(r);
                        r.Тип_гонки = typeTrack;
                        r.Дата_окончания = dateEnd;
                        r.Время_начала = bTime;
                        r.Время_окончания = eTime;
                        r.Дата_начала = dateBegin;
                        r.idЭтапа_кубка_мира = idStage;
                        r.idТрассы = idTrack;
                        row.Tag = r;
                        row.Cells["idГонки"].Value = r.idГонки;
                    }
                    else
                    {
                        var race = new Гонка
                        {
                            Тип_гонки = typeTrack,
                            Дата_окончания = dateEnd,
                            Дата_начала = dateBegin,
                            Время_начала = bTime,
                            Время_окончания = eTime,
                            idЭтапа_кубка_мира = idStage,
                            idТрассы = idTrack
                        };
                        ctx.Гонка.Add(race);
                        row.Tag = race;
                        row.Cells["idГонки"].Value = race.idГонки;
                    }

                    try
                    {
                        ctx.SaveChanges();
                    }
                    catch
                    {
                        row.ErrorText = "Нельзя добавить такую строку!!! Уже есть идентичная ей";
                        row.Cells["idГонки"].Value = null;
                        e.Cancel = true;
                    }

                }

                row.ErrorText = "";
                foreach (var cell in row.Cells)
                {
                    ((DataGridViewCell)cell).ErrorText = "";
                }
            }
        }

        private void dgvRace_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvRace.Rows[e.RowIndex].IsNewRow)
            {
                dgvRace[e.ColumnIndex, e.RowIndex].ErrorText = "Значение изменено и пока не сохранено.";
            }
        }

        private void dgvRace_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var cupId = (int?)e.Row.Cells["idГонки"].Value;
            if (!cupId.HasValue) return;
            using (var ctx = new WorldCupsContext())
            {
                var r = (Гонка) e.Row.Tag;
                ctx.Гонка.Attach(r);
                ctx.Гонка.Remove(r);
                ctx.SaveChanges();
            }
        }

        private void dgvRace_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && dgvRace.IsCurrentRowDirty)
            {
                dgvRace.CancelEdit();
                if (dgvRace.CurrentRow.Cells["idГонки"].Value != null)
                {
                    // TO DO 
                }
                else
                    dgvRace.Rows.Remove(dgvRace.CurrentRow);
            }
        }

        private void dgvStage_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = dgvStage.Rows[e.RowIndex];
            if (!dgvStage.IsCurrentRowDirty) return;

            var cellsWithPotentialErrors = new[] { row.Cells["Название_этапа"], row.Cells["Место_провеления"], row.Cells["Кубок"] };
            foreach (var cell in cellsWithPotentialErrors)
                if (string.IsNullOrWhiteSpace((string)cell.Value))
                {
                    row.ErrorText = $"Значение в столбце '{cell.OwningColumn.HeaderText}' не может быть пустым";
                    e.Cancel = true;
                }

            if (!e.Cancel)
            {
                var nameStage = (string) row.Cells["Название_этапа"].Value;
                var placeStage = (string) row.Cells["Место_провеления"].Value;
                var dateBegin = ((DateTime) row.Cells["Дата_начала"].Value).Date;
                var dateEnd = ((DateTime) row.Cells["Дата_конца"].Value).Date;
                var idCup = int.Parse(((string) row.Cells["Кубок"].Value).Substring(1,
                    ((string) row.Cells["Кубок"].Value).IndexOf(')') - 1));
                              
                using (var ctx = new WorldCupsContext())
                {
                    var cupId = (int?)row.Cells["idЭтапа"].Value;
                    if (cupId.HasValue)
                    {
                        var stage = (Этап_кубка_мира) row.Tag;
                        ctx.Этап_кубка_мира.Attach(stage);
                        stage.Название_этапа = nameStage;
                        stage.Место_провеления = placeStage;
                        stage.Дата_начала = dateBegin;
                        stage.Дата_конца = dateEnd;
                        stage.idКубка_мира = idCup;
                        row.Tag = stage;
                        row.Cells["idЭтапа"].Value = stage.idЭтапа_кубка_мира;
                    }
                    else
                    {
                        var stage = new Этап_кубка_мира
                        {
                            Название_этапа = nameStage,
                            Место_провеления = placeStage,
                            Дата_начала = dateBegin,
                            Дата_конца = dateEnd,
                            idКубка_мира = idCup
                        };

                        ctx.Этап_кубка_мира.Add(stage);

                        row.Tag = stage;
                        row.Cells["idЭтапа"].Value = stage.idЭтапа_кубка_мира;
                    }

                    try
                    {
                        ctx.SaveChanges();
                    }
                    catch
                    {
                        row.ErrorText = "Нельзя добавить такую строку!!! Уже есть идентичная ей";
                        //MessageBox.Show("Уже есть такая строка!");
                        row.Cells["idЭтапа"].Value = null;
                        e.Cancel = true;
                    }

                    InitializeDgvRace();
                }

                if (!e.Cancel)
                {
                    row.ErrorText = "";
                    foreach (var cell in row.Cells)
                    {
                        ((DataGridViewCell) cell).ErrorText = "";
                    }
                }
            }
        }

        private void dgvStage_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvStage.Rows[e.RowIndex].IsNewRow)
            {
                dgvStage[e.ColumnIndex, e.RowIndex].ErrorText = "Значение изменено и пока не сохранено.";
            }
        }

        private void dgvStage_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var stageId = (int?)e.Row.Cells["idЭтапа"].Value;
            if (!stageId.HasValue) return;
            using (var ctx = new WorldCupsContext())
            {
                var stage = (Этап_кубка_мира) e.Row.Tag;
                try
                {
                    ctx.Этап_кубка_мира.Attach(stage);
                    ctx.Этап_кубка_мира.Remove(stage);
                    ctx.SaveChanges();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException)
                {
                    MessageBox.Show(@"Используется в БД! Удаление прервано");
                    e.Cancel = true;
                }
                var listStages = ctx.Этап_кубка_мира.ToDictionary(item => item.idЭтапа_кубка_мира, item => "(" + item.idЭтапа_кубка_мира + ") " + item.Название_этапа);
                ((DataGridViewComboBoxColumn)(dgvRace.Columns["Этап"])).DataSource = listStages.Values.ToList();
            }

        }

        private void dgvStage_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode != Keys.Escape || !dgvStage.IsCurrentRowDirty) return;
            dgvStage.CancelEdit();
            if (dgvStage.CurrentRow.Cells["idЭтапа"].Value != null)
            {
                //TO DO
            }
            else
                dgvStage.Rows.Remove(dgvStage.CurrentRow);
           
        }
    }
}
