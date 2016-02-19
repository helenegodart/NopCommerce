//Contributor: Nicolas Muniere


using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel.Activation;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Payments;
using Nop.Core.Infrastructure;
using Nop.Core.Plugins;
using Nop.Plugin.Misc.WebServices.Security;
using Nop.Services.Authentication;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Services.Directory;
using Nop.Services.Orders;
using Nop.Services.Payments;
using Nop.Services.Security;
using System.Xml.Linq;

namespace Nop.Plugin.Misc.WebServices
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class NopService : INopService
    {
        #region Fields

        private readonly IAddressService _addressService;
        private readonly ICountryService _countryService;
        private readonly IStateProvinceService _stateProvinceService;
        private readonly ICustomerService _customerService;
        private readonly ICustomerRegistrationService _customerRegistrationService;
        private readonly CustomerSettings _customerSettings;
        private readonly IPermissionService _permissionSettings;
        private readonly IOrderProcessingService _orderProcessingService;
        private readonly IOrderService _orderService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IWorkContext _workContext;
        private readonly IPluginFinder _pluginFinder;
        private readonly IStoreContext _storeContext;
        
        #endregion 

        #region Ctor

        public NopService()
        {
            _addressService = EngineContext.Current.Resolve<IAddressService>();
            _countryService = EngineContext.Current.Resolve<ICountryService>();
            _stateProvinceService = EngineContext.Current.Resolve<IStateProvinceService>();
            _customerService = EngineContext.Current.Resolve<ICustomerService>();
            _customerRegistrationService = EngineContext.Current.Resolve<ICustomerRegistrationService>();
            _customerSettings = EngineContext.Current.Resolve<CustomerSettings>();
            _permissionSettings = EngineContext.Current.Resolve<IPermissionService>();
            _orderProcessingService = EngineContext.Current.Resolve<IOrderProcessingService>();
            _orderService = EngineContext.Current.Resolve<IOrderService>();
            _authenticationService = EngineContext.Current.Resolve<IAuthenticationService>();
            _workContext = EngineContext.Current.Resolve<IWorkContext>();
            _pluginFinder = EngineContext.Current.Resolve<IPluginFinder>();
            _storeContext = EngineContext.Current.Resolve<IStoreContext>();
        }

        #endregion 

        #region Utilities

        protected void CheckAccess(string usernameOrEmail, string userPassword)
        {
            //check whether web service plugin is installed
            var pluginDescriptor = _pluginFinder.GetPluginDescriptorBySystemName("Misc.WebServices");
            if (pluginDescriptor == null)
                throw new ApplicationException("Web services plugin cannot be loaded");
            if (!_pluginFinder.AuthenticateStore(pluginDescriptor, _storeContext.CurrentStore.Id))
                throw new ApplicationException("Web services plugin is not available in this store");

            if (_customerRegistrationService.ValidateCustomer(usernameOrEmail, userPassword)!= CustomerLoginResults.Successful)
                    throw new ApplicationException("Not allowed");
            
            var customer = _customerSettings.UsernamesEnabled ? _customerService.GetCustomerByUsername(usernameOrEmail) : _customerService.GetCustomerByEmail(usernameOrEmail);

            _workContext.CurrentCustomer = customer;
            _authenticationService.SignIn(customer, true);

            //valdiate whether we can access this web service
            if (!_permissionSettings.Authorize(WebServicePermissionProvider.AccessWebService))
                throw new ApplicationException("Not allowed to access web service");
        }

        protected List<Order> GetOrderCollection(int[] ordersId)
        {
            var orders = new List<Order>();
            foreach (int id in ordersId)
            {
                orders.Add(_orderService.GetOrderById(id));
            }
            return orders;
        }

        #endregion

        #region Orders

        public DataSet GetPaymentMethod(string usernameOrEmail, string userPassword)
        {
            CheckAccess(usernameOrEmail, userPassword);
            if (!_permissionSettings.Authorize(StandardPermissionProvider.ManageOrders))
                throw new ApplicationException("Not allowed to manage orders");

            var plugins = from p in _pluginFinder.GetPlugins<IPaymentMethod>()
                          select p;

            var dataset = new DataSet();
            var datatable = dataset.Tables.Add("PaymentMethod");
            datatable.Columns.Add("SystemName");
            datatable.Columns.Add("Name");
            foreach (var plugin in plugins)
            {
                datatable.LoadDataRow(new object[] { plugin.PluginDescriptor.SystemName, plugin.PluginDescriptor.FriendlyName }, true);
            }
            return dataset;
        }

        public DataSet ExecuteDataSet(string[] sqlStatements, string usernameOrEmail, string userPassword)
        {
            //uncomment lines below in order to allow execute any SQL
            //CheckAccess(usernameOrEmail, userPassword);

            //if (!_permissionSettings.Authorize(StandardPermissionProvider.ManageOrders))
            //    throw new ApplicationException("Not allowed to manage orders");

            //var dataset = new DataSet();

            //var dataSettingsManager = new DataSettingsManager();
            //var dataProviderSettings = dataSettingsManager.LoadSettings();
            //using (SqlConnection connection = new SqlConnection(dataProviderSettings.DataConnectionString))
            //{
            //    foreach (var sqlStatement in sqlStatements)
            //    {
            //        DataTable dt = dataset.Tables.Add();
            //        SqlDataAdapter adapter = new SqlDataAdapter();
            //        adapter.SelectCommand = new SqlCommand(sqlStatement, connection);
            //        adapter.Fill(dt);

            //    }
            //}

            //return dataset;




            return null;
        }
        
        public Object ExecuteScalar(string sqlStatement, string usernameOrEmail, string userPassword)
        {
            //uncomment lines below in order to allow execute any SQL
            //CheckAccess(usernameOrEmail, userPassword);
            //if (!_permissionSettings.Authorize(StandardPermissionProvider.ManageOrders))
            //    throw new ApplicationException("Not allowed to manage orders");

            //Object result;
            //var dataSettingsManager = new DataSettingsManager();
            //var dataProviderSettings = dataSettingsManager.LoadSettings();
            //using (SqlConnection connection = new SqlConnection(dataProviderSettings.DataConnectionString))
            //{
            //    SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            //    connection.Open();
            //    result = cmd.ExecuteScalar();

            //}

            //return result;



            return null;
        }
        
        public void ExecuteNonQuery(string sqlStatement, string usernameOrEmail, string userPassword)
        {
            //uncomment lines below in order to allow execute any SQL
            //CheckAccess(usernameOrEmail, userPassword);
            //if (!_permissionSettings.Authorize(StandardPermissionProvider.ManageOrders))
            //    throw new ApplicationException("Not allowed to manage orders");

            //var dataSettingsManager = new DataSettingsManager();
            //var dataProviderSettings = dataSettingsManager.LoadSettings();
            //using (SqlConnection connection = new SqlConnection(dataProviderSettings.DataConnectionString))
            //{
            //    SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            //    connection.Open();
            //    cmd.ExecuteScalar();
            //}
        }

        public List<OrderError> DeleteOrders(int[] ordersId, string usernameOrEmail, string userPassword)
        {
            CheckAccess(usernameOrEmail, userPassword);
            if (!_permissionSettings.Authorize(StandardPermissionProvider.ManageOrders))
                throw new ApplicationException("Not allowed to manage orders");

            var errors = new List<OrderError>();
            foreach (var order in GetOrderCollection(ordersId))
            {
                try
                {
                    _orderProcessingService.DeleteOrder(order);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message);
                }
            }
            return errors;
        }

        public void AddOrderNote(int orderId, string note, bool displayToCustomer, string usernameOrEmail, string userPassword)
        {
            CheckAccess(usernameOrEmail, userPassword);
            if (!_permissionSettings.Authorize(StandardPermissionProvider.ManageOrders))
                throw new ApplicationException("Not allowed to manage orders");

            try
            {
                var order = _orderService.GetOrderById(orderId);
                order.OrderNotes.Add(new OrderNote
                {
                    Note = note,
                    DisplayToCustomer = displayToCustomer,
                    CreatedOnUtc = DateTime.UtcNow
                });
                _orderService.UpdateOrder(order);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
        
        public void UpdateOrderBillingInfo(int orderId, string firstName, string lastName, string phone, string email, string fax, string company, string address1, string address2,
            string city, string stateProvinceAbbreviation, string countryThreeLetterIsoCode, string postalCode, string usernameOrEmail, string userPassword)
        {
            CheckAccess(usernameOrEmail, userPassword);
            if (!_permissionSettings.Authorize(StandardPermissionProvider.ManageOrders))
                throw new ApplicationException("Not allowed to manage orders");

            try
            {
                var order = _orderService.GetOrderById(orderId);
                var a = order.BillingAddress;
                a.FirstName = firstName;
                a.LastName = lastName;
                a.PhoneNumber = phone;
                a.Email = email;
                a.FaxNumber = fax;
                a.Company = company;
                a.Address1 = address1;
                a.Address2 = address2;
                a.City = city;
                StateProvince stateProvince = null;
                if (!String.IsNullOrEmpty(stateProvinceAbbreviation))
                    stateProvince = _stateProvinceService.GetStateProvinceByAbbreviation(stateProvinceAbbreviation);
                a.StateProvince = stateProvince;
                Country country = null;
                if (!String.IsNullOrEmpty(countryThreeLetterIsoCode))
                    country = _countryService.GetCountryByThreeLetterIsoCode(countryThreeLetterIsoCode);
                a.Country = country;
                a.ZipPostalCode = postalCode;

                _addressService.UpdateAddress(a);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
        
        public void UpdateOrderShippingInfo(int orderId, string firstName, string lastName, string phone, string email, string fax, string company, string address1, string address2,
            string city, string stateProvinceAbbreviation, string countryThreeLetterIsoCode, string postalCode, string usernameOrEmail, string userPassword)
        {
            CheckAccess(usernameOrEmail, userPassword);
            if (!_permissionSettings.Authorize(StandardPermissionProvider.ManageOrders))
                throw new ApplicationException("Not allowed to manage orders");

            try
            {
                var order = _orderService.GetOrderById(orderId);
                var a = order.ShippingAddress;
                a.FirstName = firstName;
                a.LastName = lastName;
                a.PhoneNumber = phone;
                a.Email = email;
                a.FaxNumber = fax;
                a.Company = company;
                a.Address1 = address1;
                a.Address2 = address2;
                a.City = city;
                StateProvince stateProvince = null;
                if (!String.IsNullOrEmpty(stateProvinceAbbreviation))
                    stateProvince = _stateProvinceService.GetStateProvinceByAbbreviation(stateProvinceAbbreviation);
                a.StateProvince = stateProvince;
                Country country = null;
                if (!String.IsNullOrEmpty(countryThreeLetterIsoCode))
                    country = _countryService.GetCountryByThreeLetterIsoCode(countryThreeLetterIsoCode);
                a.Country = country;
                a.ZipPostalCode = postalCode;

                _addressService.UpdateAddress(a);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

        }
        
        public void SetOrderPaymentPending(int orderId, string usernameOrEmail, string userPassword)
        {
            CheckAccess(usernameOrEmail, userPassword);
            if (!_permissionSettings.Authorize(StandardPermissionProvider.ManageOrders))
                throw new ApplicationException("Not allowed to manage orders");

            try
            {
                Order order = _orderService.GetOrderById(orderId);
                order.PaymentStatus = PaymentStatus.Pending;
                _orderService.UpdateOrder(order);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

        }
        
        public void SetOrderPaymentPaid(int orderId, string usernameOrEmail, string userPassword)
        {
            CheckAccess(usernameOrEmail, userPassword);
            if (!_permissionSettings.Authorize(StandardPermissionProvider.ManageOrders))
                throw new ApplicationException("Not allowed to manage orders");

            try
            {
                var order = _orderService.GetOrderById(orderId);
                _orderProcessingService.MarkOrderAsPaid(order);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

        }
        
        public void SetOrderPaymentPaidWithMethod(int orderId, string paymentMethodName, string usernameOrEmail, string userPassword)
        {
            CheckAccess(usernameOrEmail, userPassword);
            if (!_permissionSettings.Authorize(StandardPermissionProvider.ManageOrders))
                throw new ApplicationException("Not allowed to manage orders");

            try
            {
                var order = _orderService.GetOrderById(orderId);
                order.PaymentMethodSystemName = paymentMethodName;
                _orderService.UpdateOrder(order);
                _orderProcessingService.MarkOrderAsPaid(order);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

        }
        
        public void SetOrderPaymentRefund(int orderId, bool offline, string usernameOrEmail, string userPassword)
        {
            CheckAccess(usernameOrEmail, userPassword);
            if (!_permissionSettings.Authorize(StandardPermissionProvider.ManageOrders))
                throw new ApplicationException("Not allowed to manage orders");

            try
            {
                var order = _orderService.GetOrderById(orderId);
                if (offline)
                {
                    _orderProcessingService.RefundOffline(order);
                }
                else
                {
                    var errors = _orderProcessingService.Refund(order);
                    if (errors.Count > 0)
                    {
                        throw new ApplicationException(errors[0]);
                    }

                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

        }

        
        public List<OrderError> SetOrdersStatusCanceled(int[] ordersId, string usernameOrEmail, string userPassword)
        {
            CheckAccess(usernameOrEmail, userPassword);
            if (!_permissionSettings.Authorize(StandardPermissionProvider.ManageOrders))
                throw new ApplicationException("Not allowed to manage orders");

            var errors = new List<OrderError>();
            foreach (var order in GetOrderCollection(ordersId))
            {
                try
                {
                    _orderProcessingService.CancelOrder(order, true);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message);
                }
            }
            return errors;
        }

        public static string demandeArticle(int codeArticle)
        {
            DISTRI_DEVEntities db = new DISTRI_DEVEntities();


            var empQuery = from article in db.ART_Article
                           from tarif in db.TRF_Tarif
                           from rayon in db.ART_Rayon
                           from famille in db.ART_Famille
                           from couleur in db.ART_Couleur
                           from couleurType in db.ART_CouleurType
                           from grille in db.ART_Grille
                           from photo in db.PAR_Photo
                           from griffe in db.ART_Griffe

                           where article.CodeArticle == codeArticle.ToString()
                           where tarif.ID_Article == article.ID
                           where rayon.ID == article.ID_Rayon
                           where famille.ID == article.ID_Famille
                           where couleur.ID == article.ID_Couleur
                           where couleurType.ID == couleur.ID
                           where article.ID_GrilleAchat == grille.ID
                           where photo.ID_Objet == article.ID
                           where article.ID_Griffe == griffe.ID
                           orderby tarif.DateCreation descending

                           select new { article, tarif, rayon, famille, couleur, couleurType, grille, photo, griffe };




            Console.WriteLine("Il y a " + empQuery.Count() + " ligne");

            try
            {
                var num = empQuery.First();

                String resultat = string.Format("{0} : {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11} \n",
                        num.article.ID,
                        num.article.CodeArticle,
                        num.article.Libelle,
                        num.article.Description,
                        num.article.ID_Fournisseur,
                        num.article.QteUniteStock,
                        num.article.PoidsArticle,

                        num.tarif.PrixTTC,
                        num.tarif.DateCreation,
                        num.grille.Libelle,
                        num.couleurType.Libelle,
                        num.griffe.ID
                        );

                XElement element = new XElement("requete",
                            new XElement("ID", num.article.ID),
                            new XElement("CodeArticle", num.article.CodeArticle),
                            new XElement("Libelle", num.article.Libelle),
                            new XElement("Description", num.article.Description),
                            new XElement("ID_Fournisseur", num.article.ID_Fournisseur),
                            new XElement("QteUniteStock", num.article.QteUniteStock),
                            new XElement("PoidsArticle", num.article.PoidsArticle),


                            new XElement("PrixTTC", num.tarif.PrixTTC),
                            new XElement("DateCreation", num.tarif.DateCreation),
                            new XElement("grille_Libelle", num.grille.Libelle),
                            new XElement("famille_Libelle", num.famille.Libelle),
                            new XElement("couleurType_Libelle", num.couleurType.Libelle),
                            new XElement("Filemane", num.photo.Filename),
                            new XElement("ID_Griffe", num.griffe.ID)
                            );



                return element.ToString();
            }
            catch (Exception e)
            {
                return e.ToString() + "Pas d'article pour ce numéro";
            }
        }

        public static string demandeMarque(int codeMarque)
        {
            DISTRI_DEVEntities db = new DISTRI_DEVEntities();


            var empQuery = from griffe in db.ART_Griffe

                           where griffe.ID == codeMarque
                           select new { griffe };




            Console.WriteLine("Il y a " + empQuery.Count() + " ligne");

            try
            {
                var num = empQuery.First();


                XElement element = new XElement("requete",

                            new XElement("griffe_ID", num.griffe.ID),
                            new XElement("griffe_Libelle", num.griffe.Libelle)
                            );



                return element.ToString();
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        #endregion
    }
}
