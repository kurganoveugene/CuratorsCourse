class Utils {

  static getRandomText() {
    let text = "";
    let possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    for (var i = 0; i < 5; i++)
      text += possible.charAt(Math.floor(Math.random() * possible.length));

    return text;
  }

  static getRandomInterests(arr, count) {
    let rndList = [];
    for (let i = 0; i < count; i++) {
      let rand = Math.floor(Math.random() * arr.length);
      rndList.push(arr[rand]);
    }
    return rndList;
  }

  static getBoolean(expression) {
    if (expression === 1) {
      return true;
    } if (expression === 0) {
      return false;
    }
  }

} module.exports = Utils;