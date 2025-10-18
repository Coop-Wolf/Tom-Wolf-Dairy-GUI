using BreedingReportGUI;
using Microsoft.VisualBasic; // for InputBox
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Printing;

// Main form class
public class Form1 : Form
{
    private List<Cow> cows = new List<Cow>();
    private DataGridView dataGridView1;
    private Button btnLoadFile;
    private Button button1;
    private Button button2;
    private Button button3;
    private Button button4;
    private Button button5;
    private Button btnAddCow;

    // Constructor
    public Form1()
    {

        InitializeComponent();

        // Set form size
        this.ClientSize = new Size(1000, 700);
        this.MinimumSize = new Size(800, 600);
        this.WindowState = FormWindowState.Normal; // or Maximized

        // Make DataGridView resize with form
        dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

        // Keep buttons at bottom left
        btnLoadFile.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnAddCow.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        button5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

        InitializeDataGridView();
    }

    // Initialize DataGridView columns
    private void InitializeDataGridView()
    {
        dataGridView1.ColumnCount = 7;
        dataGridView1.Columns[0].Name = "CowID";
        dataGridView1.Columns[1].Name = "Breed Date";
        dataGridView1.Columns[2].Name = "Dry Date";
        dataGridView1.Columns[3].Name = "Bring In Date";
        dataGridView1.Columns[4].Name = "Calf Date";
        dataGridView1.Columns[5].Name = "Sire";
        dataGridView1.Columns[6].Name = "Status";
    }

    // Load cows from CSV file
    private List<Cow> LoadCows(string filename)
    {
        var list = new List<Cow>();
        foreach (var line in File.ReadAllLines(filename))
        {
            var parts = line.Split(',');
            if (parts.Length >= 3 &&
                int.TryParse(parts[0], out int cowID) &&
                DateTime.TryParse(parts[1], out DateTime breedDate))
            {
                list.Add(new Cow { CowID = cowID, BreedDate = breedDate, Sire = parts[2] });
            }
        }
        return list;
    }

    // Display cows in DataGridView
    private void DisplayCows()
    {
        dataGridView1.Rows.Clear();
        foreach (var cow in cows)
        {
            int rowIndex = dataGridView1.Rows.Add(
                cow.CowID,
                cow.BreedDate.ToString("yyyy-MM-dd"),
                cow.DryDate.ToString("yyyy-MM-dd"),
                cow.BringInDate.ToString("yyyy-MM-dd"),
                cow.CalfDate.ToString("yyyy-MM-dd"),
                cow.Sire,
                cow.IsOld ? "Old" : "New"
            );

            var row = dataGridView1.Rows[rowIndex];
            row.DefaultCellStyle.BackColor = cow.IsOld ? Color.LightCoral : Color.LightGreen;
        }
    }

    // Prompt helper
    public static string Prompt(string text, string caption)
    {
        Form prompt = new Form()
        {
            Width = 300,
            Height = 150,
            FormBorderStyle = FormBorderStyle.Sizable,
            Text = caption,
            StartPosition = FormStartPosition.CenterScreen
        };
        Label textLabel = new Label() { Left = 10, Top = 20, Text = text, AutoSize = true };
        TextBox textBox = new TextBox() { Left = 10, Top = 50, Width = 260 };
        Button confirmation = new Button() { Text = "Ok", Left = 200, Width = 70, Top = 80, DialogResult = DialogResult.OK };
        confirmation.Click += (sender, e) => { prompt.Close(); };
        prompt.Controls.Add(textBox);
        prompt.Controls.Add(confirmation);
        prompt.Controls.Add(textLabel);
        prompt.AcceptButton = confirmation;

        return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
    }

