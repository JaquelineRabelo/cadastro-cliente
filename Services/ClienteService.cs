// Services/ClienteService.cs
using CadastroClientes.Models;
using System.Collections.Generic;

namespace CadastroClientes.Services
{
    public class ClienteService
    {
        private readonly List<Cliente> _clientes = new List<Cliente>();

        public void AdicionarCliente(string nome, string email)
        {
            Cliente cliente = new Cliente(nome, email);
            _clientes.Add(cliente);
        }

        public List<Cliente> ObterClientes()
        {
            return _clientes;
        }

        public bool EditarCliente(string nome, string novoNome, string novoEmail)
        {
            var cliente = _clientes.Find(c => c.Nome == nome);
            if (cliente != null)
            {
                cliente.Nome = novoNome;
                cliente.Email = novoEmail;
                return true;
            }
            return false;
        }

        public bool ExcluirCliente(string nome)
        {
            var cliente = _clientes.Find(c => c.Nome == nome);
            if (cliente != null)
            {
                _clientes.Remove(cliente);
                return true;
            }
            return false;
        }
    }
}