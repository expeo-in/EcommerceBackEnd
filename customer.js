const axios = require("axios");

module.exports.getCustomerDetails = function getCustomerDetails(id) {
  //api
  return axios.get("https://jsonplaceholder.typicode.com/users/" + id);

  //   return new Promise((resolve, reject) => {
  //     setTimeout(() => {
  //       resolve({ id: 1, name: "Customer 1", discount: 10 });
  //     });
  //   });
};
