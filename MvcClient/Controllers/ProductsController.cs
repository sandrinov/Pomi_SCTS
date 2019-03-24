using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MvcClient.DTO;
using MvcClient.EthereumHelper;
using MvcClient.Models;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;
using Newtonsoft.Json;


namespace MvcClient.Controllers
{
    public class ProductsController : Controller
    {
        private HttpClient _httpClient = new HttpClient();
        public IConfiguration Configuration { get; }
        public ProductsController(IConfiguration configuration)
        {
            Configuration = configuration;
            _httpClient.BaseAddress = new Uri((Configuration.GetSection("Endpoints")["Authority"]).ToString());
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

            List<DTO_Product> product_List = new List<DTO_Product>();

            try
            {

                var web3 = new Web3(ethereumAddress);


                var db_contract = web3.Eth.GetContract(BlockChain.DatabaseABI, BlockChain.DataBaseAddress);

                var getNumberOfProducts = db_contract.GetFunction("getNumberOfProducts");
                var numOfProducts = await getNumberOfProducts.CallAsync<uint>();

                for (int i = 0; i < numOfProducts; i++)
                {
                    var getProduct = db_contract.GetFunction("getProduct");
                    var productAddress = await getProduct.CallAsync<String>(bc_address, new Nethereum.Hex.HexTypes.HexBigInteger(4712388), null, i);

                    var product_contract = web3.Eth.GetContract(BlockChain.ProductABI, productAddress);
                    var name_property = product_contract.GetFunction("name");
                    var additionalInformation_property = product_contract.GetFunction("additionalInformation");
                    var isConsumed_property = product_contract.GetFunction("isConsumed");

                    var name = await name_property.CallAsync<string>();
                    var additionalInformation = await additionalInformation_property.CallAsync<string>();
                    var isConsumed = await isConsumed_property.CallAsync<bool>();

                    product_List.Add(new DTO_Product() { Index = i, Name = name, Description = additionalInformation, IsConsumed = isConsumed });
                }

            }
            catch (Exception excp)
            {

                product_List.Add(new DTO_Product() { Name = excp.Message });
            }

            return View(product_List);
        }

        [HttpGet]
        public IActionResult NewProduct()
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
        public async Task<IActionResult> NewProduct(ProductViewModel model)
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
                    var db_contract = web3.Eth.GetContract(BlockChain.DatabaseABI, BlockChain.DataBaseAddress);

                    var productABI = BlockChain.ProductABI;

                    var param_lat = Convert.ToInt32(Decimal.Parse(model.Latitude) * 1000000);
                    var param_lon = Convert.ToInt32(Decimal.Parse(model.Longitude) * 1000000);

                    var gasForDeployContract = new HexBigInteger(6000000);

                    var deploymentMessage = new ProductDeployment
                    {
                        FromAddress = bc_address,
                        Gas = gasForDeployContract,
                        //Name = ConvertinHex(model.ProductName),
                        Name = model.ProductName,
                        //AdditionalInformation = ConvertinHex(model.ProductDescription),
                        AdditionalInformation = model.ProductDescription,
                        Latitude = param_lat,
                        Longitude = param_lon,
                        DataBaseContract = BlockChain.DataBaseAddress
                    };

                    var deploymentHandler = web3.Eth.GetContractDeploymentHandler<ProductDeployment>();
                    var transactionReceipt = await deploymentHandler.SendRequestAndWaitForReceiptAsync(deploymentMessage);
                    var newProductAddress = transactionReceipt.ContractAddress;

                    var getNumberOfProducts = db_contract.GetFunction("getNumberOfProducts");
                    var numOfProducts = await getNumberOfProducts.CallAsync<uint>();

                    return RedirectToAction("Index");
                }
                catch (Exception excp)
                {
                    AddErrors(excp.Message);
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }



        private void AddErrors(String errorMessage)
        {
            ModelState.AddModelError(string.Empty, errorMessage);
        }



        [HttpGet]
        public async Task<IActionResult> AddAction(int id)
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
            DTO_Product product;


