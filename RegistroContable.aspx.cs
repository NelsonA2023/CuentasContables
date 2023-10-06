using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CuentasContables
{
    public partial class RegistroContable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = System.Configuration.ConfigurationManager.ConnectionStrings["cuentas"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand comando = new SqlCommand("select id, IDCuentas, monto, tipo from RegistrosContables " + " where id ='" + this.TextBox1.Text + "'", conexion);
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                TextBox2.Text = registro["IDCuentas"].ToString();
                this.TextBox3.Text = registro["monto"].ToString();
                this.TextBox4.Text = registro["tipo"].ToString();
            }
            else
                this.Label5.Text = "No existe una cuenta con ese ID";
            conexion.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string s = System.Configuration.ConfigurationManager.ConnectionStrings["cuentas"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand comando = new SqlCommand("insert into RegistrosContables (IDCuentas, monto, tipo) values ( '" + this.TextBox2.Text + "','" + this.TextBox3.Text + "', '" + this.TextBox4.Text + "')", conexion);

            comando.ExecuteNonQuery();
            this.Label5.Text = "Registro guardado";
            conexion.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string s = System.Configuration.ConfigurationManager.ConnectionStrings["cuentas"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand comando = new SqlCommand("delete from RegistrosContables where ID = '" + this.TextBox1.Text + "'", conexion);
            int cantidad = comando.ExecuteNonQuery();
            if (cantidad == 1)
                this.Label5.Text = "Se borró el registro";
            else
                this.Label3.Text = "No existe registro con ese ID";
            conexion.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            Label5.Text = "";
            string s = System.Configuration.ConfigurationManager.ConnectionStrings["cuentas"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand comando = new SqlCommand("update RegistrosContables set " + " IDCuentas = '" + this.TextBox2.Text + "'," + " monto = '" + this.TextBox3.Text + "', " + " tipo = '" + this.TextBox4.Text + " where [id = '" + this.TextBox1.Text + " '] ", conexion);
            
            int cantidad = comando.ExecuteNonQuery();
            if (cantidad ==1)
                this.Label5.Text = "Registro Modificado";
            else
                this.Label5.Text = "No existe registro con ese ID";
            conexion.Close();
        }
    }
}