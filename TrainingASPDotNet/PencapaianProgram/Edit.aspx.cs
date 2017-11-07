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
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // First time load belum ada org load, dia akan panggil bind program
            // Kalau da ada org submit sesuatu, dia da tak panggil bind program
            // then berlaku proses update
            if (!IsPostBack)
            {
                BindProgram();
            }         
        }

        protected void BindProgram()
        {
            // based on nama dalam db --> ["Id"]
            var id = Request.QueryString["Id"];

            const string sql = "SELECT * FROM PencapaianProgram WHERE Id = @Id";

            using (var c = ConnectionManager.GetConnection())
            {
                // Akan baca row pertama dan akan hantar pada var data.
                var data = c.QueryFirstOrDefault<Entities.PencapaianProgram>(sql, new { Id = id });

                KodProgram.Text = data.KodProgram;
                TarikhProgram.Text = data.TarikhProgram.ToString();
                BilanganHari.Text = data.BilanganHari.ToString();
                Lulus.Checked = (bool) data.Lulus;
                // kena cast/set bool sebab dalam db td set null
                // int by default tak blh tak de nilai
                //

            }
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            var id = Request.QueryString["Id"];

            const string sql = @"
            UPDATE PencapaianProgram 
            SET KodProgram = @KodProgram,
            TarikhProgram = @TarikhProgram,
            Bilanganhari = @BilanganHari,
            Lulus = @Lulus
            WHERE Id = @Id";

            using (var c = ConnectionManager.GetConnection())
            {
                var pencapaian = new Entities.PencapaianProgram
                {
                    KodProgram = KodProgram.Text,
                    TarikhProgram = DateTime.Parse(TarikhProgram.Text),
                    BilanganHari = int.Parse(BilanganHari.Text),
                    Lulus = Lulus.Checked,
                    Id = int.Parse(id)
                };

                c.Execute(sql, pencapaian);
            }

            Response.Redirect("List.aspx");
        }
    }
}