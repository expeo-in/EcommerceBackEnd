const customer = require("./customer");

module.exports.greet = function (name) {
  return "Welcome " + name;
};

module.exports.getCurrencies = function () {
  return ["POUND", "USD", "INR"];
};

module.exports.getCustomer = function (id) {
  return { id: id, name: "kumar", age: 30 };
};

module.exports.register = function (name) {
  if (!name) throw new Error("Name is required");
  return { id: 1, name: name };
};

module.exports.applyDiscount = async (id, product) => {
  var res = await customer.getCustomerDetails(id);
  var customerData = res.data;
  //console.log(customerData);
  //customerData.discount = 10;
  return product.price - product.price * (customerData.discount / 100);
};
