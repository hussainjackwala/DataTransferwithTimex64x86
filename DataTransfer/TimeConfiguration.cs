using System;


using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
namespace DataTransfer
{
    public partial class TimeConfiguration : Form
    {
        public TimeConfiguration()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            try

            {
                if (Validation() == true)
                {

                    DataTable table = new DataTable();
                    table.TableName = "TimeConfig";
                    table.Columns.Add("TminMinutes");
                   

                    DataRow NewRow = table.NewRow();
                    NewRow["TminMinutes"] = txtTime.Text.Trim();
                   

                    table.Rows.Add(NewRow);

                    string path = Application.StartupPath + @"\TimeConfig.xml";
                    table.WriteXml(path, true);


                    table.Dispose();
                    MessageBox.Show("Time configuration has been done successfully");

                

                  




                }






            }

            catch (Exception ex)
            {
                


                MessageBox.Show(ex.Message.ToString(), "TimeConfiguration", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {

               



            }
        }

        private bool Validation()
        {
            bool IsOk = true;
            if (string.IsNullOrEmpty(txtTime.Text.Trim()))
            {

                IsOk = false;
                MessageBox.Show("Please enter Time in Minutes");

            }
            else
            {
                string s = txtTime.Text.Trim();
                string strPattern = "^[0-9]+$";
               
                if (Regex.IsMatch(s, strPattern) == false)
                {
                    MessageBox.Show("Numeric value is allowed");

                    txtTime.Focus();
                    IsOk = false;


                }

            }


            return IsOk;


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimeConfiguration_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\TimeConfig.xml";
            if (File.Exists(path) == true)
            {
                DataTable table = new DataTable();
                table.TableName = "TimeConfig";
                table.Columns.Add("TminMinutes");

                table.ReadXml(path);
                if (table.Rows.Count > 0)
                {
                  
                        txtTime.Text = table.Rows[0]["TminMinutes"].ToString();
                       
                    
                }
                table.Dispose();

            }
        }
    }
}
