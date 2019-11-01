using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilUsuarioController : ControllerBase
    {
        TWMarketplaceContext context = new TWMarketplaceContext();

        [HttpGet]
        public async Task<ActionResult<List<Interesse>>> Get (){ //Lista todos os produtos que o usuario demonstrou interesse
            
            var meus_Pedidos = await context.Interesse.ToListAsync();

                if(meus_Pedidos == null){

                    return NotFound();
                }

            return meus_Pedidos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Interesse>> Get(int id)
        { //Mostra cada interesse //corpo direito do perfil de usuario

            var meus_Pedidos = await context.Interesse.FindAsync(id);

            if(meus_Pedidos == null){

                return NotFound();
            }

            return meus_Pedidos;
        }

    }
}