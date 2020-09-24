using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using MediaToolkit;
using Microsoft.Win32;

namespace AudioExtractor
{
    public partial class MainWindow
    {
        private string _filePath;

        public MainWindow()
        {
            InitializeComponent();
            _filePath = string.Empty;
        }

        private void LoadButtonClicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog {
                Filter = "Video files (*.mp4, *.mkv)|*.mp4;*.mkv", 
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == true)
            {
                _filePath = openFileDialog.FileName;
                MessageBox.Show($"다음 파일이 선택되었습니다.\n{_filePath}");
            }
        }

        private void ConvertButtonClicked(object sender, RoutedEventArgs e)
        {
            if (_filePath == string.Empty)
            {
                MessageBox.Show("파일이 선택되지 않았습니다.");
                return;
            }
            
            var inputFile = new MediaToolkit.Model.MediaFile { Filename = _filePath };
            var outputFile = new MediaToolkit.Model.MediaFile { Filename = Path.ChangeExtension(_filePath, ".mp3") };

            try
            {
                using (var mediaEngine = new Engine())
                {
                    mediaEngine.GetMetadata(inputFile);
                    mediaEngine.Convert(inputFile, outputFile);
                }

                MessageBox.Show("변환에 성공했습니다.");
                Process.Start("explorer.exe", @Path.GetDirectoryName(_filePath));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"변환에 실패했습니다.\n >> {ex.Message}");
            }
        }
    }
}