using AutoMapper;
using Eventos.API.Domain;
using Eventos.API.DTO;
using Eventos.API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Service
{
    public class LoteService : ILoteDTOInterface
    {
        private readonly IMapper _IMapper;
        private readonly ILoteInterface _loteInterface;
        public LoteService(IMapper mapper, ILoteInterface loteInterface)
        {
            _IMapper = mapper;
            _loteInterface = loteInterface;
        }
        public LoteDTO AddLote(LoteDTO model)
        {
            var evento = _IMapper.Map<Lote>(model);
            if (evento == null)
            {
                return null;
            }

            _loteInterface.AddLote(evento);
            return _IMapper.Map<LoteDTO>(evento);
        }

        public async Task<bool> Delete(int idEvento, int id)
        {
           return await _loteInterface.Delete(idEvento, id);
        }

        public  List<LoteDTO> GetAllLotesbyEvento(int eventoId)
        {
            var lotes =  _loteInterface.GetAllLotesbyEvento(eventoId);

            if (lotes == null)
            {
                return null;
            }

            return  _IMapper.Map<List<LoteDTO>>(lotes);            

        }

        public async Task<LoteDTO> GetLoteById(int id)
        {
            var lote = await _loteInterface.GetLoteById(id);
            if (lote == null)
            {
                return null;
            }

            return _IMapper.Map<LoteDTO>(lote);

        }

        public void Update(int idEvento, int id, LoteDTO model)
        {
            var lote = _IMapper.Map<Lote>(model);

            _loteInterface.Update(idEvento, id, lote);
        }
    }
}
