using BLL.Models;
using Data.Conexao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Data.Validacoes
{
    public static class Valida
    {
        public static ClienteModel Cliente(DataContext _database, int idCliente)
        {
            var cliente = _database.Cliente.Where(c => c.Id_Cliente == idCliente)
                                           .Include(c => c.Telefones)
                                           .Include(c => c.Analises)
                                           .Include(c => c.Enderecos)
                                           .ThenInclude(e => e.Cidade)
                                           .ThenInclude(c => c.Estado)
                                           .ThenInclude(e => e.Pais)
                                           .First();

            if (cliente != null)
                return cliente;
            else
                throw new ArgumentException(message: "Cliente não encontrado na base de dados");
        }

        public static UsuarioModel Usuario(DataContext _database, int idUsuario)
        {
            var usuario = _database.Usuario.Where(u => u.Id_Usuario == idUsuario)
                                           .Include(u => u.Acesso)
                                           .ThenInclude(a => a.Perfil)
                                           .First();

            if (usuario != null)
                return usuario;
            else
                throw new ArgumentException(message: "Usuário não encontrado na base de dados");
        }
    }
}