    // Designer generated code
    private void InitializeComponent()
    {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.btnAddCow = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(600, 300);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(12, 320);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(75, 23);
            this.btnLoadFile.TabIndex = 1;
            this.btnLoadFile.Text = "Load File";
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click_1);
            // 
            // btnAddCow
            // 
            this.btnAddCow.Location = new System.Drawing.Point(100, 320);
            this.btnAddCow.Name = "btnAddCow";
            this.btnAddCow.Size = new System.Drawing.Size(75, 23);
            this.btnAddCow.TabIndex = 2;
            this.btnAddCow.Text = "Add Cow";
            this.btnAddCow.Click += new System.EventHandler(this.btnAddCow_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 349);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Help/Info";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.help_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(100, 349);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Credits";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.credits_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(181, 320);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Save File";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.savefile_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(262, 320);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Print";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.print_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(181, 349);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "Exit";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.exit_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(658, 384);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.btnAddCow);
            this.Name = "Form1";
            this.Text = "Breeding Report";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

    }

    // Help/Info button handler
    private void help_Click(object sender, EventArgs e)
    {
        MessageBox.Show("This program loads a data file containing a list" +
                        "of cow information in the form on cowID, when the" +
                        "cow was inpregnated, and who the sire is. " +
                        "The program will then calculate when the cow is" +
                        "expected to go dry, is needed to come in, and around" +
                        "the time she will have her baby.\n\nButtons:\nLoad File -" +
                        " uploads a file of cow data ([CowID], [BreedDate], [Sire]).\nAdd Cow" +
                        "- manually add cow information.\nSave File - Saves the file as a CSV." +
                        "\nPrint - Prints information.\nCredits - Display credits.\nExit - Terminate" +
                        " program.",
                        "Help/Info",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
    }

    // Load File button handler
    private void btnLoadFile_Click_1(object sender, EventArgs e)
    {
        using (OpenFileDialog ofd = new OpenFileDialog())
        {
            ofd.Filter = "CSV Files|*.csv|All Files|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                cows.AddRange(LoadCows(ofd.FileName));
                DisplayCows();
            }
        }
    }

    // Add Cow button handler
    private void btnAddCow_Click(object sender, EventArgs e)
    {
        string cowIDStr = Prompt("Enter Cow ID:", "Add Cow");
        string breedDateStr = Prompt("Enter Breed Date (YYYY-MM-DD):", "Add Cow");
        string sire = Prompt("Enter Sire:", "Add Cow");

        if (int.TryParse(cowIDStr, out int cowID) &&
            DateTime.TryParse(breedDateStr, out DateTime breedDate))
        {
            cows.Add(new Cow { CowID = cowID, BreedDate = breedDate, Sire = sire });
            DisplayCows();
        }
        else
        {
            MessageBox.Show("Invalid input. Cow not added.");
        }
    }

    // Credits button handler
    private void credits_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Cooper Wolf - Programmer\n" +
                        "Tom Wolf - Consultant/Client",
                        "Credits",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
    }

    // Save File button handler
    private void savefile_Click(object sender, EventArgs e)
    {
        using (SaveFileDialog sfd = new SaveFileDialog())
        {
            sfd.Filter = "CSV Files|*.csv";
            sfd.Title = "Save Cow Data";
            sfd.FileName = "CowData.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    // Write headers
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        sw.Write(dataGridView1.Columns[i].Name);
                        if (i < dataGridView1.Columns.Count - 1)
                            sw.Write(",");
                    }
                    sw.WriteLine();

                    // Write rows
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            sw.Write(row.Cells[i].Value?.ToString() ?? "");
                            if (i < row.Cells.Count - 1)
                                sw.Write(",");
                        }
                        sw.WriteLine();
                    }
                }
            }
        }
    }

    // Print button handler
    private void print_Click(object sender, EventArgs e)
    {
        PrintDocument pd = new PrintDocument();
        pd.PrintPage += Pd_PrintPage;

        PrintPreviewDialog preview = new PrintPreviewDialog();
        preview.Document = pd;
        preview.ShowDialog();
    }

    // Print page helper
    private void Pd_PrintPage(object sender, PrintPageEventArgs e)
    {
        int startX = 20;
        int startY = 20;
        int rowHeight = 20;
        Font font = new Font("Arial", 10);

        // Print headers
        int x = startX;
        for (int i = 0; i < dataGridView1.Columns.Count; i++)
        {
            e.Graphics.DrawString(dataGridView1.Columns[i].HeaderText, font, Brushes.Black, x, startY);
            x += 120; // column width in pixels
        }

        startY += rowHeight;

        // Print rows
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            x = startX;
            foreach (DataGridViewCell cell in row.Cells)
            {
                e.Graphics.DrawString(cell.Value?.ToString() ?? "", font, Brushes.Black, x, startY);
                x += 120; // same column width
            }
            startY += rowHeight;
        }
    }

    // Exit button handler
    private void exit_Click(object sender, EventArgs e)
    {
        // Close the application
        Application.Exit();
    }
}