using AutoMapper;
using ISS.Application;
using ISS.Application.Models;
using Xml2CSharp;

namespace ISWebApp.GraphQL.Fatca
{
    public class FatcaProfile : Profile
    {
        public FatcaProfile()
        {
            CreateMap<Endereco, Address>()
                .ForMember(x => x.CountryCode, ops => ops.MapFrom(y => y.CodEndereco))
                .ForMember(x => x.AddressFree, ops => ops.MapFrom(y => y.CodEndereco));
            CreateMap<Saldo, AccountBalance>()
                .ForMember(x => x.CurrCode, ops => ops.MapFrom(y => y.CodSaldo))
                .ForMember(x => x.Text, ops => ops.MapFrom(y => y.Saldo1));

            CreateMap<Titularidade, AccountHolder>()
                .ForMember(x => x.AcctHolderType, ops => ops.MapFrom(y => y.Principal))
                .ForMember(x => x.Individual, ops => ops.MapFrom(y => y.Pessoa))
                .ForMember(x => x.Organisation, ops => ops.MapFrom(y => y.Pessoa));
            CreateMap<ContaFinanceira, AccountReport>()
                .ForMember(x => x.SubstantialOwner, ops => ops.MapFrom(y => y.Titularidade))
                .ForMember(x => x.Payment, ops => ops.MapFrom(y => y.CartaoPagamento))
                .ForMember(x => x.DocSpec, ops => ops.MapFrom(y => y.Contrato))
                .ForMember(x => x.AccountNumber, ops => ops.MapFrom(y => y.NumeroConta))
                .ForMember(x => x.AdditionalData, ops => ops.MapFrom(y => y.CodContaFinanceira))
                .ForMember(x => x.AccountBalance, ops => ops.MapFrom(y => y.Saldo))
                .ForMember(x => x.AccountClosed, ops => ops.MapFrom(y => y.Descricao))
                .ForMember(x => x.AccountHolder, ops => ops.MapFrom(y => y.EnderecoNavigation));
           CreateMap<Endereco, AdditionalData>()
                .ForMember(x => x.AdditionalItem, ops => ops.MapFrom(y => y.CodEndereco));
           CreateMap<Endereco, AdditionalItem>()
              .ForMember(x => x.ItemContent, ops => ops.MapFrom(y => y.CodEndereco))
              .ForMember(x => x.ItemName, ops => ops.MapFrom(y => y.CodEndereco));
           CreateMap<Endereco, BirthInfo>()
             .ForMember(x => x.BirthDate, ops => ops.MapFrom(y => y.CodEndereco))
             .ForMember(x => x.City, ops => ops.MapFrom(y => y.CodEndereco))
             .ForMember(x => x.CitySubentity, ops => ops.MapFrom(y => y.CodEndereco))
             .ForMember(x => x.CountryInfo, ops => ops.MapFrom(y => y.CodEndereco));
           CreateMap<Endereco, DocSpec>()
            .ForMember(x => x.CorrDocRefId, ops => ops.MapFrom(y => y.CodEndereco))
            .ForMember(x => x.CorrMessageRefId, ops => ops.MapFrom(y => y.CodEndereco))
            .ForMember(x => x.DocRefId, ops => ops.MapFrom(y => y.CodEndereco))
            .ForMember(x => x.DocTypeIndic, ops => ops.MapFrom(y => y.CodEndereco));
            CreateMap<Endereco, FATCA>()
              .ForMember(x => x.ReportingFI, ops => ops.MapFrom(y => y.CodEndereco))
              .ForMember(x => x.ReportingGroup, ops => ops.MapFrom(y => y.CodEndereco));
           CreateMap<Endereco, FATCA_OECD>()
              .ForMember(x => x.FATCA, ops => ops.MapFrom(y => y.CodEndereco))
              .ForMember(x => x.Ftc, ops => ops.MapFrom(y => y.CodEndereco));




        }
    }
}
