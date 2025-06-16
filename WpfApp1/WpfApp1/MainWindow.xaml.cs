using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Word.Application;
using Document = Microsoft.Office.Interop.Word.Document;
using Window = System.Windows.Window;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private string _currentData = "";

        public MainWindow()
        {
            InitializeComponent();
        }


        private async void BtnGetData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("TransferSimulator.exe");
                var response = await _httpClient.GetFromJsonAsync<ResponseModel>(
                    "http://localhost:4444/TransferSimulator/fullName"
                );
                _currentData = response?.Value ?? "";
                txtData.Text = _currentData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void BtnSendResult_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_currentData))
            {
                MessageBox.Show("Сначала получите данные!");
                return;
            }

            bool isValid = !Regex.IsMatch(_currentData, @"[\d!@#?=$:%^&*()]");
            UpdateTestDocument(isValid ? "Успешно" : "Не успешно");
            txtValidationResult.Text = isValid ? "Данные корректны" : "Найдены запрещенные символы";
        }

        private void UpdateTestDocument(string testResult)
        {
            Application wordApp = null;
            Document doc = null;

            try
            {

                wordApp = new Application();
                doc = wordApp.Documents.Open(
                    Environment.CurrentDirectory + @"\ТестКейс.docx",
                    ReadOnly: false
                );

                Microsoft.Office.Interop.Word.Table table = doc.Tables[1];

                Row newRow = table.Rows.Add();

                newRow.Cells[1].Range.Text = "Проверка ФИО на запрещенные символы";
                newRow.Cells[2].Range.Text = "Отсутствие цифр и спецсимволов";
                newRow.Cells[3].Range.Text = testResult;

                doc.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка работы с Word: {ex.Message}");
            }
            finally
            {
                doc?.Close(SaveChanges: false);
                wordApp?.Quit(SaveChanges: false);

                if (doc != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
                if (wordApp != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
            }
        }

        public record ResponseModel(string Value);

            }
}
