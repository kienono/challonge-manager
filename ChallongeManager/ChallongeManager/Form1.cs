using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ChallongeManager.Forms;
using System.IO;
using System.Collections;

namespace ChallongeManager
{
    public partial class Form1 : Form
    {
        private FormSettings _settings = new FormSettings();
        private ChallongeInterface _challongeInterface = new ChallongeInterface();
        private ListViewColumnSorter lvwColumnSorter;
        private ListViewColumnSorter lvwStatColumnSorter;
        private Color _oddLineColor = Color.White;
        private Color _evenLineColor = Color.LightGoldenrodYellow;
        private FormEventManager _eventManager = new FormEventManager();
        private FormResultTableGenerator _resultGenerator = new FormResultTableGenerator();

        public Form1()
        {
            InitializeComponent();
            _challongeInterface.Initialize();
            listViewPoints.Columns.Add("Joueur", -2);
            listViewStats.Columns.Add("Event", -2);

            // add date column on stat table
            listViewStats.Columns.Add("Date", -2);

            for (int i = 0; i < _challongeInterface.GameList.Count; i++)
            {
                listViewPoints.Columns.Add(_challongeInterface.GameList[i].Name, -2);
                listViewPoints.Columns[listViewPoints.Columns.Count - 1].Tag = "Numeric";

                listViewStats.Columns.Add(_challongeInterface.GameList[i].Name, -2);
                listViewStats.Columns[listViewStats.Columns.Count - 1].Tag = "Numeric";
            }
            // add total column
            listViewPoints.Columns.Add("Total", -2);
            listViewPoints.Columns[listViewPoints.Columns.Count - 1].Tag = "Numeric";            

            lvwColumnSorter = new ListViewColumnSorter();
            listViewPoints.ListViewItemSorter = lvwColumnSorter;

            lvwStatColumnSorter = new ListViewColumnSorter();
            listViewStats.ListViewItemSorter = lvwStatColumnSorter;

            // Link to event manager events
            _eventManager.VisibleChanged += _eventManager_VisibleChanged;

            // Link to result table generation
            _resultGenerator.Interface = _challongeInterface;
            _resultGenerator.VisibleChanged += _resultGenerator_VisibleChanged;
        }

        private void _resultGenerator_VisibleChanged(object sender, EventArgs e)
        {
            resultTableGenerationToolStripMenuItem.Checked = _resultGenerator.Visible;
        }

        private void _eventManager_VisibleChanged(object sender, EventArgs e)
        {
            eventManagerToolStripMenuItem.Checked = _eventManager.Visible;
        }

        private void backgroundWorkerChallongeRequest_DoWork(object sender, DoWorkEventArgs e)
        {
            _challongeInterface.GetTournaments(dateTimePickerRequestPeriodStart.Value, dateTimePickerRequestPeriodEnd.Value);
        }

        private void backgroundWorkerChallongeRequest_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarDataRequest.Style = ProgressBarStyle.Continuous;
            progressBarDataRequest.Value = 100;
            // Request completed, build data report
            checkedListBoxTournois.Items.Clear();
            for (int i = 0; i < _challongeInterface.TournamentsList.Count; i++)
            {
                checkedListBoxTournois.Items.Add(_challongeInterface.TournamentsList[i], true);
            }

            FillResultTable();
            FillStatsTable();
            UpdateLineColor();
        }

        private void buttonDataRequest_Click(object sender, EventArgs e)
        {
            progressBarDataRequest.Value = 0;
            progressBarDataRequest.Style = ProgressBarStyle.Marquee;            
            backgroundWorkerChallongeRequest.RunWorkerAsync();
        }

        private void FillResultTable()
        {
            listViewPoints.Items.Clear();
            List<wr_Tournament> consideredTournaments = new List<wr_Tournament>();
            for (int i = 0; i < checkedListBoxTournois.CheckedItems.Count; i++)
            {
                consideredTournaments.Add((wr_Tournament)checkedListBoxTournois.CheckedItems[i]);
            }
            List<Player> playerList = new List<Player>();
            _challongeInterface.GetResults(consideredTournaments, out playerList);
            
            for (int i = 0; i < playerList.Count; i++)
            {
                string[] saLvwItem = new string[listViewPoints.Columns.Count];

                for (int k = 0; k < listViewPoints.Columns.Count - 1; k++)
                {
                    int points = 0;
                    if (k == 0)
                    {
                        saLvwItem[k] = playerList[i].Name;
                    }
                    else if (playerList[i].GetPoints(listViewPoints.Columns[k].Text, out points))
                    {
                        saLvwItem[k] = points.ToString();
                    }
                    else
                    {
                        saLvwItem[k] = "";
                    }
                }
                // Set total
                saLvwItem[listViewPoints.Columns.Count - 1] = playerList[i].GetTotalPoints().ToString();

                ListViewItem lvi = new ListViewItem(saLvwItem);
                listViewPoints.Items.Add(lvi);                
            }
        }

