using ISS.Application.Dto.Calculos;
using ISS.Application.Helpers;
using ISS.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ISS.Application.Cambio
{
    public class ConversaoMoedas
    {

        private List<Moeda> moedas = new List<Moeda>();
        private DapperContext db;

        public ConversaoMoedas(DapperContext db)
            => this.SetDb(db);

        public void SetDb(DapperContext _db)
        {
            this.db = _db;

            if (moedas.Count() == 0 && this.db != null)
            {
                // Pegando os estados da base de dados
                var estado = db.GetAsync<Estado>("E002", nameof(Estado.CodEstado)).Await();
                var cambios = db.GetAsync<ISS.Application.Models.Cambio>(e => e.DapperInclude(d => d.MoedaBase)).Await();

                // Pegando as moedas ativas
                moedas = db.GetAsync<Moeda>(null, estado.IdEstado, nameof(Moeda.EstadoId)).Await().ToList();

                // TODO: Resolver, adicionado para o caso da Moeda UCF
                moedas?.AddRange(db.GetAsync<Moeda>(null, "987", nameof(Moeda.CodMoeda)).Await());

                moedas.For(e =>
                {
                    e.CambioMoeda = cambios.Where(x => x.MoedaId == e.IdMoeda).ToList();
                });
            }
        }

        public CambioModel Calcular(CambioModel model)
        {
            // Função para preencher o objecto de retorno
            void FillModel(Moeda c, Moeda o)
            {
                model.MoedaId = c.IdMoeda;
                model.OutraMoedaId = o.IdMoeda;

                model.CodMoeda = c.CodMoeda;
                model.CodOutraMoeda = o.CodMoeda;

                model.SimboloMoeda = c.Simbolo;
                model.SimboloOutraMoeda = o.Simbolo;

                model.Moeda = c.Designacao;
                model.OutraMoeda = o.Designacao;
            }

            try
            {
                // Pegando a moeda corrente
                var moedaCorrente = moedas.FirstOrDefault
                    (x => x.IdMoeda == model.MoedaId || x.Simbolo == model.MoedaId || x.CodMoeda == model.MoedaId);

                // Verificando se ela foi encontrada
                if (moedaCorrente == null)
                    model.Mensagens.Add($"A moeda corrente com o identificador '{model.MoedaId}' não foi encontrada.");

                Moeda outraMoeda = null;
                if (model.OutraMoedaId != null)
                    // Pegando a outra moeda
                    outraMoeda = moedas.FirstOrDefault
                        (x => x.IdMoeda == model.OutraMoedaId || x.Simbolo == model.OutraMoedaId || x.CodMoeda == model.OutraMoedaId);

                // Verificando se ela foi encontrada
                //if (outraMoeda == null)
                //    model.Mensagens.Add($"A outra moeda com o identificador '{model.OutraMoedaId}' não foi encontrada.");

                // Verificando se alguma mensagem foi adicionada e parando a execução
                if (model.Mensagens.Count > 0)
                    return model;

                if (moedaCorrente.Simbolo == "AOA")
                {
                    if (model.ValorOutraMoeda == null)
                        // Efectuando o calculo do cambio
                        model.ValorOutraMoeda = model.Valor;
                    else if (model.Valor == null)
                        // Efectuando o calculo do cambio
                        model.Valor = model.ValorOutraMoeda;

                    FillModel(moedaCorrente, moedaCorrente);

                    return model;
                }

                // Pegando o cambio mais recente da moeda corrente
                var cambioMoedaCorrente = moedaCorrente.CambioMoeda.OrderByDescending(x => x.DataCriacao).FirstOrDefault();

                // Verificando se a outra moeda está preenchida
                if (outraMoeda == null)
                    // Configurando a moeda base como a outra moeda
                    outraMoeda = cambioMoedaCorrente != null ? cambioMoedaCorrente.MoedaBase : moedaCorrente;

                // Verificando se ela foi encontrada
                if (cambioMoedaCorrente == null)
                    model.Mensagens.Add($"Não existe cambio para a moeda corrente com a desigancao '{moedaCorrente.Designacao}'.");

                var cambioOutraMoeda = outraMoeda.CambioMoeda.OrderByDescending(x => x.DataCriacao).FirstOrDefault();

                // Verificando se ela foi encontrada
                //if (cambioOutraMoeda == null)
                //    model.Mensagens.Add($"Não existe cambio para a outra moeda com a desigancao '{outraMoeda.Designacao}'.");

                // Verificando se alguma mensagem foi adicionada e parando a execução
                if (model.Mensagens.Count > 0)
                    return model;

                var check = moedaCorrente.IdMoeda == outraMoeda.IdMoeda;

                if (model.ValorOutraMoeda == null)
                    // Efectuando o calculo do cambio
                    model.ValorOutraMoeda = check ? model.Valor : (double)((model.Valor * cambioMoedaCorrente.DivisaVenda));
                else if (model.Valor == null)
                    // Efectuando o calculo do cambio
                    model.Valor = check ? model.ValorOutraMoeda : (double)((model.ValorOutraMoeda / cambioMoedaCorrente.DivisaVenda));

                // Configurando os dados do retorno.
                FillModel(moedaCorrente, outraMoeda);

            }
            catch (Exception ex)
            {
                // Adicionado a mensagem de erro
                model.Mensagens.Add($"Algum erro ocorreu no servidor. Descrição: '{ex.Message}'.");
                // Verificando se a existe uma exceção mais detalhada
                if (ex.InnerException != null)
                    // Adicionado a mensagem de erro
                    model.Mensagens.Add($"Descrição mais profunda: '{ex.InnerException.Message}'.");
            }

            return model;
        }

    }

}
