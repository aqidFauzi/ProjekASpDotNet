using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

namespace TrainingASPDotNet.PencapaianProgram
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            // Logic insert ke table pencapaian program

            const string sql = @"
            INSERT INTO PencapaianProgram (KodProgram, TarikhProgram, BilanganHari, Lulus)
            VALUES(@KodProgram, @TarikhProgram, @BilanganHari, @Lulus)";

            // Get connection string from web.config
            var connection = ConfigurationManager.ConnectionStrings["Database"].ToString();

            // Buka connection
            using (var c = new SqlConnection(connection))
            {
                var pencapaianProgram = new Entities.PencapaianProgram
                {
                    KodProgram = KodProgram.Text,
                    // Casting datetime dan int
                    TarikhProgram =DateTime.Parse(TarikhProgram.Text),
                    BilanganHari = int.Parse(BilanganHari.Text),
                    Lulus = Lulus.Checked
                };

                // tempat nak anta
                c.Execute(sql, pencapaianProgram);
            }
            
            // page kita nak pergi bila butang ditekan
            Response.Redirect("List.aspx");
        }
    }
}