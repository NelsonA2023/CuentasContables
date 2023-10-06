using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CuentasContables
{
    public partial class Cuentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string s = System.Configuration.ConfigurationManager.ConnectionStrings["cuentas"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand comando = new SqlCommand("insert into Cuentas(descripcion) values ('" + this.TextBox2.Text + "')", conexion);
            comando.ExecuteNonQuery();
            this.Label3.Text = "Cuenta Registrada";
            conexion.Close();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string s =System.Configuration.ConfigurationManager.ConnectionStrings["cuentas"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand comando = new SqlCommand("select descripcion from Cuentas " + " where ID ='" + this.TextBox1.Text + "'",conexion);
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
                this.TextBox2.Text =  (String)registro["descripcion"] ;
            else
                this.Label3.Text = "No existe una cuenta con ese ID";
            conexion.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string s =System.Configuration.ConfigurationManager.ConnectionStrings["cuentas"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand comando = new SqlCommand("delete from Cuentas where ID = '" + this.TextBox1.Text + "'", conexion);
            int cantidad = comando.ExecuteNonQuery();
            if (cantidad == 1)
                this.Label3.Text = "Se borró la cuenta";
            else
                this.Label3.Text = "No existe una cuenta con ese ID";
            conexion.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            Label3.Text = "";
            string s = System.Configuration.ConfigurationManager.ConnectionStrings["cuentas"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand comando = new SqlCommand("update Cuentas set " + " descripcion = '" + this.TextBox2.Text + "' where ID = '" + this.TextBox1.Text + "", conexion);
            //update Cuentas set" + " descripcion = '" + this.TextBox2.Text + "' where ID = '" + this.TextBox1.Text + " ' "
            int cantidad = comando.ExecuteNonQuery();
            if (cantidad >0)
                this.Label3.Text = "Cuenta Modificada";
            else
                this.Label3.Text = "No existe cuenta con ese ID";
            conexion.Close();
        }
    }
}