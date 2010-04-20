using System;
using System.Web.UI;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Configuration;


namespace Samples.Ajax40
{
    public partial class Templates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Implementation of "dual side templating" pattern
                string[] theCountries = new string [] {"[All]", "USA", "Italy", "UK", "Sweden"};
                string theCountriesAsString = "'[All]', 'USA', 'Italy', 'UK', 'Sweden'";
                this.ClientScript.RegisterArrayDeclaration("theCountries", theCountriesAsString);

                listOfCountries.DataSource = theCountries;
                listOfCountries.DataBind();
            }
        }
    }
}
