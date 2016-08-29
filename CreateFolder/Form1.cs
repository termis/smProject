using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Ookii.Dialogs;
//using System.Reflection;

namespace CreateFolder
{
    public partial class Form1 : Form
    {


        string path;
        string fullPath;

        public Form1()
        {
            InitializeComponent();
            //var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            //this.Text = String.Format("My Application Version {0}", version);
            string version = Application.ProductVersion;
            this.Text = String.Format("Application Version {0}", version);
        }
        // default folderbrowserdialog
        /*private void button1_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.Description = "Select folder";
            fbd.ShowNewFolderButton = true;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath;

            }

        }
        */
        //using Ookii
        private void button1_Click(object sender, EventArgs e)
        {

            VistaFolderBrowserDialog vfbd = new VistaFolderBrowserDialog();
            vfbd.RootFolder = Environment.SpecialFolder.Desktop;
            vfbd.Description = "Select folder";
            vfbd.ShowNewFolderButton = true;

            if (vfbd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = vfbd.SelectedPath;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            path = textBox1.Text;
            try
            {
                fullPath = Path.GetFullPath(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong folder destination:" + ex.Message);
                return;
            }

            Directory.CreateDirectory(path + "\\01_Supplier_information\\01_Strategic_intent_and_SWOT");
            Directory.CreateDirectory(path + "\\02_Agreements\\01_Agreements\\z_Old_Agreements");
            Directory.CreateDirectory(path + "\\02_Agreements\\02_Pricelist_Comdatafile\\z_Old_Pricelists");
            Directory.CreateDirectory(path + "\\03_Administration\\01_Activities");
            Directory.CreateDirectory(path + "\\03_Administration\\02_Meetings");
            Directory.CreateDirectory(path + "\\03_Administration\\03_Negotiation_preparation");
            Directory.CreateDirectory(path + "\\03_Administration\\04_Drafts");
            Directory.CreateDirectory(path + "\\04_Supplier_performance\\01_Assessments_Audits_Certificates");
            Directory.CreateDirectory(path + "\\04_Supplier_performance\\02_Cost");
            Directory.CreateDirectory(path + "\\04_Supplier_performance\\03_Quality");
            Directory.CreateDirectory(path + "\\04_Supplier_performance\\04_Supply");

            ListDirectory(treeView1, path);

        }
 
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }

        private void ListDirectory(TreeView treeView, string path)
        {
            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
        }

        private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            foreach (var file in directoryInfo.GetFiles())
                directoryNode.Nodes.Add(new TreeNode(file.Name));
            directoryNode.ExpandAll();
            return directoryNode;
        }
    }
}

