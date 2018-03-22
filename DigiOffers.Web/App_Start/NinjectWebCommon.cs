[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DigiOffers.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(DigiOffers.Web.App_Start.NinjectWebCommon), "Stop")]

namespace DigiOffers.Web.App_Start
{
	using System;
	using System.Web;
	using DAL;
	using DAL.Repository;
	using DigiOffers.Service;
	using Microsoft.Web.Infrastructure.DynamicModuleHelper;
	using Ninject;
	using Ninject.Web.Common;
	using Ninject.Web.Common.WebHost;

	public static class NinjectWebCommon
	{
		private static readonly Bootstrapper bootstrapper = new Bootstrapper();

		/// <summary>
		/// Starts the application
		/// </summary>
		public static void Start()
		{
			DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
			DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
			bootstrapper.Initialize(CreateKernel);
		}

		/// <summary>
		/// Stops the application.
		/// </summary>
		public static void Stop()
		{
			bootstrapper.ShutDown();
		}

		/// <summary>
		/// Creates the kernel that will manage your application.
		/// </summary>
		/// <returns>The created kernel.</returns>
		private static IKernel CreateKernel()
		{
			var kernel = new StandardKernel();
			try
			{
				kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
				kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

				RegisterServices(kernel);
				return kernel;
			}
			catch
			{
				kernel.Dispose();
				throw;
			}
		}

		/// <summary>
		/// Load your modules or register your services here!
		/// </summary>
		/// <param name="kernel">The kernel.</param>
		private static void RegisterServices(IKernel kernel)
		{
			kernel.Bind<DigiOfferDbContext>()
			.To<DigiOfferDbContext>()
			.InRequestScope();

			kernel.Bind<OfferService>()
			.ToSelf()
			.InRequestScope();

			kernel.Bind<IClientRepository>()
				.To<ClientRepository>()
				.InRequestScope();

			kernel.Bind<IOfferRepository>()
				.To<OfferRepository>()
				.InRequestScope();

			kernel.Bind<IOfferItemRepository>()
				.To<OfferItemRepository>()
				.InRequestScope();

			kernel.Bind<IOfferNoteRepository>()
				.To<OfferNoteRepository>()
				.InRequestScope();

			kernel.Bind<IOfferSectionRepository>()
				.To<OfferSectionRepository>()
				.InRequestScope();
		}
	}
}
