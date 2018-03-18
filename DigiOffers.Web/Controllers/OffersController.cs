using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DigiOffers.DAL;
using DigiOffers.DAL.Repository;
using DigiOffers.Model.DTO;
using DigiOffers.Model.Entities;
using Ninject;

namespace DigiOffers.Web.Controllers
{
	public class OffersController : Controller
	{
		[Inject]
		private IOfferRepository _offerRepository { get; set; }

		public OffersController(IOfferRepository offerRepository)
		{
			_offerRepository = offerRepository;
		}

		// GET: Offers
		public ActionResult Index()
		{
			List<Offer> offers = _offerRepository.GetList();
			
			List<OfferDto> test = Mapper.Map<List<Offer>, List<OfferDto>>(offers);


			return View(Mapper.Map<List<Offer>, List<OfferDto>>(offers));
		}

		// GET: Offers/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Offer offer = _offerRepository.Find(id.Value);
			if (offer == null)
			{
				return HttpNotFound();
			}
			return View(Mapper.Map<Offer,OfferDto>(offer));
		}

		// GET: Offers/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Offers/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ID,ClientID,ClientFirstName,ClientLastName,DeliveryDate")] OfferDto offerDTO)
		{
			if (ModelState.IsValid)
			{
				//db.OfferDTOes.Add(offerDTO);
				//db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(offerDTO);
		}

		// GET: Offers/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Offer offer = _offerRepository.Find(id.Value);
			if (offer == null)
			{
				return HttpNotFound();
			}
			return View(Mapper.Map<Offer, OfferDto>(offer));
		}

		// POST: Offers/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID,Active,DateCreated,ClientID,ClientFirstName,ClientLastName,DeliveryDate")] OfferDto offerDTO)
		{
			if (ModelState.IsValid)
			{
				//db.Entry(offerDTO).State = EntityState.Modified;
				//db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(offerDTO);
		}

		// GET: Offers/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Offer offer = _offerRepository.Find(id.Value);
			if (offer == null)
			{
				return HttpNotFound();
			}
			return View(Mapper.Map<Offer, OfferDto>(offer));
		}

		// POST: Offers/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			//OfferDto offerDTO = db.OfferDTOes.Find(id);
			//db.OfferDTOes.Remove(offerDTO);
			//db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
