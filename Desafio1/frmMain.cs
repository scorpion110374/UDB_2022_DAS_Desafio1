using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Desafio1;

namespace Desafio1
{
    public partial class frmMain : Form
    {
        //Declarar lista de usuarios
        public static List<Usuario> lstUsuarios = new List<Usuario>();

        //Declarar categoria de usuario
       public string catSelected = null;

        public frmMain()
        {
            InitializeComponent();
        }


        public bool Login(string usr, string pass)
        {
            if (usr == "" || pass == "")
            {
                //Mensaje de error si los cambos de usuario y contraseña no son completados
                MessageBox.Show("Favor ingresar usuario y contraseña!", "Advertencia", MessageBoxButtons.OK);
                return false;
            }
            else if ((usr != "" || pass != ""))
            {
                var usrFound = lstUsuarios;
                return usrFound.Any(Usuario => Usuario.User == usr && Usuario.Clave == pass);
            }
            return false;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            //Instanciar usuarios predeterminados
            lstUsuarios.Add(new Usuario("eduardot", "123456", "Transporte"));
            lstUsuarios.Add(new Usuario("etrujillo", "123456", "Población"));
            lstUsuarios.Add(new Usuario("luist", "123456", "Transporte"));
            lstUsuarios.Add(new Usuario("armandot", "123456", "Población"));
            lstUsuarios.Add(new Usuario("fatimat", "123456", "Transporte"));
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
            else
            {
                var usrFound = lstUsuarios;
                if (usrFound.Any(Usuario => Usuario.User == txtNuevoUsuario.Text))
                {
                    MessageBox.Show("Este nombre de usuario ya existe en el sistema, favor seleccione uno diferente!", "Advertencia", MessageBoxButtons.OK);
                }
                else
                {
                    //Agregar nuevo usuario
                    lstUsuarios.Add(new Usuario(txtNuevoUsuario.Text, txtNuevoPassword.Text, cbNuevaCategoria.Text));
                    //Ocultar controles de registro
                    txtUsername.Text = "";
                    txtPassword.Text = "";
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


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Login(txtUsername.Text, txtPassword.Text))
            {
                var usrFound = lstUsuarios;
                //Gardar categoria de usuario validado
                catSelected = usrFound.Where(Usuario => Usuario.User == txtUsername.Text && Usuario.Clave == txtPassword.Text).Select(Usuario => Usuario.Categoria).SingleOrDefault();
                //Ocultar objetos de inicio si login es validado
                pbLogin.Hide();
                lblUsername.Hide();
                lblPassword.Hide();
                txtUsername.Hide();
                txtPassword.Hide();
                btnLogin.Hide();
                linkRegistro.Hide();
                //Ocultar controles de registro
                lblNuevoUsuario.Hide();
                lblNuevoPassword.Hide();
                lblCategoria.Hide();
                txtNuevoUsuario.Hide();
                txtNuevoPassword.Hide();
                cbNuevaCategoria.Hide();
                btnRegistro.Hide();
                //Mostrar el Tab control
                tabControl1.Show();
                btnCerrar.Show();


                //Cargar informacion a ser mostrada segun categoria de usuario
                //Si categoria de interes del usuario es Transporte
                if (catSelected == "Transporte")
                {
                    //llenar informacion a tab1
                    txtTitle.Text = "PARQUE VEHICULAR EN EL SALVADOR";
                    FileStream fs = new System.IO.FileStream(@"..\..\images\transporte.jpg", FileMode.Open, FileAccess.Read);
                    pictureBox1.Image = Image.FromStream(fs);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    fs.Close();
                    txtMainInfo.Text = "En San Salvador, los automovilistas realizan diariamente 2,500,000 viajes y circulan en velocidades inferiores a los 20 kilómetros por hora, según un estudio de BID" + "\r\n" +
                                        "Por las calles y carreteras del país circulan 1,412,393 de automotores, según datos oficiales. Si esa cantidad de automotores se repartiera equitativamente entre las familias(1, 871, 468), significaría que ocho de cada diez familias poseerían uno." + "\r\n" +
                                        "Pero la distribución no es de esa forma y dentro de ese casi millón y medio hay un millón de vehículos particulares, más de 5,000 de alquiler, 500,000 motocicletas y más 12,932 vehículos propiedad del Gobierno, y así continúa el conteo." + "\r\n" +
                                        "La lista de vehículos matriculados crece diariamente.El estimado mensual oscila entre 8,879." + "\r\n" +
                                        "Según los datos del Viceministerio de Transporte(VMT)en el departamento de San Salvador circulan 512,381 de automotores; la cifra no es de extrañar si tomamos en cuenta la cantidad de habitantes(2,750,000) y la concentración de actividad económica." + "\r\n" +
                                        "Las cifras también son importantes en los departamentos de la Libertad con 185,380 vehículos; 118, 852 en Santa Ana y 109, 727 en San Miguel." +
                                        "Las 10 departamentos restantes tienen un registro menor a 80,000 cada uno." + "\r\n" +
                                        "Por las calles y carreteras del país circulan 1,412,393 de automotores, según datos oficiales. Si esa cantidad de automotores se repartiera equitativamente entre las familias(1, 871, 468), significaría que ocho de cada diez familias poseerían uno.";

                    //declarar datos 2020, tab2 y tab3
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

                    // Generar graficos en tab4
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


                }else
                {
                    //Si categoria de interes del usuario es Transporte
                    //llenar informacion a tab1
                    txtTitle.Text = "POBLACIÓN DE EL SALVADOR";
                    FileStream fs = new System.IO.FileStream(@"..\..\images\censo.jpg", FileMode.Open, FileAccess.Read);
                    pictureBox1.Image = Image.FromStream(fs);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    fs.Close();
                    txtMainInfo.Text = "El Salvador está en el puesto 112 de los 196 estados que componen la tabla de población mundial de datosmacro.com."+"\r\n"+
                                       "Tan solo un 0,66 % de la población de El Salvador son inmigrantes, según los últimos datos de inmigración publicados por la ONU. El Salvador es el 166º país del mundo por porcentaje de inmigración."+"\r\n"+
                                       "El Salvador se encuentra en la 167ª posición de la tabla de densidad, así pues, tiene una alta densidad de población, de 308 habitantes por Km2.";

                    //declarar datos , tab2 y tab3
                    //Declarar instancia del objeto datatable
                    DataTable table = new DataTable();
                    //Agregar columnas con su respectivo nombre
                    table.Columns.Add("Anio", typeof(string));
                    table.Columns.Add("Densidad", typeof(int));
                    table.Columns.Add("Hombres", typeof(int));
                    table.Columns.Add("Mujeres", typeof(int));
                    table.Columns.Add("Población", typeof(int));

                    //Agregar filas
                    table.Rows.Add("2020", "308", "3036424", "3449777", "6486201");
                    table.Rows.Add("2019", "307", "3023353", "3430197", "6454000");
                    table.Rows.Add("2018", "305", "3010428", "3410312", "6421000");
                    table.Rows.Add("2017", "304", "2997810", "3390314", "6388000");
                    table.Rows.Add("2016", "302", "2985690", "3370447", "6356000");
                    table.Rows.Add("2015", "301", "2974229", "3350892", "6325000");
                    table.Rows.Add("2014", "299", "2963437", "3331687", "6295000");
                    table.Rows.Add("2013", "298", "2953270", "3312806", "6266000");
                    table.Rows.Add("2012", "296", "2943739", "3294183", "6238000");
                    table.Rows.Add("2011", "295", "2934825", "3275742", "6211000");


                    //Ordenar datos de forma ascendente con respecto a columna "Depto."
                    table.DefaultView.Sort = "Anio DESC";
                    //Cargar datos a dataview
                    dgDatos2020.DataSource = table;

                    //Ocultar datagrid2
                    dgDatos2021.Hide();


                    // Generar graficos en tab4
                    //Grafico $ 1
                    chart1.DataSource = table;
                    chart1.Series["Series1"].XValueMember = "Anio";
                    chart1.Series["Series1"].YValueMembers = "Población";
                    chart1.Titles.Add("Población por año");
                    chart1.Series["Series1"].ChartType = SeriesChartType.Pie;
                    chart1.Series["Series1"].IsValueShownAsLabel = false;

                    //Grafico $ 2
                    chart2.DataSource = table;
                    chart2.Series["Series1"].XValueMember = "Anio";
                    chart2.Series["Series1"].YValueMembers = "Hombres";
                    //chart2.Series["Series2"].XValueMember = "Anio";
                    chart2.Series["Series2"].YValueMembers = "Mujeres";
                    chart2.Titles.Add("Gráfico por Género");
                    chart2.Series["Series1"].ChartType = SeriesChartType.Column;
                    chart2.Series["Series1"].IsValueShownAsLabel = false;
                    chart2.Series["Series2"].ChartType = SeriesChartType.Column;
                    chart2.Series["Series2"].IsValueShownAsLabel = false;
                }
                //Si categoria de interes del usuario es Poblacion
            }
            else {
                //Mensaje si credenciales invalidas
                MessageBox.Show("Credenciales invalidas o usuario no esta registrado!", "Advertencia", MessageBoxButtons.OK);
            };
        }

            private void btnCerrar_Click(object sender, EventArgs e)
        {
            //Ocultar objetos de inicio si login es validado
            pbLogin.Show();
            lblUsername.Show();
            lblPassword.Show();
            txtUsername.Text = "";
            txtUsername.Show();
            txtPassword.Text = "";
            txtPassword.Show();
            btnLogin.Show();
            linkRegistro.Show();
            //Ocultar controles de registro
            lblNuevoUsuario.Hide();
            lblNuevoPassword.Hide();
            lblCategoria.Hide();
            txtNuevoUsuario.Hide();
            txtNuevoPassword.Hide();
            cbNuevaCategoria.Hide();
            btnRegistro.Hide();
            //Mostrar el Tab control
            tabControl1.Hide();
            btnCerrar.Hide();
        }
    }
}
