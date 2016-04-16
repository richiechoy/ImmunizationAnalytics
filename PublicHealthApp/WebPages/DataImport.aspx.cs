using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using PublicHealthApp.Models;
using Microsoft.VisualBasic.FileIO;

namespace PublicHealthApp.WebPages
{
    public partial class DataImport : System.Web.UI.Page
    {
        Dictionary<string, string> targetVaccines;
        protected void Page_Load(object sender, EventArgs e)
        {
            // vaccine type, default vaccine code
            targetVaccines = new Dictionary<string, string>() {
                { "FLU", "FL" },
                { "DTP", "01" },
                { "H1N", "1L" },
                { "HEPA", "HA" },
                { "HEPB", "HB" },
                { "HIB", "HI" },
                { "MMR", "MM" },
                { "MP", "MP" },
                { "MPRB", "MB" },
                { "PCV", "72" },
                { "POLIO", "22" },
                { "RB", "RB" },
                { "ROT", "RO" },
                { "VRC", "VA" },
            };
            /*targetVaccines = new Dictionary<string, string>() {
                { "FL", "DFLU{0}" },
                { "01", "DDTP{0}" },
                { "1L", "DH1N{0}" },
                { "HA", "DHEPA{0}" },
                { "HB", "DHEPB{0}" },
                { "HI", "DHIB{0}" },
                { "MM", "DMMR{0}" },
                { "MP", "DMP{0}" },
                { "MB", "DMPRB{0}" },
                { "72", "DPCV{0}" },
                { "22", "DPOLIO{0}" },
                { "RB", "DRB{0}" },
                { "RO", "DROT{0}" },
                { "VA", "DVRC{0}" },
            };*/
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            int rowStart = Int32.Parse(txtRowStart.Text);
            int rowLimit = Int32.Parse(txtRowLimit.Text);
            loadFromFile(txtFilePath.Text, rowStart, rowLimit);

        }

        private void loadFromFile(String filePath, int rowStart, int rowLimit)
        {
            DataModel.beginTransaction();
            using (TextFieldParser file = new TextFieldParser(filePath))
            {
                int processedCount = 0;
                file.TextFieldType = FieldType.Delimited;
                file.Delimiters = new String[] { "\t" };
                string[] headers = file.ReadFields();
                while (!file.EndOfData && (rowLimit == 0 || processedCount < rowLimit))
                {
                    if (file.LineNumber >= rowStart)
                    {
                        // process row
                        processedCount++;
                        string[] cols = file.ReadFields();
                        Dictionary<string, string> rowValues = new Dictionary<string, string>();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            rowValues[headers[i]] = cols[i];
                        }

                        // build patient data
                        Patient patient = new Patient();
                        patient.Id = rowValues["YEAR"] + rowValues["SEQNUMC"];
                        patient.Age = rowValues["AGEGRP"];
                        patient.State = rowValues["STATE"];
                        patient.Year = Int32.Parse(rowValues["YEAR"]);
                        patient.MotherMaritalStatus = rowValues["MARITAL2"];
                        patient.Poverty = rowValues["INCPOV1"];
                        patient.Race = rowValues["RACEETHK"];
                        patient.Gender = rowValues["SEX"];

                        if (DataModel.GetItem(patient, patient.Id) == null)

                        // if (DataModel.GetPatient(patient.Id) == null)
                        {
                            //DataModel.AddPatient(patient);
                            DataModel.AddItem(patient);
                            // get vaccinations

                            foreach (KeyValuePair<string, string> entry in targetVaccines)
                            {
                                addImmunizationsForVaccine(rowValues, patient.Id, entry.Key, entry.Value);
                            }
                        }

                        if (processedCount % 1000 == 0)
                        {
                            // sync with data base after every 1000 to prevent memory overflow
                            DataModel.commitTransaction();
                            DataModel.beginTransaction();
                        }
                    }
                    else
                    {
                        file.ReadLine();
                    }
                }
                lblOutput.Text = "Import complete, processed " + processedCount + " patients";
            }
            DataModel.commitTransaction();
        
        }

        private void addImmunizationsForVaccine(Dictionary<string, string> rowValues, string patientId, string vaccineColumn, string defaultCode)
        {
            for (int i = 1; i <= 9; i++)
            {
                string column = "D" + vaccineColumn + i;
                int age;
                try
                {                    
                    if (Int32.TryParse(rowValues[column], out age))
                    {
                        // try to get code, if not available, fall back to default
                        string vaccineCode;
                        try
                        {
                            vaccineCode = rowValues["X" + vaccineColumn + "TY" + i];
                        } catch(KeyNotFoundException)
                        {
                            vaccineCode = defaultCode;
                        }
                        addImmunization(patientId, vaccineCode);
                    }
                }
                catch (KeyNotFoundException)
                {
                    break;
                }
            }
        }

        private void addImmunization(string patientId, string vaccineId)
        {
            Immunization immunization = new Immunization()
            {
                VaccineId = vaccineId,
                PatientId = patientId
            };
            //DataModel.AddImmunization(immunization);
            DataModel.AddItem(immunization);
        }
    }
}