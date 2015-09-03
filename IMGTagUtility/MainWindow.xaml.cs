using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

using System.IO;
using System.Drawing;


namespace IMGTagUtility
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_ConvertNow_Click(object sender, RoutedEventArgs e)
        {

            if (txt_LocalImgPath.Text == string.Empty)
            {
                lbl_FullPathValidator.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                lbl_FullPathValidator.Visibility = Visibility.Hidden;
            }

            if (txt_ImgFolderOnServer.Text == string.Empty)
            {
                lbl_ServerFolderValidator.Visibility = Visibility.Visible;
                return;
            }
            else 
            {
                lbl_ServerFolderValidator.Visibility = Visibility.Hidden;
            }


            string[] strLocalImgList = null;
            if (Directory.Exists(txt_LocalImgPath.Text.Trim()))  //
            {
                strLocalImgList = Directory.GetFiles(txt_LocalImgPath.Text.Trim());
            }
            else
            {
                lbl_ConversionMessage.Content = "That directory is not found";
                lbl_ConversionMessage.Visibility = Visibility.Visible;
                return;
            }
                       

            string imgFolderOnServer = txt_ImgFolderOnServer.Text.Trim();
            string srcPrefix = "http://www.mooremediaone.com/blogImg/" + imgFolderOnServer + "/";


            if (strLocalImgList.Length > 1)
            {

                foreach (var img in strLocalImgList)
                {
                    string imgName = img.Replace(txt_LocalImgPath.Text + "\\", string.Empty);
                    string srcProperty = srcPrefix + imgName;
                    string imgTag = "<img src=" + "\"" + srcProperty + "\"" + "/>" + "<br/>"; //adding double quotes to the string
                    using (System.IO.StreamWriter file = new StreamWriter(@"C:\Users\mooremedia\Documents\My Web Sites\ImgTagUtility\List.txt", true))
                    {
                        file.WriteLine(imgTag);
                    }

                }

                lbl_ConversionMessage.Visibility = Visibility.Visible;
                return;
            }
            else //if img list is blank
            {
                lbl_ConversionMessage.Visibility = Visibility.Visible;
                lbl_ConversionMessage.Content = "No files found.";
               // lbl_ConversionMessage.Foreground = Color.
                return;
            }

        }

      
        

    }
}
