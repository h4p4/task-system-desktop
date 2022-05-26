using Microsoft.EntityFrameworkCore;
using System;
using System.Windows;
using TaskSystem.ViewModels;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace TaskSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для TasksReportWindow.xaml
    /// </summary>
    public partial class TasksReportWindow : System.Windows.Window
    {
        private string _savingDirectory = string.Empty;
        private bool _areHeadersEnabled = false;
        public TasksReportWindow(System.Collections.ObjectModel.ObservableCollection<Models.Task> allTasks)
        {
            InitializeComponent();
            DataContext = new TasksReportWindowViewModel(allTasks);
            Helper.taskSystemContext.Users.Load();
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Handle();
        }
        private void DirectoryChangerBtn_Click(object sender, RoutedEventArgs e)
        {
            DirectoryChangerBtn.Content = "Change";
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.ShowDialog();
            _savingDirectory = dialog.SelectedPath;
        }
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DirectoryChangerBtn.Content = "Choose";
        }

        private void EnableHeadersChBox_Checked(object sender, RoutedEventArgs e)
        {
            _areHeadersEnabled = !_areHeadersEnabled;
        }
        private void EnableHeadersChBox_Unchecked(object sender, RoutedEventArgs e)
        {
            _areHeadersEnabled = !_areHeadersEnabled;
        }
        private void Handle()
        {
            if (_savingDirectory == String.Empty)
            {
                MessageBox.Show("Please choose a directory to save file!", "Wrong directory", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            switch (SavingTypeCombobox.SelectedIndex)
            {
                case 0:
                    SaveToPdf();
                    break;
                case 1: 
                    SaveToWord();
                    break;
                case 2: 
                    SaveToExcel();
                    break;


            }
            DirectoryChangerBtn.Content = "Choose";
            MessageBox.Show("Report was saved to " + _savingDirectory, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            _savingDirectory = string.Empty;
            this.Close();
        }
        private void SaveToPdf()
        {
            Aspose.Pdf.Document document = new Aspose.Pdf.Document();
            Aspose.Pdf.Page page = document.Pages.Add();
            Aspose.Pdf.Table table = new Aspose.Pdf.Table();
            table.Border = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, .5f, Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black));
            table.DefaultCellBorder = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, .5f, Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black));

            if (_areHeadersEnabled)
            {
                Aspose.Pdf.Row row = table.Rows.Add();
                row.Cells.Add("Id");
                row.Cells.Add("Title");
                row.Cells.Add("Description");
                row.Cells.Add("Publication date");
                row.Cells.Add("Creator user");
                row.Cells.Add("Accepted user");
                row.Cells.Add("Status");
            }
            for (int i = 0; i < AllTasksDataGrid.Items.Count; i++)
            {
                Models.Task taskForAdd = AllTasksDataGrid.Items.GetItemAt(i) as Models.Task;
                Aspose.Pdf.Row row = table.Rows.Add();
                row.Cells.Add(taskForAdd.Id.ToString());
                row.Cells.Add(taskForAdd.Title);
                row.Cells.Add(taskForAdd.Description);
                row.Cells.Add(taskForAdd.PublicationDate.ToString());
                row.Cells.Add(taskForAdd.CreatorUser.Surname + " " + taskForAdd.CreatorUser.FirstName + " " + taskForAdd.CreatorUser.MiddleName);
                if (taskForAdd.AcceptedUser != null)
                    row.Cells.Add(taskForAdd.AcceptedUser.Surname + " " + taskForAdd.AcceptedUser.FirstName + " " + taskForAdd.AcceptedUser.MiddleName);
                else row.Cells.Add(" ");
                row.Cells.Add(taskForAdd.TaskStatus.Title);
            }
            table.DefaultColumnWidth = "61";
            page.Paragraphs.Add(table);
            string fileName = "\\Task_report_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".pdf";
            string fullFileName = $"{_savingDirectory}{fileName}";
            document.Save(fullFileName);


            //workSheet.SaveAs($"{_savingDirectory}{fileName}");
        }
        private void SaveToWord()
        {
            object start = 0;
            object end = 0;
            //Word.Application wordApp = new Word.Application();
            Word.Document wordDoc = new Word.Document();
            Word.Range tableLocation = wordDoc.Range(ref start, ref end);
            //tableLocation.SetRange(tableLocation.End, tableLocation.End);
            wordDoc.Tables.Add(tableLocation, AllTasksDataGrid.Items.Count, 7);
            var table = wordDoc.Tables[1];
            table.AllowAutoFit = true;
            table.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
            table.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;


            Word.Cell cell = table.Cell(1, 1);
            //cell.Range.Text = "aaaaaaaaaaaaaaaaaaaaa";
            //cell.Range.Text = "aaa";
            int rowWord = 1;
            if (_areHeadersEnabled)
            {
                table.Cell(1, 1).Range.Text = "Id";
                table.Cell(1, 2).Range.Text = "Title";
                table.Cell(1, 3).Range.Text = "Description";
                table.Cell(1, 4).Range.Text = "Publication date";
                table.Cell(1, 5).Range.Text = "Creator user";
                table.Cell(1, 6).Range.Text = "Accepted user";
                table.Cell(1, 7).Range.Text = "Status";
                rowWord = 2;
            }
            for (int i = 0; i < AllTasksDataGrid.Items.Count; i++)
            {
                Models.Task taskForAdd = AllTasksDataGrid.Items.GetItemAt(i) as Models.Task;

                table.Cell(rowWord, 1).Range.Text = taskForAdd.Id.ToString();
                table.Cell(rowWord, 2).Range.Text = taskForAdd.Title;
                table.Cell(rowWord, 3).Range.Text = taskForAdd.Description;
                table.Cell(rowWord, 4).Range.Text = taskForAdd.PublicationDate.ToString();
                table.Cell(rowWord, 5).Range.Text = taskForAdd.CreatorUser.Surname + " " + taskForAdd.CreatorUser.FirstName + " " + taskForAdd.CreatorUser.MiddleName;
                if (taskForAdd.AcceptedUser != null)
                    table.Cell(rowWord, 6).Range.Text = taskForAdd.AcceptedUser.Surname + " " + taskForAdd.AcceptedUser.FirstName + " " + taskForAdd.AcceptedUser.MiddleName;
                table.Cell(rowWord, 7).Range.Text = taskForAdd.TaskStatus.Title;

                ++rowWord;
            }



            string fileName = "\\Task_report_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".docx";
            wordDoc.SaveAs($"{_savingDirectory}{fileName}");
        }
        private void SaveToExcel()
        {
            int rowExcel = 1;
            Excel.Application exApp = new Excel.Application();
            exApp.Workbooks.Add();
            Worksheet workSheet = (Worksheet)exApp.ActiveSheet;

            if (_areHeadersEnabled)
            {
                workSheet.Cells[1, 1] = "Id";
                workSheet.Cells[1, 2] = "Title";
                workSheet.Cells[1, 3] = "Description";
                workSheet.Cells[1, 4] = "Publication date";
                workSheet.Cells[1, 5] = "Creator user";
                workSheet.Cells[1, 6] = "Accepted user";
                workSheet.Cells[1, 7] = "Status";
                rowExcel = 2;
            }
            for (int i = 0; i < AllTasksDataGrid.Items.Count; i++)
            {
                Models.Task taskForAdd = AllTasksDataGrid.Items.GetItemAt(i) as Models.Task;

                workSheet.Cells[rowExcel, "A"] = taskForAdd.Id;
                workSheet.Cells[rowExcel, "B"] = taskForAdd.Title;
                workSheet.Cells[rowExcel, "C"] = taskForAdd.Description;
                workSheet.Cells[rowExcel, "D"] = taskForAdd.PublicationDate;
                workSheet.Cells[rowExcel, "E"] = taskForAdd.CreatorUser.Surname + " " +  taskForAdd.CreatorUser.FirstName + " " + taskForAdd.CreatorUser.MiddleName;
                if (taskForAdd.AcceptedUser != null)
                    workSheet.Cells[rowExcel, "F"] = taskForAdd.AcceptedUser.Surname + " " + taskForAdd.AcceptedUser.FirstName + " " + taskForAdd.AcceptedUser.MiddleName;
                workSheet.Cells[rowExcel, "G"] = taskForAdd.TaskStatus.Title;

                ++rowExcel;
            }
            workSheet.Columns.AutoFit();
            string fileName = "\\Task_report_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xlsx";
            workSheet.SaveAs($"{_savingDirectory}{fileName}");
            exApp.Quit();
        }


    }
}
