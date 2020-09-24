using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using Xabe.FFmpeg;

namespace AudioExtractor
{
    public partial class MainWindow
    {
        private FFmpegClass _ffmpegClass;
        private string _filePath;

        public MainWindow()
        {
            InitializeComponent();
            _ffmpegClass = new FFmpegClass();
            _filePath = string.Empty;
        }

        private void LoadButtonClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog {
                Filter = "All files (*.*)|*.*", 
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == true)
            {
                _filePath = openFileDialog.FileName;
                MessageBox.Show(_filePath);
            }
        }

        private void ConvertButtonClicked(object sender, System.Windows.RoutedEventArgs e)
        {
        }
    }

    public class FFmpegClass
    {
        public FFmpegClass()
        {
            
        }
    }
}