        private void FillStatsTable()
        {
            listViewStats.Items.Clear();
            List<wr_Tournament> consideredTournaments = new List<wr_Tournament>();
            for (int i = 0; i < checkedListBoxTournois.CheckedItems.Count; i++)
            {
                consideredTournaments.Add((wr_Tournament)checkedListBoxTournois.CheckedItems[i]);
            }
            List<Event> eventList = new List<Event>();
            _challongeInterface.GetEventStats(consideredTournaments, out eventList);

            for (int i = 0; i < eventList.Count; i++)
            {
                string[] saLvwItem = new string[listViewStats.Columns.Count];              

                for (int k = 0; k < listViewStats.Columns.Count; k++)
                {
                    int attendants = 0;
                    if (k == 0)
                    {
                        saLvwItem[k] = eventList[i].Name;
                    }
                    else if (k == 1)
                    {
                        // Set Date
                        saLvwItem[k] = eventList[i].Date.ToString("yyyy/MM/dd");
                    }
                    else if (eventList[i].GetAttendants(listViewStats.Columns[k].Text, out attendants))
                    {
                        saLvwItem[k] = attendants.ToString();
                    }
                    else
                    {
                        saLvwItem[k] = "";
                    }
                }               

                ListViewItem lvi = new ListViewItem(saLvwItem);
                listViewStats.Items.Add(lvi);
            }
        }
        private void UpdateLineColor()
        {
            for (int i = 0; i < listViewPoints.Items.Count; i++)
            {
                if (listViewPoints.Items[i].Index % 2 == 0)
                {
                    listViewPoints.Items[i].BackColor = _oddLineColor;
                }
                else
                {
                    listViewPoints.Items[i].BackColor = _evenLineColor;
                }
            }
            for (int i = 0; i < listViewStats.Items.Count; i++)
            {
                if (listViewStats.Items[i].Index % 2 == 0)
                {
                    listViewStats.Items[i].BackColor = _oddLineColor;
                }
                else
                {
                    listViewStats.Items[i].BackColor = _evenLineColor;
                }
            }
        }

