starterServices.factory("LocalStorage", ['$window',
  function ($window) {
    var _facebookAuth = null

    return {

      set justSignedIn(value) {
        _justSignedIn = value;
      },
      get justSignedIn() {
        return _justSignedIn;
      },

      set facebookAuth(value) {
        _facebookAuth = value;
      },
      get facebookAuth() {
        return _facebookAuth;
      },

      clear: function () {
        localStorage.clear();
      }
    };
  }]);