            string ethereumAddress = (Configuration.GetSection("Endpoints")["EthereumAddress"]).ToString();
            try
            {
                var web3 = new Web3(ethereumAddress);
                var db_contract = web3.Eth.GetContract(BlockChain.DatabaseABI, BlockChain.DataBaseAddress);

                var getProduct = db_contract.GetFunction("getProduct");
                var productAddress = await getProduct.CallAsync<String>(bc_address, new Nethereum.Hex.HexTypes.HexBigInteger(4712388), null, id);

                var product_contract = web3.Eth.GetContract(BlockChain.ProductABI, productAddress);

                var name_property = product_contract.GetFunction("name");
                var additionalInformation_property = product_contract.GetFunction("additionalInformation");
                var isConsumed_property = product_contract.GetFunction("isConsumed");

                var name = await name_property.CallAsync<string>();
                var additionalInformation = await additionalInformation_property.CallAsync<string>();
                var isConsumed = await isConsumed_property.CallAsync<bool>();

                product = new DTO_Product() { Index = id, Name = name, Description = additionalInformation, IsConsumed = isConsumed };
            }
            catch (Exception excp)
            {
                product = new DTO_Product() { Index = id, Name = excp.Message, Description = "", IsConsumed = false };
            }
            ViewData["Product"] = product;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAction(ActionViewModel model)
        {
            var path = HttpContext.Request.Path.Value;
            String index_string = path.Substring(path.Length - 1);
            var index = Convert.ToInt32(index_string);

            var param_lat = Convert.ToInt32(Decimal.Parse(model.Latitude) * 1000000);
            var param_lon = Convert.ToInt32(Decimal.Parse(model.Longitude) * 1000000);

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
            DTO_Product product;

            string ethereumAddress = (Configuration.GetSection("Endpoints")["EthereumAddress"]).ToString();

            try
            {
                var web3 = new Web3(ethereumAddress);
                var db_contract = web3.Eth.GetContract(BlockChain.DatabaseABI, BlockChain.DataBaseAddress);
                var getProduct = db_contract.GetFunction("getProduct");
                var productAddress = await getProduct.CallAsync<String>(bc_address, new Nethereum.Hex.HexTypes.HexBigInteger(4712388), null, index);

                var product_contract = web3.Eth.GetContract(BlockChain.ProductABI, productAddress);

                var name_property = product_contract.GetFunction("name");
                var additionalInformation_property = product_contract.GetFunction("additionalInformation");
                var isConsumed_property = product_contract.GetFunction("isConsumed");

                var name = await name_property.CallAsync<string>();
                var additionalInformation = await additionalInformation_property.CallAsync<string>();
                var isConsumed = await isConsumed_property.CallAsync<bool>();

                product = new DTO_Product() { Index = index, Name = name, Description = additionalInformation, IsConsumed = isConsumed };


                var addAction = product_contract.GetFunction("addAction");
                var transactionInput = addAction.CreateTransactionInput(bc_address, new Nethereum.Hex.HexTypes.HexBigInteger(4712388), new Nethereum.Hex.HexTypes.HexBigInteger(0));
                
                var x1 = await addAction.SendTransactionAsync(transactionInput, model.Description, param_lat, param_lon, model.IsConsumed);

                return RedirectToAction("ViewHistory", new { id = index });

            }
            catch (Exception excp)
            {
                product = new DTO_Product() { Index = index, Name = excp.Message, Description = "", IsConsumed = false };
            }

            ViewData["Product"] = product;
            return View();
        }

        public async Task<IActionResult> ViewHistory(int id)
        {
            var userClaims = (User as ClaimsPrincipal).Claims;
            string bc_address = userClaims
                           .Where(c => c.Type == "BC_Address")
                           .Select(c => c.Value)
                           .FirstOrDefault();
            ViewData["BC_Address"] = bc_address;
            string user_name = userClaims
                           .Where(c => c.Type == "given_name")
                           .Select(c => c.Value)
                           .FirstOrDefault();
            ViewData["UserName"] = user_name;

            List<ActionHistoryViewModel> listOfAction = new List<ActionHistoryViewModel>();

            string ethereumAddress = (Configuration.GetSection("Endpoints")["EthereumAddress"]).ToString();

            try
            {
                var web3 = new Web3(ethereumAddress);
                var db_contract = web3.Eth.GetContract(BlockChain.DatabaseABI, BlockChain.DataBaseAddress);
                var getProduct = db_contract.GetFunction("getProduct");
                var productAddress = await getProduct.CallAsync<String>(bc_address, new Nethereum.Hex.HexTypes.HexBigInteger(4712388), null, id);

                var product_contract = web3.Eth.GetContract(BlockChain.ProductABI, productAddress);

                var name_property = product_contract.GetFunction("name");
                var isConsumed_property = product_contract.GetFunction("isConsumed");

                var product_name = await name_property.CallAsync<string>();
                var isConsumed = await isConsumed_property.CallAsync<bool>();
                ViewData["ProductName"] = product_name;
                ViewData["IsConsumed"] = isConsumed;

                var getNumberOfActions = product_contract.GetFunction("getNumberOfActions");
                var numOfActions = await getNumberOfActions.CallAsync<uint>();
                var getAction = product_contract.GetFunction("getAction");

                for (int i = 0; i < numOfActions; i++)
                {
                    var dto_action = await getAction.CallDeserializingToObjectAsync<DTO_Action>(bc_address, new Nethereum.Hex.HexTypes.HexBigInteger(4712388), null, i);

                    var handler_address = dto_action.Handler;

                    var getHandler = db_contract.GetFunction("getHandler");
                    var dto_handler = await getHandler.CallDeserializingToObjectAsync<DTO_Handler>(bc_address, new Nethereum.Hex.HexTypes.HexBigInteger(4712388), null, handler_address);

                    listOfAction.Add(new ActionHistoryViewModel(dto_action, dto_action.Handler, dto_handler.AdditionalInformation));
                }
            }
            catch (Exception excp)
            {

                listOfAction.Add(new ActionHistoryViewModel(new DTO_Action(), excp.Message, ""));
            }


            return View(listOfAction);
        }
        private string ConvertinHex(String s)
        {
            byte[] ba = Encoding.Default.GetBytes(s);
            var hexString = BitConverter.ToString(ba);
            hexString = "0x" + hexString.Replace("-", "");
            return hexString;
        }
    }
}