        private void buttonExtractToCSV_Click(object sender, EventArgs e)
        {
            if (saveFileDialogCSV.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialogCSV.FileName))
                {
                    string Columns = "";
                    for (int j = 0; j < listViewPoints.Columns.Count; j++)
                    {
                        Columns += listViewPoints.Columns[j].Text + ";";
                    }
                    sw.WriteLine(Columns);

                    for (int i = 0; i < listViewPoints.Items.Count; i++)
                    {
                        string lineContent = "";
                        for (int j = 0; j < listViewPoints.Items[i].SubItems.Count; j++)
                        {
                            lineContent += listViewPoints.Items[i].SubItems[j].Text + ";";
                        }
                        sw.WriteLine(lineContent);
                    }
                }
            }
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void parametresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _settings.ShowDialog();
        }

        private void listViewPoints_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Déterminer si la colonne sélectionnée est déjà la colonne triée.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Inverser le sens de tri en cours pour cette colonne.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Définir le numéro de colonne à trier ; par défaut sur croissant.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Procéder au tri avec les nouvelles options.
            listViewPoints.Sort();

            UpdateLineColor();
        }

        private void checkedListBoxTournois_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxTournamentDetails.Text = ((wr_Tournament)checkedListBoxTournois.SelectedItem).GetTournamentDetails();
        }

        private void buttonUpdateTable_Click(object sender, EventArgs e)
        {
            FillResultTable();
            UpdateLineColor();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = string.Format("{0} {1}", Application.ProductName, Application.ProductVersion);
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            string clipboardContent = "";
            string Columns = "";
            for (int j = 0; j < listViewPoints.Columns.Count; j++)
            {
                Columns += listViewPoints.Columns[j].Text + "\t";
            }
            clipboardContent += Columns;
            clipboardContent += Environment.NewLine;

            for (int i = 0; i < listViewPoints.Items.Count; i++)
            {
                string lineContent = "";
                for (int j = 0; j < listViewPoints.Items[i].SubItems.Count; j++)
                {
                    lineContent += listViewPoints.Items[i].SubItems[j].Text + "\t";
                }
                clipboardContent += lineContent;
                clipboardContent += Environment.NewLine;                
            }

            Clipboard.SetText(clipboardContent);
        }

        private void eventManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_eventManager.Visible)
            {
                _eventManager.Hide();
            }
            else
            {
                _eventManager.Show();
            }
        }

        private void resultTableGenerationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_resultGenerator.Visible)
            {
                _resultGenerator.Hide();
            }
            else
            {
                _resultGenerator.Show();
            }
        }

        private void buttonUpdateStats_Click(object sender, EventArgs e)
        {
            FillStatsTable();
            UpdateLineColor();
        }

        private void listViewStats_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Déterminer si la colonne sélectionnée est déjà la colonne triée.
            if (e.Column == lvwStatColumnSorter.SortColumn)
            {
                // Inverser le sens de tri en cours pour cette colonne.
                if (lvwStatColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwStatColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwStatColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Définir le numéro de colonne à trier ; par défaut sur croissant.
                lvwStatColumnSorter.SortColumn = e.Column;
                lvwStatColumnSorter.Order = SortOrder.Ascending;
            }

            // Procéder au tri avec les nouvelles options.
            listViewStats.Sort();

            UpdateLineColor();
        }

        private void buttonExportStatsToCSV_Click(object sender, EventArgs e)
        {
            if (saveFileDialogCSV.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialogCSV.FileName))
                {
                    string Columns = "";
                    for (int j = 0; j < listViewStats.Columns.Count; j++)
                    {
                        Columns += listViewStats.Columns[j].Text + ";";
                    }
                    sw.WriteLine(Columns);

                    for (int i = 0; i < listViewStats.Items.Count; i++)
                    {
                        string lineContent = "";
                        for (int j = 0; j < listViewStats.Items[i].SubItems.Count; j++)
                        {
                            lineContent += listViewStats.Items[i].SubItems[j].Text + ";";
                        }
                        sw.WriteLine(lineContent);
                    }
                }
            }
        }

        private void buttonCopyStats_Click(object sender, EventArgs e)
        {
            string clipboardContent = "";
            string Columns = "";
            for (int j = 0; j < listViewStats.Columns.Count; j++)
            {
                Columns += listViewStats.Columns[j].Text + "\t";
            }
            clipboardContent += Columns;
            clipboardContent += Environment.NewLine;

            for (int i = 0; i < listViewStats.Items.Count; i++)
            {
                string lineContent = "";
                for (int j = 0; j < listViewStats.Items[i].SubItems.Count; j++)
                {
                    lineContent += listViewStats.Items[i].SubItems[j].Text + "\t";
                }
                clipboardContent += lineContent;
                clipboardContent += Environment.NewLine;
            }

            Clipboard.SetText(clipboardContent);
        }
    }

    /// <summary>
    /// Cette classe est une implémentation de l'interface 'IComparer'.
    /// </summary>
    public class ListViewColumnSorter : IComparer
    {
        /// <summary>
        /// Spécifie la colonne à trier
        /// </summary>
        private int ColumnToSort;
        /// <summary>
        /// Spécifie l'ordre de tri (en d'autres termes 'Croissant').
        /// </summary>
        private SortOrder OrderOfSort;
        /// <summary>
        /// Objet de comparaison ne respectant pas les majuscules et minuscules
        /// </summary>
        private CaseInsensitiveComparer ObjectCompare;

        /// <summary>
        /// Constructeur de classe.  Initializes various elements
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialise la colonne sur '0'
            ColumnToSort = 0;

            // Initialise l'ordre de tri sur 'aucun'
            OrderOfSort = SortOrder.None;

            // Initialise l'objet CaseInsensitiveComparer
            ObjectCompare = new CaseInsensitiveComparer();
        }

        public int Compare(object x, object y) // IComparer Member
        {
            if (!(x is ListViewItem))
                return (0);
            if (!(y is ListViewItem))
                return (0);

            ListViewItem l1 = (ListViewItem)x;
            ListViewItem l2 = (ListViewItem)y;

            if (l1.ListView.Columns[ColumnToSort].Tag == null)
            {
                l1.ListView.Columns[ColumnToSort].Tag = "Text";
            }

            if (l1.ListView.Columns[ColumnToSort].Tag.ToString() == "Numeric")
            {
                float fl1 = (l1.SubItems[ColumnToSort].Text == "") ? 0 : float.Parse(l1.SubItems[ColumnToSort].Text);
                float fl2 = (l2.SubItems[ColumnToSort].Text == "") ? 0 : float.Parse(l2.SubItems[ColumnToSort].Text);

                if (Order == SortOrder.Ascending)
                {
                    return fl1.CompareTo(fl2);
                }
                else
                {
                    return fl2.CompareTo(fl1);
                }
            }
            else
            {
                string str1 = l1.SubItems[ColumnToSort].Text;
                string str2 = l2.SubItems[ColumnToSort].Text;

                if (Order == SortOrder.Ascending)
                {
                    return str1.CompareTo(str2);
                }
                else
                {
                    return str2.CompareTo(str1);
                }
            }
        }

        /// <summary>
        /// Obtient ou définit le numéro de la colonne à laquelle appliquer l'opération de tri (par défaut sur '0').
        /// </summary>
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        /// <summary>
        /// Obtient ou définit l'ordre de tri à appliquer (par exemple, 'croissant' ou 'décroissant').
        /// </summary>
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }

    }
}