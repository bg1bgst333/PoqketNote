using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace PoqketNote
{
    public class FileData
    {
        public string FileName
        {
            get;
            set;
        }
        /*
        public DateTime Updated
        {
            get;
            set;
        }
        */
    }
    public class FileList
    {
        public List<FileData> Files
        {
            get;
            set;
        }
        public FileList()
        {
            Files = new List<FileData>();
        }
    }
}
