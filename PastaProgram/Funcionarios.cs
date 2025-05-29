using System;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Drawing;

public string nome_fun;
public string cpf_fun;
public string idade_fun;
public string setor_fun;

public void CadastrarFun() {
    Console.WriteLine("Preencha as informações dos funcionarios:");
    Console.WriteLine("Nome:");
     string nome_fun = Console.ReadLine();
    Console.WriteLine("CPF:");
     string cpf_fun = Console.ReadLine();
    Console.WriteLine("Idade:");
     string idade_fun = Console.ReadLine();
    Console.WriteLine("Setor:");
     string setor_fun = Console.ReadLine();

}

public void infoFun() {
    
}

public void SalvarDados() {
    string info_fun = "insert into Funcionarios(nome_fun,cpf_fun,data_nasc_fun,setor_fun) values (@nome_fun,@cpf_fun,@data_nasc_fun,@setor_fun)";
    conn.Open();

    cmd.Parameters.AddWithValue("@nome_fun", this.nome_fun);
    cmd.Parameters.AddWithValue("@cpf_fun", this.cpf_fun);
    cmd.Parameters.AddWithValue("@data_nasc_fun", this.idade_fun);
    cmd.Parameters.AddWithValue("@setor_fun", this.setor_fun);
    
}
