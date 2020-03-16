using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WikiForm
{
    public partial class Form1 : Form
    {
        private string pathToPG_RESTORE = ConfigurationManager.AppSettings["PathToPG_RESTOREv11"];
        private string pathToPG_DUMP = ConfigurationManager.AppSettings["PathToPG_DUMPv11"];
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Select saving folder with backups
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenBut_Click(object sender, EventArgs e)
        {
            string newDirectoryPath = string.Empty;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            else
            {
                newDirectoryPath = folderBrowserDialog1.SelectedPath;
            }
            path_textBox.Text = newDirectoryPath;
        }

        private void BackupBut_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(path_textBox.Text))
            {
                MessageBox.Show("Выберите папку для сохранения!");
                return;
            }
            
            var outputFileWithPg_DUMP = path_textBox.Text;
            var host = ConfigurationManager.AppSettings["host"];
            var port  = ConfigurationManager.AppSettings["port"];
            var user = ConfigurationManager.AppSettings["user"];
            var dbname = ConfigurationManager.AppSettings["dbname"];
            var password = ConfigurationManager.AppSettings["password"];
            Pg_dump_sql(
                pathToPG_DUMP,
                outputFileWithPg_DUMP,
                host,
                port,
                dbname,
                user,
                password);
        }

        /// <summary>
        /// <para>Using pg_dump makes dump in sql with inserts commands and save in selected dir.</para>
        /// File log.txt is created to watch errors.If it is empty - everything is ok.
        /// </summary>
        /// <param name="pathToPG_DUMP">Полный путь до pg_dump.exe</param>
        /// <param name="outFile"></param>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="database"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        private void Pg_dump_sql(
            string pathToPG_DUMP,
            string outFile,
            string host,
            string port,
            string database,
            string user,
            string password
            )
        {
            try
            {
                outFile = Path.Combine(outFile, $"{DateTime.Now.ToString("yyyy.MM.dd")}_wiki.sql");
                ProcessStartInfo startinfo = new ProcessStartInfo
                {
                    FileName = pathToPG_DUMP,
                    Arguments = $" --inserts --dbname=postgresql://{user}:{password}@{host}:{port}/{database} -f {outFile} ",
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(startinfo))
                {
                    using (StreamReader reader = process.StandardError)
                    {
                        StreamWriter sw = new StreamWriter(Path.Combine(path_textBox.Text, "log.txt"));
                        sw.WriteLine(reader.ReadToEnd());
                        sw.Close();
                    }
                }
                MessageBox.Show("Success");
            }
            catch(Exception e)
            {
                MessageBox.Show
                    (e.Message);
            }
        }

        /// <summary>
        /// <para>Using pg_dump makes dump in dump ext with inserts commands and save in selected dir.</para>
        /// File log.txt is created to watch errors.If it is empty - everything is ok.
        /// </summary>
        /// <param name="pathToPG_DUMP">Полный путь до pg_dump.exe</param>
        /// <param name="outFile"></param>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="database"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        private void Pg_dump(
            string pathToPG_DUMP,
            string outFile,
            string host,
            string port,
            string database,
            string user,
            string password
            )
        {
            try
            {
                outFile = Path.Combine(outFile, $"{DateTime.Now.ToString("yyyy.MM.dd")}_wiki.dump");
                ProcessStartInfo startinfo = new ProcessStartInfo
                {
                    FileName = pathToPG_DUMP,
                    Arguments = $" --format=custom --dbname=postgresql://{user}:{password}@{host}:{port}/{database} -f {outFile} ",
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(startinfo))
                {
                    using (StreamReader reader = process.StandardError)
                    {
                        StreamWriter sw = new StreamWriter(Path.Combine(path_textBox.Text, "log.txt"));
                        sw.WriteLine(reader.ReadToEnd());
                        sw.Close();
                    }
                }
                MessageBox.Show("Success");
            }
            catch (Exception e)
            {
                MessageBox.Show
                    (e.Message);
            }
        }
        
        private void RestoreBut_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Dump files (*.dump) | *.dump|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // get selected file
            string dumpFile = openFileDialog1.FileName;
            if (string.IsNullOrEmpty(dumpFile))
                return;
            var host = ConfigurationManager.AppSettings["host"];
            var port = ConfigurationManager.AppSettings["port"];
            var user = ConfigurationManager.AppSettings["user"];
            var dbname = ConfigurationManager.AppSettings["dbname"];
            var password = ConfigurationManager.AppSettings["password"];
            RestoreDump(pathToPG_RESTORE,dumpFile,host,port, dbname, user,password);
        }

        /// <summary>
        /// Restore db from dump file with key -c (clears old db) 
        /// </summary>
        /// <param name="PathToPG_RESTORE"></param>
        /// <param name="dumpFile"></param>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="dbname"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        private void RestoreDump(
            string PathToPG_RESTORE,
            string dumpFile,
            string host,
            string port,
            string dbname,
            string user,
            string password)
        {
            try
            {
                ProcessStartInfo startinfo = new ProcessStartInfo
                {
                    FileName = PathToPG_RESTORE,
                    Arguments = $" -c --dbname=postgresql://{user}:{password}@{host}:{port}/{dbname} {dumpFile}",
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(startinfo))
                {
                    using (StreamReader reader = process.StandardError)
                    {
                        StreamWriter sw = new StreamWriter(Path.Combine(path_textBox.Text, "log.txt"));
                        sw.WriteLine(reader.ReadToEnd());
                        sw.Close();
                    }
                }
                MessageBox.Show("Success");
            }
            catch (Exception e)
            {
                MessageBox.Show
                    (e.Message);
            }
        }

        private void Backup_dumpBut_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(path_textBox.Text))
            {
                MessageBox.Show("Выберите папку для сохранения!");
                return;
            }
            var outputFileWithPg_DUMP = path_textBox.Text;
            var host = ConfigurationManager.AppSettings["host"];
            var port = ConfigurationManager.AppSettings["port"];
            var user = ConfigurationManager.AppSettings["user"];
            var dbname = ConfigurationManager.AppSettings["dbname"];
            var password = ConfigurationManager.AppSettings["password"];
            Pg_dump(
                pathToPG_DUMP,
                outputFileWithPg_DUMP,
                host,
                port,
                dbname,
                user,
                password);
        }
    }
}
