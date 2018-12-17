pragma solidity ^0.4.7;

import "./Owned.sol";

contract Database is owned {
    // addresses of the Products referenced in this database
    address[] public products;

    // struct which represents a Handler for the products stored in the database.
    struct Handler {
        // indicates the name of a Handler.
        string _name;
        // Additional information about the Handler, generally as a JSON object
        string _additionalInformation;
    }

    // Relates an address with a Handler record.
    mapping(address => Handler) public addressToHandler;
    address[] public addressHandlerSupport;

    /*  Constructor to create a Database */
    constructor() public {}

    function () external{
        // If anyone wants to send Ether to this contract, the transaction gets rejected
        revert();
    }

    function getNumberOfProducts() public view returns(uint256)  {
        return products.length;
    }

    function getProduct(uint index) public view returns(address) {
        return products[index];
    }

    function getNumberOfHandlers() public view returns(uint256)  {
        return addressHandlerSupport.length;
    }

    //Get HAndler Function
    function getHandler(address index) public view returns(string memory, string memory) {
        Handler memory h = addressToHandler [index];
        return (h._name, h._additionalInformation);
    }


    /*   Function to add a Handler reference
        @param _address address of the handler
        @param _name The name of the Handler
        @param _additionalInformation Additional information about the Product,
                generally as a JSON object. */
    function addHandler (
        address _address, string memory _name, string memory _additionalInformation) onlyOwner public {
        Handler memory handler;
        handler._name = _name;
        handler._additionalInformation = _additionalInformation;

        addressToHandler[_address] = handler;
        addressHandlerSupport.push(_address);
    }

    /*  Function to add a product reference
       @param productAddress address of the product */
    function storeProductReference(address productAddress) public {
        products.push(productAddress);
    }
}