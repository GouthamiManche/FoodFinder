using System;
using System.Threading.Tasks;
using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;


namespace RecipeWEB
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            Class1.InClient();

        }
       
        public async Task FLoad()
        {
            string keyApi = "c8929479833a4ee4afc65c72e744336c";

            string basee = $"https://api.spoonacular.com/recipes/search?apiKey={keyApi}&query=";
            string term = search.Text;
            SqlStart(term);
            string url = basee + term;
            var pic = await Jsp.Load(url);
            int i = 0;
           
            DataTable dt = new DataTable("Table");

            dt.Columns.Add("Title", Type.GetType("System.String"));
            dt.Columns.Add("Img", Type.GetType("System.String"));
            dt.Columns.Add("Url", Type.GetType("System.String"));

            dt.Columns.Add("Serv", Type.GetType("System.Int32"));
            dt.Columns.Add("Minu", Type.GetType("System.Int32"));

            foreach (var item in pic.Results)
            {
                DataRow dr = dt.NewRow();
                object[] yum = new object[5];

                foreach (var vastu in pic.Results[i])
                {
                    string idu = "id";
                    string opLi = "openLicense";

                    if (vastu.Key.Equals(idu) || vastu.Key.Equals(opLi))
                    {
                        continue;
                    }
                    else
                    {
                        if (vastu.Key.Equals("title"))
                        {
                            yum[0] = vastu.Value;
                        }
                        else if (vastu.Key.Equals("image"))
                        {
                            yum[1] = "https://spoonacular.com/recipeImages/" + vastu.Value;
                        }
                        else if (vastu.Key.Equals("sourceUrl"))
                        {
                            yum[2] = vastu.Value;
                        }
                        else if (vastu.Key.Equals("servings"))
                        {
                            yum[3] = vastu.Value;
                        }
                        else if (vastu.Key.Equals("readyInMinutes"))
                        {
                            yum[4] = vastu.Value;
                        }
                    }


                }

                for (var t = 0; t < 5; t++)
                {
                    dr[t] = yum[t];
                }
                dt.Rows.Add(dr);
                i++;
            }

            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        public void SqlStart(string term)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["RecipeWEB"].ConnectionString;

            string insert = $"INSERT INTO [Database] (Search_History) VALUES ('{term}')";
            SqlConnection con = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand(insert, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err.Message);

            }
            finally
            {
                con.Close();
            }
        }

        protected async void Searchbtn_Click(object sender, EventArgs e)
        {
            await FLoad();
        }
    }
}