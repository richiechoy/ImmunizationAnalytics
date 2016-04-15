using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.Highcharts.Options;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Enums;

using PublicHealthApp.Models;

namespace PublicHealthApp.WebPages
{
    public partial class VaccinationsPage : System.Web.UI.Page{

        Object[] chartValues;
        String[] xValues;
        String chartName = "Counts for";
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //do the data binding
                LoadVaccineList();
                LoadStateList();
                LoadYearList();
                LoadAgeList();
                LoadGenderList();
                LoadPovertyList();
                LoadMaritalList();
                LoadRaceList();
            }
            else
            {
                string state = statemenu.SelectedValue;
                string vaccine = vaccinemenu.SelectedItem.Text;
                string age = agemenu.SelectedValue;
                string gender = gendermenu.SelectedValue;
                string pstat = povertymenu.SelectedValue;
                string mstat = maritalmenu.SelectedValue;
                string race = racemenu.SelectedValue;
                string year = yearmenu.SelectedValue;
                
                QueryFilter filter = new QueryFilter() {
                    State = statemenu.SelectedValue,
                    VaccineType = vaccinemenu.SelectedValue,
                    Age = agemenu.SelectedValue,
                    Gender = gendermenu.SelectedValue,
                    PovertyStatus = povertymenu.SelectedValue,
                    MaritalStatus = maritalmenu.SelectedValue,
                    Race = racemenu.SelectedValue,
                    Year = Convert.ToInt32(yearmenu.SelectedValue),
                };

                dt = DataModel.GetQueryResults(filter);
                placeHolderGrid.DataSource = dt;
                placeHolderGrid.DataBind();
                if (vaccine == "Choose a vaccine:")
                {
                    vaccine = "ALL VACCINES";
                }
                if (dt.Rows.Count == 0)
                {
                    chartName = "No counts for : " + vaccine;
                }
                else
                {
                    chartName = chartName + " : " + vaccine;
                }
                createDAO();
                Render_Chart();
            }

        }

        private void Render_Chart()
        {
            int chkval = 1;
            switch (chkval)
            {
                case 1: //Display bar chart
                    DisplayBar();
                    break;
                case 2:  //Display line chart
                    DisplayLine();
                    break;
            }
    }




    private void DisplayLine()
    {
 	            DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart")

                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line })
                .SetTitle(new Title
                {
                    Text = "CS6400 Population Health Application - Immunization",
                    X = -20
                })
                .SetSubtitle(new Subtitle
                {
                    Text = "Source: CDC, NCRID and NCHS (2015), 2010 - 2014 National Immunization Survey",
                    X = -20
                })
                .SetXAxis(new XAxis
                {

                    Categories = xValues

                })
                .SetSeries(new[]
                            {
                                new Series 
                                {   Name = chartName, 
                                    Data = new Data(chartValues),
                                    //Color = System.Drawing.ColorTranslator.FromHtml("#443850")
                                    Color = System.Drawing.ColorTranslator.FromHtml("#665478")
                                },  
                            });

                ltrChart.Text = chart.ToHtmlString();
        } 

        private void DisplayBar()
        {
 	        DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart")

                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Bar })
                .SetTitle(new Title
                {
                    Text = "CS6400 Population Health Application - Immunization",
                    X = -20
                })
                .SetSubtitle(new Subtitle
                {
                    Text = "Source: CDC, NCRID and NCHS (2015), 2010 - 2014 National Immunization Survey",
                    X = -20
                })
                .SetXAxis(new XAxis
                {
                    Categories = xValues

                })
                .SetSeries(new[]
                            {
                                new Series 
                                {   Name = chartName, 
                                    Data = new Data(chartValues),
                                    //Color = System.Drawing.ColorTranslator.FromHtml("#443850")
                                    Color = System.Drawing.ColorTranslator.FromHtml("#665478")
                                },  
                            });

            ltrChart.Text = chart.ToHtmlString();
        } 

        private void createDAO()
        {
            int i = Convert.ToInt16(dt.Rows.Count);
            if (i == 0)
            {
                i = 5;
                chartValues = new Object[i];
                xValues = new[] { "2010", "2011", "2012", "2013", "2014" };
            }
            else
            {
                chartValues = new Object[i];
                xValues = new String[i];

                int counter = 0;
                foreach (DataColumn col in dt.Columns)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (counter < dt.Rows.Count)
                        {

                            //System.Diagnostics.Debug.WriteLine(row["Period"].ToString());
                            //System.Diagnostics.Debug.WriteLine(row["cnts"].ToString());
                            //System.Diagnostics.Debug.WriteLine(row[0].ToString());
                            chartValues[counter] = dt.Rows[counter][2];
                            xValues[counter] = Convert.ToString(dt.Rows[counter][1]);
                            counter++;
                        }

                    }
                }
            }
        }

        private void LoadRaceList()
        {
            List<Code> vaccineList = DataModel.GetUniqueCodeList("RACE");
            racemenu.DataSource = vaccineList;
            racemenu.DataTextField = "Name";
            racemenu.DataValueField = "Value";
            racemenu.DataBind();
        }

        private void LoadPovertyList()
        {
            List<Code> vaccineList = DataModel.GetUniqueCodeList("POVERTY");
            povertymenu.DataSource = vaccineList;
            povertymenu.DataTextField = "Name";
            povertymenu.DataValueField = "Value";
            povertymenu.DataBind();
        }

        private void LoadGenderList()
        {
            List<Code> vaccineList = DataModel.GetUniqueCodeList("GENDER");
            gendermenu.DataSource = vaccineList;
            gendermenu.DataTextField = "Name";
            gendermenu.DataValueField = "Value";
            gendermenu.DataBind();

        }

        private void LoadAgeList()
        {
            List<Code> vaccineList = DataModel.GetUniqueCodeList("AGE");
            agemenu.DataSource = vaccineList;
            agemenu.DataTextField = "Name";
            agemenu.DataValueField = "Value";
            agemenu.DataBind();

        }

        private void LoadMaritalList()
        {
            List<Code> vaccineList = DataModel.GetUniqueCodeList("MARITAL");
            maritalmenu.DataSource = vaccineList;
            maritalmenu.DataTextField = "Name";
            maritalmenu.DataValueField = "Value";
            maritalmenu.DataBind();

        }

        private void LoadVaccineList()
        {
            //string only
            //List<string> vaccineList = DataModel.GetUniqueVaccineNames();
            //vaccinemenu.DataSource = vaccineList;
            //vaccinemenu.DataBind();

            List<Vaccine> vaccineList = DataModel.GetUniqueVaccines();
            vaccinemenu.DataSource = vaccineList;
            vaccinemenu.DataTextField = "Name";
            vaccinemenu.DataValueField = "Id";
            vaccinemenu.DataBind();
        }

        private void LoadStateList()
        {

            List<State> vaccineList = DataModel.GetUniqueStates();
            statemenu.DataSource = vaccineList;
            statemenu.DataTextField = "Name";
            statemenu.DataValueField = "FipsCode";
            statemenu.DataBind();
        }

        private void LoadYearList()
        {

            List<int> yearList = DataModel.GetUniqueYears();
            yearmenu.DataSource = yearList;
            yearmenu.DataBind();
        }
    }
}