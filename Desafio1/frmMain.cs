using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Desafio1
{
    public partial class frmMain : Form
    {
        //Set username & password
        string usr = "eduardot";
        string pwd = "123456";

        public class Usuario
        {
            public string User { get; set; }
            public string Clave { get; set; }
            public string Categoria { get; set; }
            public Usuario() { }
            public Usuario(string usuario,string clave,string categoria)
            {
                User = usuario;
                Clave = clave;
                Categoria = categoria;
            }
        }

        //Declarar lista de usuarios
        //List<Usuario> lstUsuarios = new List<Usuario>();
        public static List<Usuario> lstUsuarios = new List<Usuario>();

        //Declarar categoria de usuario
       public string catSelected = null;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Login(txtUsername.Text, txtPassword.Text))
            {
                //Ocultar objetos de inicio si login es validado
                pbLogin.Hide();
                lblUsername.Hide();
                lblPassword.Hide();
                txtUsername.Hide();
                txtPassword.Hide();
                btnLogin.Hide();
                linkRegistro.Hide();
                //Mostrar el Tab control
                tabControl1.Show();
                btnCerrar.Show();


                //Cargar informacion a ser mostrada segun categoria de usuario
                if (catSelected == "Transporte")
                {
                    //declarar datos 2020
                    //Declarar instancia del objeto datatable
                    DataTable table = new DataTable();
                    //Agregar columnas con su respectivo nombre
                    table.Columns.Add("Depto", typeof(string));
                    table.Columns.Add("A", typeof(int));
                    table.Columns.Add("AB", typeof(int));
                    table.Columns.Add("C", typeof(int));
                    table.Columns.Add("CC", typeof(int));
                    table.Columns.Add("CD", typeof(int));
                    table.Columns.Add("CR", typeof(int));
                    table.Columns.Add("D", typeof(int));
                    table.Columns.Add("M", typeof(int));
                    table.Columns.Add("MB", typeof(int));
                    table.Columns.Add("MI", typeof(int));
                    table.Columns.Add("N", typeof(int));
                    table.Columns.Add("O", typeof(int));
                    table.Columns.Add("P", typeof(int));
                    table.Columns.Add("PR", typeof(int));
                    table.Columns.Add("R", typeof(int));
                    table.Columns.Add("RE", typeof(int));
                    table.Columns.Add("V", typeof(int));
                    table.Columns.Add("TOTAL", typeof(int));

                    //Agregar filas
                    table.Rows.Add("San Vicente", "50", "202", "1500", "0", "0", "0", "0", "8669", "11", "0", "111", "0", "16553", "0", "0", "60", "0", "27156");
                    table.Rows.Add("Sonsonate", "131", "605", "3818", "0", "0", "0", "4", "22319", "91", "0", "148", "0", "39780", "0", "0", "2152", "0", "69048");
                    table.Rows.Add("Usulutan", "257", "182", "2011", "0", "0", "0", "0", "25175", "69", "0", "108", "0", "35613", "0", "0", "174", "0", "63589");
                    table.Rows.Add("Cabañas", "4", "174", "1184", "0", "0", "0", "0", "11420", "56", "0", "96", "0", "14849", "0", "0", "89", "0", "27872");
                    table.Rows.Add("La Unión", "177", "334", "2071", "0", "0", "0", "0", "13925", "31", "0", "89", "0", "28809", "0", "0", "138", "0", "45574");
                    table.Rows.Add("Morazán", "29", "84", "1673", "0", "0", "0", "0", "11754", "27", "0", "101", "0", "16757", "0", "0", "162", "0", "30587");
                    table.Rows.Add("La Libertad", "257", "854", "8078", "31", "389", "0", "39", "40165", "558", "191", "1217", "0", "127412", "0", "0", "3146", "68", "182405");
                    table.Rows.Add("San Miguel", "1414", "574", "4352", "0", "0", "0", "0", "33640", "211", "0", "147", "0", "66164", "0", "0", "557", "0", "107059");
                    table.Rows.Add("La Paz", "79", "298", "1655", "0", "0", "0", "0", "16833", "135", "0", "152", "0", "32623", "0", "0", "337", "0", "52112");
                    table.Rows.Add("San Salvador", "2917", "2138", "16419", "35", "198", "152", "115", "107311", "1821", "341", "10197", "1", "359115", "0", "0", "6427", "250", "507437");
                    table.Rows.Add("Chalatenango", "148", "201", "1926", "0", "0", "0", "3", "17489", "20", "0", "160", "0", "23932", "0", "0", "144", "0", "44023");
                    table.Rows.Add("Santa Ana", "104", "697", "3904", "0", "0", "0", "2", "36594", "266", "0", "267", "0", "73869", "0", "0", "503", "4", "116210");
                    table.Rows.Add("Ahuachapan", "7", "229", "1957", "0", "0", "0", "2", "20194", "147", "0", "92", "0", "27171", "0", "0", "225", "0", "50024");
                    table.Rows.Add("Cuscatlan", "54", "193", "1166", "0", "0", "0", "1", "12114", "61", "0", "96", "0", "22185", "0", "0", "153", "0", "36023");


                    //Ordenar datos de forma ascendente con respecto a columna "Depto."
                    table.DefaultView.Sort = "Depto ASC";
                    //Cargar datos a dataview
                    dgDatos2020.DataSource = table;

                    //Sumar valores de columna
                    DataRow rowTable = table.NewRow();
                    rowTable["Depto"] = "V.TOTALES";
                    rowTable["A"] = table.Compute("Sum(A)", "");
                    rowTable["AB"] = table.Compute("Sum(AB)", "");
                    rowTable["C"] = table.Compute("Sum(C)", "");
                    rowTable["CC"] = table.Compute("Sum(CC)", "");
                    rowTable["CD"] = table.Compute("Sum(CD)", "");
                    rowTable["CR"] = table.Compute("Sum(CR)", "");
                    rowTable["D"] = table.Compute("Sum(D)", "");
                    rowTable["M"] = table.Compute("Sum(M)", "");
                    rowTable["MB"] = table.Compute("Sum(MB)", "");
                    rowTable["MI"] = table.Compute("Sum(MI)", "");
                    rowTable["N"] = table.Compute("Sum(N)", "");
                    rowTable["O"] = table.Compute("Sum(O)", "");
                    rowTable["P"] = table.Compute("Sum(P)", "");
                    rowTable["PR"] = table.Compute("Sum(PR)", "");
                    rowTable["R"] = table.Compute("Sum(R)", "");
                    rowTable["RE"] = table.Compute("Sum(RE)", "");
                    rowTable["V"] = table.Compute("Sum(V)", "");
                    rowTable["TOTAL"] = table.Compute("Sum(TOTAL)", "");
                    table.Rows.Add(rowTable);


                    //Establecer ancho de columnas,primera 100, resto 50
                    for (int i = 0; i < 18; i++)
                    {
                        if (i == 0)
                        {
                            dgDatos2020.Columns[i].Width = 100;
                        }
                        else
                        {
                            dgDatos2020.Columns[i].Width = 45;
                        }
                    }



                    //declarar datos 2021
                    //Declarar instancia del objeto datatable
                    DataTable table2 = new DataTable();
                    //Agregar columnas con su respectivo nombre
                    table2.Columns.Add("Depto", typeof(string));
                    table2.Columns.Add("A", typeof(int));
                    table2.Columns.Add("AB", typeof(int));
                    table2.Columns.Add("C", typeof(int));
                    table2.Columns.Add("CC", typeof(int));
                    table2.Columns.Add("CD", typeof(int));
                    table2.Columns.Add("CR", typeof(int));
                    table2.Columns.Add("D", typeof(int));
                    table2.Columns.Add("M", typeof(int));
                    table2.Columns.Add("MB", typeof(int));
                    table2.Columns.Add("MI", typeof(int));
                    table2.Columns.Add("N", typeof(int));
                    table2.Columns.Add("O", typeof(int));
                    table2.Columns.Add("P", typeof(int));
                    table2.Columns.Add("PR", typeof(int));
                    table2.Columns.Add("R", typeof(int));
                    table2.Columns.Add("RE", typeof(int));
                    table2.Columns.Add("V", typeof(int));
                    table2.Columns.Add("TOTAL", typeof(int));


                    //Agregar filas
                    table2.Rows.Add("San Vicente", "51", "205", "1551", "0", "0", "0", "0", "10089", "12", "0", "110", "0", "18434", "0", "0", "73", "0", "30525");
                    table2.Rows.Add("Sonsonate", "125", "632", "4052", "0", "0", "0", "6", "26305", "93", "0", "153", "0", "43598", "0", "0", "2279", "0", "77243");
                    table2.Rows.Add("Usulutan", "263", "183", "2154", "0", "0", "0", "0", "29985", "70", "0", "114", "0", "39060", "0", "0", "172", "0", "72001");
                    table2.Rows.Add("Cabañas", "4", "183", "1261", "0", "0", "0", "0", "13769", "55", "0", "96", "0", "16203", "0", "0", "99", "0", "31670");
                    table2.Rows.Add("La Unión", "172", "346", "2160", "0", "0", "0", "0", "17056", "30", "0", "95", "0", "31509", "0", "0", "153", "0", "51521");
                    table2.Rows.Add("Morazán", "30", "88", "1766", "0", "0", "0", "0", "14367", "27", "0", "100", "0", "18344", "0", "0", "199", "0", "34921");
                    table2.Rows.Add("La Libertad", "250", "868", "8389", "31", "404", "0", "34", "45728", "572", "195", "1212", "0", "134459", "0", "0", "3290", "66", "195498");
                    table2.Rows.Add("San Miguel", "1410", "587", "4641", "0", "0", "0", "0", "39866", "214", "0", "144", "0", "71940", "0", "0", "607", "0", "119409");
                    table2.Rows.Add("La Paz", "74", "309", "1762", "0", "0", "0", "0", "19795", "137", "0", "153", "0", "36178", "0", "0", "359", "0", "58767");
                    table2.Rows.Add("San Salvador", "2795", "2193", "17011", "35", "178", "161", "116", "119316", "1878", "346", "10224", "1", "375034", "0", "0", "6609", "252", "536149");
                    table2.Rows.Add("Chalatenango", "144", "202", "1985", "0", "0", "0", "3", "20595", "17", "0", "162", "0", "25902", "0", "0", "143", "0", "49153");
                    table2.Rows.Add("Santa Ana", "103", "710", "4032", "0", "0", "0", "3", "42059", "273", "0", "267", "0", "79949", "0", "0", "528", "4", "127928");
                    table2.Rows.Add("Ahuachapan", "7", "232", "2091", "0", "0", "0", "2", "23427", "147", "0", "96", "0", "30310", "0", "0", "240", "0", "56552");
                    table2.Rows.Add("Cuscatlan", "53", "204", "1205", "0", "0", "0", "1", "14003", "60", "0", "98", "0", "24380", "0", "0", "137", "0", "40141");

                    //Ordenar datos de forma ascendente con respecto a columna "Depto."
                    table2.DefaultView.Sort = "Depto ASC";
                    //Cargar datos a dataview
                    dgDatos2021.DataSource = table2;

                    //Sumar valores de filas
                    DataRow rowTable2 = table2.NewRow();
                    rowTable2["Depto"] = "V.TOTALES";
                    rowTable2["A"] = table2.Compute("Sum(A)", "");
                    rowTable2["AB"] = table2.Compute("Sum(AB)", "");
                    rowTable2["C"] = table2.Compute("Sum(C)", "");
                    rowTable2["CC"] = table2.Compute("Sum(CC)", "");
                    rowTable2["CD"] = table2.Compute("Sum(CD)", "");
                    rowTable2["CR"] = table2.Compute("Sum(CR)", "");
                    rowTable2["D"] = table2.Compute("Sum(D)", "");
                    rowTable2["M"] = table2.Compute("Sum(M)", "");
                    rowTable2["MB"] = table2.Compute("Sum(MB)", "");
                    rowTable2["MI"] = table2.Compute("Sum(MI)", "");
                    rowTable2["N"] = table2.Compute("Sum(N)", "");
                    rowTable2["O"] = table2.Compute("Sum(O)", "");
                    rowTable2["P"] = table2.Compute("Sum(P)", "");
                    rowTable2["PR"] = table2.Compute("Sum(PR)", "");
                    rowTable2["R"] = table2.Compute("Sum(R)", "");
                    rowTable2["RE"] = table2.Compute("Sum(RE)", "");
                    rowTable2["V"] = table2.Compute("Sum(V)", "");
                    rowTable2["TOTAL"] = table2.Compute("Sum(TOTAL)", "");
                    table2.Rows.Add(rowTable2);


                    //Establecer ancho de columnas,primera 100, resto 50
                    for (int i = 0; i < 18; i++)
                    {
                        if (i == 0)
                        {
                            dgDatos2021.Columns[i].Width = 100;
                        }
                        else
                        {
                            dgDatos2021.Columns[i].Width = 45;
                        }
                    }

                    //Grafico $ 1
                    chart1.DataSource = table.Select("Depto not like 'V.TOTALES'");
                    chart1.Series["Series1"].XValueMember = "Depto";
                    chart1.Series["Series1"].YValueMembers = "TOTAL";
                    chart1.Titles.Add("Gráfico por Departamento 2020");
                    chart1.Series["Series1"].ChartType = SeriesChartType.Pie;
                    chart1.Series["Series1"].IsValueShownAsLabel = false;

                    //Grafico $ 2
                    chart2.DataSource = table2.Select("Depto not like 'V.TOTALES'");
                    chart2.Series["Series1"].XValueMember = "Depto";
                    chart2.Series["Series1"].YValueMembers = "TOTAL";
                    chart2.Titles.Add("Gráfico por Departamento 2021");
                    chart2.Series["Series1"].ChartType = SeriesChartType.Pie;
                    chart2.Series["Series1"].IsValueShownAsLabel = false;


                }
            }
            else {
                //Mensaje si credenciales invalidas
                MessageBox.Show("Credenciales invalidas!", "Advertencia", MessageBoxButtons.OK);
            };
        }

            private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public bool Login(string usr, string pass)
        {
            if (usr == "" || pass == "")
            {
                //Mensaje de error si los cambos de usuario y contraseña no son completados
                MessageBox.Show("Favor ingresar usuario y contraseña!", "Advertencia", MessageBoxButtons.OK);
                return false;
            }
            else if((usr != "" || pass != ""))
            {
                var usrFound = lstUsuarios;
                catSelected = usrFound.Where(Usuario => Usuario.User == usr && Usuario.Clave == pass).Select(Usuario => Usuario.Categoria).SingleOrDefault();
                return usrFound.Any(Usuario => Usuario.User == usr && Usuario.Clave == pass);
                return false;
            }
            return false;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            //Instanciar usuarios predeterminados
            lstUsuarios.Add(new Usuario("eduardot", "123456", "Transporte"));
        }

        private void linkRegistro_Click(object sender, EventArgs e)
        {
            //Mostrar controles de registro
            lblNuevoUsuario.Show();
            lblNuevoPassword.Show();
            lblCategoria.Show();
            txtNuevoUsuario.Show();
            txtNuevoPassword.Show();
            cbNuevaCategoria.Show();
            btnRegistro.Show();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            if (txtNuevoUsuario.Text == "" || txtNuevoPassword.Text == "" || cbNuevaCategoria.Text == "")
            {
                //Mensaje de error si los cambos de usuario y contraseña no son completados
                MessageBox.Show("Favor llenar los 3 campos de registro requeridos!", "Advertencia", MessageBoxButtons.OK);
            }
            else {
                var usrFound = lstUsuarios;
                if(usrFound.Any(Usuario => Usuario.User == txtNuevoUsuario.Text))
                {
                    MessageBox.Show("Este nombre de usuario ya existe en el sistema, favor seleccione uno diferente!", "Advertencia", MessageBoxButtons.OK);
                }
                else
                {
                    //Instanciar usuarios predeterminados
                    lstUsuarios.Add(new Usuario(txtNuevoUsuario.Text, txtNuevoPassword.Text, cbNuevaCategoria.Text));
                    //Mostrar controles de registro
                    lblNuevoUsuario.Hide();
                    lblNuevoPassword.Hide();
                    lblCategoria.Hide();
                    txtNuevoUsuario.Hide();
                    txtNuevoPassword.Hide();
                    cbNuevaCategoria.Hide();
                    btnRegistro.Hide();
                    MessageBox.Show("Usuario registrado exitosamente!", "Advertencia", MessageBoxButtons.OK);
                }
            }
        }
    }
}
