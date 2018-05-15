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
		[Inject]
		private readonly IClientRepository _clientRepository;
		[Inject]
		private readonly IOfferNoteRepository _offerNoteRepository;
		[Inject]
		private readonly IOfferSectionRepository _offerSectionRepository;
		[Inject]
		private readonly IOfferItemRepository _offerItemRepository;

		public OfferService(IOfferRepository offerRepository, IClientRepository clientRepository, IOfferNoteRepository offerNoteRepository, IOfferSectionRepository offerSectionRepository, IOfferItemRepository offerItemRepository)
		{
			_offerRepository = offerRepository;
			_clientRepository = clientRepository;
			_offerNoteRepository = offerNoteRepository;
			_offerSectionRepository = offerSectionRepository;
			_offerItemRepository = offerItemRepository;
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
			offerDto.ClientID = GetClientID(offerDto);

			Offer offer = Mapper.Map<OfferDto, Offer>(offerDto);
			offer = _offerRepository.Add(offer);

			//TODO: stored procedure that will take xml and process offer
			foreach (OfferNoteDto noteDto in offerDto.OfferNotes)
			{
				noteDto.OfferID = offer.ID;

				OfferNote note = Mapper.Map<OfferNoteDto, OfferNote>(noteDto);
				_offerNoteRepository.Add(note);
			}

			foreach(OfferSectionDto sectionDto in offerDto.OfferSections)
			{
				sectionDto.OfferID = offer.ID;

				OfferSection section = Mapper.Map<OfferSectionDto, OfferSection>(sectionDto);
				section = _offerSectionRepository.Add(section);

				foreach(OfferItemDto itemDto in sectionDto.OfferItems)
				{
					itemDto.OfferSectionID = section.ID;

					OfferItem item = Mapper.Map<OfferItemDto, OfferItem>(itemDto);
					_offerItemRepository.Add(item);
				}
			}

			return Mapper.Map<Offer, OfferDto>(offer);
		}

		public void UpdateOffer(OfferDto offerDto)
		{
			offerDto.ClientID = GetClientID(offerDto);

			Offer offer = _offerRepository.Find(offerDto.ID);
			_offerRepository.Update(Mapper.Map(offerDto, offer));

			//TODO: stored procedure that will take xml and process offer
			foreach (OfferNoteDto noteDto in offerDto.OfferNotes)
			{
				OfferNote note = _offerNoteRepository.Find(noteDto.ID.Value);
				_offerNoteRepository.Update(Mapper.Map(noteDto, note));
			}

			foreach (OfferSectionDto sectionDto in offerDto.OfferSections)
			{
				OfferSection section = _offerSectionRepository.Find(sectionDto.ID.Value);
				_offerSectionRepository.Update(Mapper.Map(sectionDto, section));

				foreach (OfferItemDto itemDto in sectionDto.OfferItems)
				{
					OfferItem item = _offerItemRepository.Find(itemDto.ID.Value);
					_offerItemRepository.Add(Mapper.Map(itemDto, item));
				}
			}
		}

		public void DeleteOffer(int id)
		{
			Offer offer = _offerRepository.Find(id);

			if (offer != null)
				_offerRepository.Delete(offer);
		}

		private int GetClientID(OfferDto offerDto)
		{
			Client newClient = new Client()
			{
				FirstName = offerDto.ClientFirstName,
				Email = offerDto.ClientEmail,
				LastName = offerDto.ClientLastName,
				PhoneNumber = offerDto.ClientPhoneNumber,
				Title = offerDto.ClientTitle
			};

			Client client = _clientRepository.Find(newClient);
			if (client == null)
				client = _clientRepository.Add(newClient);

			return client.ID;
		}
	}
}
