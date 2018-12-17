pragma solidity ^0.4.7;

import "./Database.sol";



 /*Constructor  */
contract Product {
    //Reference to its database contract
    address public DATABASE_CONTRACT;
    //Reference to its product factory.
   // address public PRODUCT_FACTORY;

    // This struct represents an action realized by a handler on the product.
    struct Action {
        //address of the individual or the organization who realizes the action.
        address handler;
        //description of the action.
        bytes32 description;
        // Longitude x10^10 where the Action is done.
        uint256 lon;
        // Latitude x10^10 where the Action is done.
        uint256 lat;

        // Instant of time when the Action is done.
        uint timestamp;
        // Block when the Action is done.
        uint blockNumber;
    }

    // if the Product is consumed the transaction can't be done.
    modifier notConsumed {
        if (isConsumed)
        revert("not consumed");
        _;
    }

    // addresses of the products which were used to build this Product.
    address[] public parentProducts;
    // addresses of the products which are built by this Product.
    address[] public childProducts;

    // indicates if a product has been consumed or not.
    bool public isConsumed;

    // indicates the name of a product.
    bytes32 public name;

    // Additional information about the Product, generally as a JSON object
    bytes32 public additionalInformation;

    // all the actions which have been applied to the Product.
    Action[] public actions;

    function getNumberOfActions() public view returns(uint256) {
        return actions.length;
    }

    function getAction(uint index) public view returns(address, bytes32, uint256, uint256, uint, uint) {
        return (
            actions[index].handler, actions[index].description, actions[index].lat, 
            actions[index].lon, actions[index].timestamp, actions[index].blockNumber);
    }

    /////////////////
    // Constructor //
    /////////////////

  /* @notice Constructor to create a Product
     @param _name The name of the Product
     @param _additionalInformation Additional information about the Product,
            generally as a JSON object.
     @param _parentProducts Addresses of the parent products of the Product.
     @param _lon Longitude x10^10 where the Product is created.
     @param _lat Latitude x10^10 where the Product is created.
     @param _DATABASE_CONTRACT Reference to its database contract
     @param _PRODUCT_FACTORY Reference to its product factory */

    constructor (
        bytes32 _name, bytes32 _additionalInformation, uint256 _lat, uint256 _lon, address _DATABASE_CONTRACT) public {
        name = _name;
        isConsumed = false;
        additionalInformation = _additionalInformation;

        DATABASE_CONTRACT = _DATABASE_CONTRACT;
        //Action
        Action memory creation;
        creation.handler = msg.sender;
        creation.description = "Product creation";
        creation.lon = _lon;
        creation.lat = _lat;
        creation.timestamp = now;
        creation.blockNumber = block.number;

        actions.push(creation);

        Database database = Database(DATABASE_CONTRACT);
        database.storeProductReference(this);
    }

    function () public {
        // If anyone wants to send Ether to this contract, the transaction gets rejected
        revert("no eth accepted");
    }

  /* @notice Function to add an Action to the product.
     @param _description The description of the Action.
     @param _lon Longitude x10^10 where the Action is done.
     @param _lat Latitude x10^10 where the Action is done.
     @param _newProductNames In case that this Action creates more products from
            this Product, the names of the new products should be provided here.
     @param _newProductsAdditionalInformation In case that this Action creates more products from
            this Product, the additional information of the new products should be provided here.
     @param _consumed True if the product becomes consumed after the action. */

    function addAction (
        bytes32 description, uint256 lat, uint256 lon, bool _consumed) public notConsumed {
        //if (newProductsNames.length != newProductsAdditionalInformation.length) revert();

        Action memory action;
        action.handler = msg.sender;
        action.description = description;
        action.lon = lon;
        action.lat = lat;
        action.timestamp = now;
        action.blockNumber = block.number;


        actions.push(action);
        isConsumed = _consumed;
    }


    function collaborateInMerge(address newProductAddress, uint256 lat, uint256 lon) public notConsumed {
        childProducts.push(newProductAddress);

        Action memory action;
        action.handler = this;
        action.description = "Collaborate in merge";
        action.lon = lon;
        action.lat = lat;
        action.timestamp = now;
        action.blockNumber = block.number;

        actions.push(action);

        this.consume();
    }

    /* Function to consume the Product */
    function consume() public notConsumed {
        isConsumed = true;
    }
}
