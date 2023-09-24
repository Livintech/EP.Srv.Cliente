using EP.Srv.Cliente.Application.Interfaces;
using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Domain.Responses;
using EP.Srv.Cliente.Infrastructure.Interfaces;

namespace EP.Srv.Cliente.Application.Services
{
    public class PlanoDeContasService : IPlanoDeContasService
    {
        public readonly IPlanoDeContasRepository _planoDeContasRepository;

        public PlanoDeContasService(IPlanoDeContasRepository planoDeContasRepository)
            => _planoDeContasRepository = planoDeContasRepository;

        public async Task<BaseResponse> AtualizarPlanoDeContasAsync(PlanoContas planoContas)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var retorno = await _planoDeContasRepository.AtualizarPlanoDeContasAsync(planoContas);
                baseResponse.Data = retorno;
                baseResponse.Success = true;
                baseResponse.Message = "Plano de contas atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                baseResponse.Success = false;
                baseResponse.Message = ex.Message;
            }
            return baseResponse;
        }

        public async Task<BaseResponse> GravarPlanoDeContasAsync(PlanoContas planoContas)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var retorno = await _planoDeContasRepository.GravarPlanoDeContasAsync(planoContas);
                baseResponse.Data = retorno;
                baseResponse.Success = true;
                baseResponse.Message = "Plano de contas criado com sucesso.";
            }
            catch (Exception ex)
            {
                baseResponse.Success = false;
                baseResponse.Message = ex.Message;
            }
            return baseResponse;
        }

        public async Task<BaseResponse> ListarPlanoDeContasAsync(string codigoEmpresa)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var planoContas = await _planoDeContasRepository.ListarPlanoDeContasAsync();

                if (!string.IsNullOrEmpty(codigoEmpresa))
                {
                    planoContas = planoContas.Where(p => p.CodigoEmpresa == codigoEmpresa).ToList();
                }

                baseResponse.Data = planoContas;
                baseResponse.Success = true;
            }
            catch (Exception ex)
            {
                baseResponse.Success = false;
                baseResponse.Message = ex.Message;
            }

            return baseResponse;
        }
    }
}
