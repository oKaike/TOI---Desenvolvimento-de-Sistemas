using System;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace PastaProgram{
        public class Inserts{
            public void CadastrarGR(){

            }

            public void CadastrarSG(){

            }

            public void EnviarGrav(){
            EnviatTitulo = "insert into gravacao values (@titulo)";
        cmd.Parameters.AddWithValue("@gravacao", gravacao);

            EnviarGR = "insert into gravacao values (@gravacao)";
        cmd.Parameters.AddWithValue("@gravacao", gravacao);

            }

            public void EnviarIMG(){
            
            }


        }

}
