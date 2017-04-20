using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.myWcf;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;

namespace WebApplication
{
    public partial class Page2 : System.Web.UI.Page
    {
        #region Properties
        public Person CurrentPerson { get; private set; }
        public PersonType CurrentType { get; private set; }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int personId = Convert.ToInt32(Request.Params["Id"]);

            CurrentPerson = WebServiceAccess.MyWebService.GetPersons().FirstOrDefault(x => x.Id == personId);

            if (CurrentPerson != null)
            {
                Label lblName = (Label)this.FindControl("name");
                lblName.Text = CurrentPerson.Name;

                Label lblAge = (Label)this.FindControl("age");
                lblAge.Text = CurrentPerson.Age.ToString();

                CurrentType =
                    WebServiceAccess.MyWebService.GetPersonTypes().FirstOrDefault(x => x.Type == CurrentPerson.Type);

                if (CurrentType != null)
                {
                    Label lblType = (Label)this.FindControl("type");
                    lblType.Text = CurrentType.Description;
                }
            }

            //create the chart
            Render_Chart();
        }

        protected void Render_Chart()
        {
            int nbValues = 10;

            DateTime dateFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            int maxDaysInMonth = DateTime.DaysInMonth(dateFrom.Year, dateFrom.Month);
            DateTime dateTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, maxDaysInMonth);

            var randomDatesValues = ChartsRandomDataGenerator.GenerateRandomDates(dateFrom, dateTo, nbValues);
            var randomNumberValues = ChartsRandomDataGenerator.GenerateRandomNumbers(1000, nbValues);

            object[] chartValues = randomNumberValues.Cast<object>().ToArray();
            string[] dateValues = randomDatesValues.ToArray();

            // Declare the HighCharts object    
            DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart").InitChart(new Chart { DefaultSeriesType = ChartTypes.Column })
                .SetTitle(new Title
                {
                    Text = "Example of Chart",
                    X = -50
                })
                .SetSubtitle(new Subtitle
                {
                    Text = "All data are random",
                    X = -70
                })
                .SetXAxis(new XAxis
                {
                    Categories = dateValues //random dates
                })
                .SetSeries(new[]
                        {
                        new Series
                        {
                            //Name = "# Dates",
                            Data = new Data(chartValues)   //random numbers           
                        },
                    });
            chrtMyChart.Text = chart.ToHtmlString();         
        }
    }
}