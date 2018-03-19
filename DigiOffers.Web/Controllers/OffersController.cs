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
using DigiOffers.Service;
using Ninject;

namespace DigiOffers.Web.Controllers
{
	public class OffersController : Controller
	{
		[Inject]
		private readonly OfferService _offerService;

		public OffersController(OfferService offerService)
		{
			_offerService = offerService;
		}

		// GET: Offers
		public ActionResult Index()
		{
			return View(_offerService.GetOffers());
		}

		// GET: Offers/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			OfferDto offer = _offerService.FindOffer(id.Value);

			if (offer == null)
				return HttpNotFound();

			return View(offer);
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
		public ActionResult Create(OfferDto offerDto)
		{
			bool isOk = TryUpdateModel(offerDto);

			if (isOk && ModelState.IsValid)
			{
				_offerService.AddOffer(offerDto);

				return RedirectToAction("Index");
			}

			return View(offerDto);
		}

		// GET: Offers/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			OfferDto offer = _offerService.FindOffer(id.Value);

			if (offer == null)
				return HttpNotFound();

			return View(offer);
		}

		// POST: Offers/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(OfferDto offerDto)
		{
			bool isOk = TryValidateModel(offerDto);

			if (isOk && ModelState.IsValid)
			{
				_offerService.UpdateOffer(offerDto);

				return RedirectToAction("Index");
			}
			return View(offerDto);
		}

		// GET: Offers/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			OfferDto offer = _offerService.FindOffer(id.Value);

			if (offer == null)
				return HttpNotFound();

			return View(offer);
		}

		// POST: Offers/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			OfferDto offerDto = _offerService.FindOffer(id);
			_offerService.DeleteOffer(offerDto);

			return RedirectToAction("Index");
		}
	}
}
