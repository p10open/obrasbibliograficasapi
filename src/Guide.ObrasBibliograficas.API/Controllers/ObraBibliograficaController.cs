using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Guide.ObrasBibliograficas.Domain.Entitdades;
using Guide.ObrasBibliograficas.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Guide.ObrasBibliograficas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObraBibliograficaController : ControllerBase
    {
        IObraBibliograficaService _obraBibliograficaService;

        public ObraBibliograficaController(IObraBibliograficaService obraBibliograficaService)
        {
            _obraBibliograficaService = obraBibliograficaService;
        }

        [HttpPost]
        [Route("processar")]
        public IActionResult Processar([FromBody] List<ObraBibliografica> obraBibliograficas)
        {
            var resultadoProcessamento =_obraBibliograficaService.Processar(obraBibliograficas);

            if (resultadoProcessamento.Sucesso)
                return Ok(resultadoProcessamento);

            return BadRequest(resultadoProcessamento);
        }
    }
}
