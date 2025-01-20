// Controllers/ClientesController.cs
using Microsoft.AspNetCore.Mvc;
using CadastroClientes.Models;
using CadastroClientes.Services;

namespace CadastroClientes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClientesController()
        {
            _clienteService = new ClienteService();
        }

        [HttpPost]
        public IActionResult AdicionarCliente([FromBody] Cliente cliente)
        {
            _clienteService.AdicionarCliente(cliente.Nome, cliente.Email);
            return CreatedAtAction(nameof(ObterClientes), new { nome = cliente.Nome }, cliente);
        }

        [HttpGet]
        public IActionResult ObterClientes()
        {
            return Ok(_clienteService.ObterClientes());
        }

        [HttpPut("{nome}")]
        public IActionResult EditarCliente(string nome, [FromBody] Cliente cliente)
        {
            if (_clienteService.EditarCliente(nome, cliente.Nome, cliente.Email))
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{nome}")]
        public IActionResult ExcluirCliente(string nome)
        {
            if (_clienteService.ExcluirCliente(nome))
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
