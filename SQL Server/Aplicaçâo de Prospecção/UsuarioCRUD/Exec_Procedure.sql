EXEC InserirNovoPerfil 'ADMINISTRA��O';
EXEC InserirNovoPerfil 'OPERA��O';
EXEC InserirNovoPerfil 'GER�NCIA';
EXEC InserirNovoPerfil 'CONTROLE DE RISCO';
EXEC InserirNovoPerfil 'Teste';

EXEC AtualizarPerfil 5, 'Teste II';

EXEC DeletarPerfil 5;

EXEC CadastroUsuario 'Fabiano', '123456';
EXEC CadastroUsuario 'Gustavo', '123456';
EXEC CadastroUsuario 'Pedro', '123456';
EXEC CadastroUsuario 'Karine', '123456';
EXEC CadastroUsuario 'Paulo', '123456';
EXEC CadastroUsuario 'Carlos', '123456';
EXEC CadastroUsuario 'Carla', '123456';
EXEC CadastroUsuario 'David', '123456';
EXEC CadastroUsuario 'Leticia', '123456';
EXEC CadastroUsuario 'Julia', '123456';

EXEC AtualizarUsuario 3, 'Jo�o', '654321';

EXEC CriarAcessoUsuario 1, 3;
EXEC CriarAcessoUsuario 2, 2;
EXEC CriarAcessoUsuario 3, 4;
EXEC CriarAcessoUsuario 4, 4;
EXEC CriarAcessoUsuario 4, 3;
EXEC CriarAcessoUsuario 1002, 1;
EXEC CriarAcessoUsuario 1003, 1;
EXEC CriarAcessoUsuario 1004, 2;
EXEC CriarAcessoUsuario 1004, 3;
EXEC CriarAcessoUsuario 1005, 2;
EXEC CriarAcessoUsuario 1006, 3;
EXEC CriarAcessoUsuario 1007, 4;

EXEC DeletarAcessoUsuario 3, 4;

SELECT * FROM Perfil;
SELECT * FROM Usuario;
SELECT * FROM Acesso;