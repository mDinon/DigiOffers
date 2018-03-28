using System.Collections.Generic;
using AutoMapper;
using DigiOffers.DAL.Repository;
using DigiOffers.Model.DTO;
using DigiOffers.Model.Entities;
using Ninject;

namespace DigiOffers.Service
{
	public class OfferService
	{
		[Inject]
		private readonly IOfferRepository _offerRepository;

		public OfferService(IOfferRepository offerRepository)
		{
			_offerRepository = offerRepository;
		}

		public List<OfferDto> GetOffers()
		{
			List<Offer> offers = _offerRepository.GetList();

			return Mapper.Map<List<Offer>, List<OfferDto>>(offers);
		}

		public OfferDto FindOffer(int id)
		{
			Offer offer = _offerRepository.Find(id);

			return Mapper.Map<Offer, OfferDto>(offer);
		}

		public OfferDto AddOffer(OfferDto offerDto)
		{
			Offer offer = Mapper.Map<OfferDto, Offer>(offerDto);
			offer = _offerRepository.Add(offer);

			return Mapper.Map<Offer, OfferDto>(offer);
		}

		public void UpdateOffer(OfferDto offerDto)
		{
			_offerRepository.Update(Mapper.Map<OfferDto, Offer>(offerDto));
		}

		public void DeleteOffer(int id)
		{
			Offer offer = _offerRepository.Find(id);

			if (offer != null)
				_offerRepository.Delete(offer);
		}
	}
}
