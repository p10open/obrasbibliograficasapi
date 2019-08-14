using Guide.ObrasBibliograficas.Domain.DTO;
using Guide.ObrasBibliograficas.Domain.Entitdades;
using Guide.ObrasBibliograficas.Domain.Interfaces.Repositories;
using Guide.ObrasBibliograficas.Domain.Interfaces.Services;
using Guide.ObrasBibliograficas.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;

namespace Guide.ObrasBibliograficas.Domain.Services
{
    public sealed class ObraBibliograficaService : IObraBibliograficaService
    {
        readonly IObraBibliograficaRepository _obraBibliograficaRepository;
        readonly IUnitOfWork _unitOfWork;

        public ObraBibliograficaService(IUnitOfWork unitOfWork, IObraBibliograficaRepository obraBibliograficaService)
        {
            _obraBibliograficaRepository = obraBibliograficaService;
            _unitOfWork = unitOfWork;
        }

        public ProcessamentoNomesDTO Processar(List<ObraBibliografica> obraBibliograficas)
        {
            if (obraBibliograficas == null || obraBibliograficas.Count < 0)
                return ProcessamentoNomesDTO.ProcessamentoNomesDTOFactory.Erro("Nenhuma obra bibliográfica foi informada");


            obraBibliograficas.ForEach(o => o.Formatar());

            _obraBibliograficaRepository.AdicionarLote(obraBibliograficas);

            try
            {
                _unitOfWork.Commit();

                return ProcessamentoNomesDTO.ProcessamentoNomesDTOFactory.Sucesso(obraBibliograficas, "obras bibliográficas processadas com sucesso");
            }
            catch (Exception ex)
            {
                return ProcessamentoNomesDTO.ProcessamentoNomesDTOFactory.Erro($"Ocorreu um erro ao tentar processar as obras bibliográficas: {ex.Message}");
            }
        }
    }
}
