Create database TOI;
use TOI;

-- Tabela: setor
CREATE TABLE setor (
    id_setor INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    nome_setor VARCHAR(100) NOT NULL UNIQUE,
    qtade_fun INT NOT NULL,
    DataCadastroSetor DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Tabela: Configuracoes
CREATE TABLE Configuracoes (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    limiteMaximoSG INT NOT NULL
);

-- Tabela: SegurancaUser
CREATE TABLE SegurancaUser (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Nome_sg VARCHAR(200),
    Sexo_sg CHAR(11),
    Senha_sg VARCHAR(100),
    cpf CHAR(11),
    data_nasc_sg DATE
);

-- Tabela: cargos
CREATE TABLE cargos (
    cod_cargo INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    nome_cargo VARCHAR(55) UNIQUE
);

-- Tabela: funcionarios
CREATE TABLE funcionarios (
    id_fun INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    cargoid INT,
    nome_fun VARCHAR(55),
    cpf_fun CHAR(11),
    data_nasc_fun DATE,
    sexo_fun CHAR(10),
    setor_fun VARCHAR(55),
    FOREIGN KEY (cargoid) REFERENCES cargos(cod_cargo)
);

-- Tabela: gravacoes
CREATE TABLE gravacoes (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Titulo_GRV VARCHAR(200),
    gravacao LONGBLOB,
    data_gravacao DATETIME,
    funcionarioID INT,
    OcorrenciaID INT,
    FOREIGN KEY (funcionarioID) REFERENCES funcionarios(id_fun),
    FOREIGN KEY (OcorrenciaID) REFERENCES ocorrencias(id_oc)
);

-- Tabela: imagens
CREATE TABLE imagens (
    id_img INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    titulo_img VARCHAR(200),
    dadosimg LONGBLOB,
    data_upload DATETIME DEFAULT CURRENT_TIMESTAMP,
    ocorrenciasid INT,
    FOREIGN KEY (ocorrenciasid) REFERENCES ocorrencias(id_oc)
);

-- Tabela: ocorrencias
CREATE TABLE ocorrencias (
    id_oc INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    tipo_oc VARCHAR(255),
    descricao_oc VARCHAR(255),
    local_caso CHAR(30),
    nivel_risco ENUM('baixo','medio','grande','auto_risco'),
    data_hora_ocorrido DATETIME,
    nome_envolvido VARCHAR(100),
    registradopor VARCHAR(55),
    qtdade_envolvidos INT
);

-- Tabela: painel_estatistica
CREATE TABLE painel_estatistica (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    quantidade_problemas INT,
    setorcommaisocorrencia CHAR(55),
    ultimo_registro DATETIME,
    setorcommaisproblemas VARCHAR(100),
    qtdade_ocorrencias INT
);

-- Tabela: problemas
CREATE TABLE problemas (
    id_pl INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    titulo_pr VARCHAR(255),
    descricao TEXT,
    problemas_resolvidos TEXT,
    nivel_risco ENUM('baixo','medio','grande','auto_risco'),
    data_pr DATE,
    id_fun INT,
    setor_pr VARCHAR(100),
    RegistradoPor VARCHAR(100),
    FOREIGN KEY (id_fun) REFERENCES funcionarios(id_fun)
);