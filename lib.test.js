const lib = require("./lib");
const customer = require("./customer");

test("greet should return message", function () {
  let result = lib.greet("kumar");
  //more specific
  //expect(result).toBe("Welcome kumar");

  //more generic
  //expect(result).not.toBeNull();

  expect(result).toMatch(/kumar/);
  expect(result).toContain("kumar");
});

test("getCurrencies should return currency values", () => {
  let result = lib.getCurrencies();

  //more generic
  //expect(result.length).toBeGreaterThan(0);

  //more specific
  //expect(result[0]).toBe("USD");

  expect(result).toContain("USD");
  expect(result).toContain("INR");
});

test("getCustomer should return customer details", () => {
  let result = lib.getCustomer(1);

  //generic
  expect(result).not.toBeNull();

  //specific
  //expect(result).toEqual({ id: 1, name: "kumar" });

  //balanced
  expect(result).toMatchObject({ id: 1, name: "kumar" });
  //expect(result).toHaveProperty("name", "kumar");
});

test("register function should throw error when name is null", () => {
  expect(() => lib.register(null)).toThrowError(/name/i);
});

test("register function should object when name is passed", () => {
  let result = lib.register("kumar");
  expect(result).toMatchObject({ name: "kumar" });
});

test("applydiscount function should apply discount on price", async () => {
  customer.getCustomerDetails = (id) => {
    return Promise.resolve({
      data: { id: 1, name: "customer 1", discount: 20 },
    });
  };
  let result = await lib.applyDiscount(1, { id: 1, price: 50 });
  expect(result).toBe(40);
});

//moq
test("applydiscount function should apply discount on price", async () => {
  customer.getCustomerDetails = jest.fn().mockResolvedValue({
    data: { id: 1, name: "customer 1", discount: 50 },
  });
  let result = await lib.applyDiscount(1, { id: 1, price: 50 });
  expect(result).toBe(25);
});
