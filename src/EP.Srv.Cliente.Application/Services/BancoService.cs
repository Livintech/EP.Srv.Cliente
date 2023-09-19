using EP.Srv.Cliente.Application.Interfaces;
using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Domain.Interfaces;
using EP.Srv.Cliente.Domain.Responses;
using EP.Srv.Cliente.Infrastructure.Interfaces;

namespace EP.Srv.Cliente.Application.Services
{
    public class BancoService : IBancoService
    {
        private readonly IBancorepository _bancorepository;
        private readonly IUserIdentity _userIdentity;

        public BancoService(IBancorepository bancorepository, IUserIdentity userIdentity)
        {
            _bancorepository = bancorepository;
            _userIdentity = userIdentity;
        }

        public async Task<BaseResponse> AtualizarBancoAsync(Banco banco)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var response = await _bancorepository.AtualizarBancoAsync(banco);
                baseResponse.Data = response;
                baseResponse.Success = true;
                baseResponse.Message = "Banco atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                baseResponse.Success = false;
                baseResponse.Message = ex.Message;
            }

            return baseResponse;
        }

        public async Task<BaseResponse> CadastrarBancoAsync(Banco banco)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var response = await _bancorepository.CadastrarBancoAsync(banco);
                baseResponse.Data = response;
                baseResponse.Success = true;
            }
            catch (Exception ex)
            {
                baseResponse.Success = false;
                baseResponse.Message = ex.Message;
            }

            return baseResponse;
        }

        public async Task<BaseResponse> ListarBancosAsync(string empresaId)
        {
            var baseResponse = new BaseResponse();
            try
            {
                //var clienteId = _userIdentity.Perfil != "Master" ? _userIdentity.CodigoEmpresa.Substring(0, 5) : null;
                var response = await _bancorepository.ListarBancosAsync();

                if (!string.IsNullOrEmpty(empresaId))
                {
                    response = response.Where(c => c.EmpresaId == int.Parse(empresaId)).ToList();
                }

                baseResponse.Data = response;
                baseResponse.Success = true;
            }
            catch (Exception ex)
            {
                baseResponse.Success = false;
                baseResponse.Message = ex.Message;
            }

            return baseResponse;
        }

        public async Task<BaseResponse> ObterBancoByIdAsunc(int id)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var response = await _bancorepository.ObterBancoByIdAsunc(id);
                baseResponse.Data = response;
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
