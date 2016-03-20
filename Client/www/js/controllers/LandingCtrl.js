starterControllers.controller('LandingCtrl', function ($scope, $stateParams, Facebook, LocalStorage, $location) {
  $scope.getLoginStatus = function () {
    Facebook.getLoginStatus(function (response) {
      if (response.status === 'connected') {
        $scope.loggedIn = true;
        $location.path('registration');
      } else {
        $scope.loggedIn = false;
      }
    });
  };

  $scope.fbLogin = function () {
    // From now on you can use the Facebook service just as Facebook api says
    Facebook.login(function (response) {
      // Do something with response.
      console.log(response);
      LocalStorage.facebookAuth = response;
      $location.path('registration');
    });
  };
});
