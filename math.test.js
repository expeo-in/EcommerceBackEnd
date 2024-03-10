const math = require("./math");

describe("absolute function", () => {
  test("should return positive num if num greater than zero", () => {
    //A-Arrange,  A-Act, A-Assert
    let result = math.absolute(1);
    expect(result).toBe(1);
  });

  test("should return positive num if num lesser than zero", () => {
    let result = math.absolute(-1);
    expect(result).toBe(1);
  });

  test("should return zero if the number is zero", () => {
    let result = math.absolute(0);
    expect(result).toBe(0);
  });
});

describe("add function", () => {
  test("should return sum of two num", () => {
    let result = math.add(2, 3);
    expect(result).toBe(5);
  });
});
