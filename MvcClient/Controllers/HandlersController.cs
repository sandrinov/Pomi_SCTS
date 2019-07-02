using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MvcClient.DTO;
using MvcClient.EthereumHelper;
using MvcClient.Models;
using Nethereum.Web3;

namespace MvcClient.Controllers
{
    public class HandlersController : Controller
    {
        public IConfiguration Configuration { get; }
        private BlockChain BC = new BlockChain();
        public HandlersController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            var userClaims = (User as ClaimsPrincipal).Claims;
            string bc_address = userClaims
                          .Where(c => c.Type == "BC_Address")
                          .Select(c => c.Value)
                          .FirstOrDefault();
            string user_name = userClaims
                           .Where(c => c.Type == "given_name")
                           .Select(c => c.Value)
                           .FirstOrDefault();
            ViewData["UserName"] = user_name;

            ViewData["BC_Address"] = bc_address;
            string ethereumAddress = (Configuration.GetSection("Endpoints")["EthereumAddress"]).ToString();

            List<HandlerViewModel> handlers_List = new List<HandlerViewModel>();
            try
            {
                var web3 = new Web3(ethereumAddress);
                var db_contract = web3.Eth.GetContract(BC.Get_ABI("Database"), BC.Get_Address("Database"));

                var getNumberOfHandlers = db_contract.GetFunction("getNumberOfHandlers");
                var numOfHandlers = await getNumberOfHandlers.CallAsync<uint>();

                var addressHandlerSupport_property = db_contract.GetFunction("addressHandlerSupport");

                for (int i = 0; i < numOfHandlers; i++)
                {
                    var handlerAddress = await addressHandlerSupport_property.CallAsync<string>(i);

                    var getHandler = db_contract.GetFunction("getHandler");
                    var dto_handler = await getHandler.CallDeserializingToObjectAsync<DTO_Handler>(bc_address, new Nethereum.Hex.HexTypes.HexBigInteger(4712388), null, handlerAddress);

                    handlers_List.Add(new HandlerViewModel(dto_handler, handlerAddress));
                }
            }
            catch (Exception excp)
            {

                handlers_List.Add(new HandlerViewModel() { HandlerName = excp.Message });
            }

            return View(handlers_List);
        }



        [HttpGet]
        public IActionResult NewHandler()
        {
            var userClaims = (User as ClaimsPrincipal).Claims;
            string bc_address = userClaims
                           .Where(c => c.Type == "BC_Address")
                           .Select(c => c.Value)
                           .FirstOrDefault();
            string user_name = userClaims
                           .Where(c => c.Type == "given_name")
                           .Select(c => c.Value)
                           .FirstOrDefault();
            ViewData["UserName"] = user_name;

            ViewData["BC_Address"] = bc_address;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewHandler(HandlerViewModel model)
        {
            var userClaims = (User as ClaimsPrincipal).Claims;
            string bc_address = userClaims
                          .Where(c => c.Type == "BC_Address")
                          .Select(c => c.Value)
                          .FirstOrDefault();
            string user_name = userClaims
                           .Where(c => c.Type == "given_name")
                           .Select(c => c.Value)
                           .FirstOrDefault();
            ViewData["UserName"] = user_name;

            ViewData["BC_Address"] = bc_address;

            if (ModelState.IsValid)
            {
                string ethereumAddress = (Configuration.GetSection("Endpoints")["EthereumAddress"]).ToString();

                try
                {
                    var web3 = new Web3(ethereumAddress);
                    var db_contract = web3.Eth.GetContract(BC.Get_ABI("Database"), BC.Get_Address("Database"));
                    var addAction = db_contract.GetFunction("addHandler");
                    var transactionInput = addAction.CreateTransactionInput(bc_address, new Nethereum.Hex.HexTypes.HexBigInteger(4712388), new Nethereum.Hex.HexTypes.HexBigInteger(0));
                    var x1 = await addAction.SendTransactionAsync(transactionInput, model.HandlerAddress, model.HandlerName, model.AdditionalInformation);

                    return RedirectToAction("Index");
                }
                catch (Exception excp)
                {

                    model = new HandlerViewModel() { HandlerName = excp.Message };
                }
            }

            // If we got this far, something failed, redisplay form
            return RedirectToAction("Index");
        }
    }
}