module.exports.absolute = function (num) {
  //if (num > 0) return num;
  //   if (num >= 0) return num;
  //   if (num < 0) return -num;
  //return 0;

  return num >= 0 ? num : -num;
};

module.exports.add = function (x, y) {
  return x + y;
};
