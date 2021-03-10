EXEC InserirNovoPerfil 'ADMINISTRAÇÃO';
EXEC InserirNovoPerfil 'OPERAÇÃO';
EXEC InserirNovoPerfil 'GERÊNCIA';
EXEC InserirNovoPerfil 'CONTROLE DE RISCO';
EXEC InserirNovoPerfil 'Teste';

EXEC AtualizarPerfil 5, 'Teste II';

EXEC DeletarPerfil 5;

EXEC CadastroUsuario 'Fabiano', '123456';
EXEC CadastroUsuario 'Gustavo', '123456';
EXEC CadastroUsuario 'Pedro', '123456';
EXEC CadastroUsuario 'Karine', '123456';

EXEC AtualizarUsuario 3, 'João', '654321';

EXEC CriarAcessoUsuario 1, 3;
EXEC CriarAcessoUsuario 2, 2;
EXEC CriarAcessoUsuario 3, 4;
EXEC CriarAcessoUsuario 4, 4;

EXEC DeletarAcessoUsuario 3, 4;

SELECT * FROM Perfil;
SELECT * FROM Usuario;
SELECT * FROM Acesso;